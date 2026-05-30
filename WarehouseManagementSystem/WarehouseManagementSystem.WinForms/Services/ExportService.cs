using System;
using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;
using WarehouseManagementSystem.WinForms.Rule;
using WarehouseManagementSystem.WinForms.Utils;

namespace WarehouseManagementSystem.WinForms.Services
{
    public class ExportService
    {
        private readonly BatchRepository _batchRepository;
        private readonly ExportRepository _exportRepository;
        private readonly TransactionRepository _transactionRepository;
        private readonly FifoRule _fifoRule;

        public ExportService()
        {
            _batchRepository = new BatchRepository();
            _exportRepository = new ExportRepository();
            _transactionRepository = new TransactionRepository();
            _fifoRule = new FifoRule();
        }

        public bool CreateExportInvoice(
    string employeeName,
    string destination,
    List<OrderDetail> details)
        {
            List<Batch> allBatches =
                _batchRepository.GetAll();

            foreach (
                OrderDetail detail
                in details
            )
            {
                List<Batch> batches =
                    new List<Batch>();

                foreach (
                    Batch batch
                    in allBatches
                )
                {
                    if (
                        batch.ProductId ==
                        detail.ProductId
                    )
                    {
                        batches.Add(batch);
                    }
                }

                List<FifoDeduction>
                    tempDeductions;

                bool ok =
                    _fifoRule.Apply(
                        batches,
                        detail.Quantity,
                        out tempDeductions
                    );

                if (!ok)
                {
                    return false;
                }
            }

            List<OrderDetail> exportDetails =
                new List<OrderDetail>();

            foreach (
                OrderDetail detail
                in details
            )
            {
                List<Batch> batches =
                    new List<Batch>();

                foreach (
                    Batch batch
                    in allBatches
                )
                {
                    if (
                        batch.ProductId ==
                        detail.ProductId
                    )
                    {
                        batches.Add(batch);
                    }
                }

                List<FifoDeduction>
                    deductions;

                _fifoRule.Apply(
                    batches,
                    detail.Quantity,
                    out deductions
                );

                foreach (
                    FifoDeduction deduction
                    in deductions
                )
                {
                    Batch batch = null;

                    foreach (
                        Batch item
                        in allBatches
                    )
                    {
                        if (
                            item.BatchId ==
                            deduction.BatchId
                        )
                        {
                            batch = item;
                            break;
                        }
                    }

                    if (batch == null)
                    {
                        continue;
                    }

                    exportDetails.Add(
                        new OrderDetail
                        {
                            ProductId =
                                batch.ProductId,

                            BatchId =
                                batch.BatchId,

                            Quantity =
                                deduction.QuantityToDeduct,

                            UnitPrice =
                                detail.UnitPrice,

                            TotalPrice =
                                deduction.QuantityToDeduct
                                * detail.UnitPrice,

                            LocationCode =
                                batch.LocationCode,
                        }
                    );

                    batch.ExportedQuantity +=
                        deduction.QuantityToDeduct;

                    batch.RemainingQuantity -=
                        deduction.QuantityToDeduct;

                    if (
                        batch.RemainingQuantity <= 0
                    )
                    {
                        batch.Status =
                            "Out of Stock";
                    }
                }
            }

            _batchRepository.Update(
                allBatches
            );

            List<ExportInvoice>
                invoices =
                    _exportRepository
                        .GetAll();

            List<string>
                invoiceIds =
                    new List<string>();

            foreach (
                ExportInvoice item
                in invoices
            )
            {
                invoiceIds.Add(
                    item.InvoiceId
                );
            }

            int nextNumber =
                IdGenerator
                    .GetNextNumber(
                        invoiceIds,
                        "EXP"
                    );

            decimal totalAmount = 0;

            foreach (
                OrderDetail detail
                in exportDetails
            )
            {
                totalAmount +=
                    detail.TotalPrice;
            }

            ExportInvoice invoice =
                new ExportInvoice();

            invoice.InvoiceId =
                IdGenerator
                    .GenerateExportId(
                        nextNumber
                    );

            invoice.EmployeeName =
                employeeName;

            invoice.Destination =
                destination;

            invoice.CreatedDate =
                DateTime.Now;

            invoice.Status =
                "Completed";

            invoice.OrderDetails =
                exportDetails;

            invoice.TotalAmount =
                totalAmount;

            _exportRepository.Add(
                invoice
            );

            foreach (
                OrderDetail detail
                in exportDetails
            )
            {
                CreateTransaction(
                    detail.ProductId,
                    detail.Quantity,
                    invoice.InvoiceId
                );
            }

            return true;
        }

        private void CreateTransaction(
	string productId,
	int quantity,
	string InvoiceId)
		{
			List<Transaction>
				transactions =
					_transactionRepository
						.GetAll();

			List<string>
				transactionIds =
					new List<string>();

			foreach (
				Transaction item
				in transactions
			)
			{
				transactionIds.Add(
					item.TransactionId
				);
			}

			int nextNumber =
				IdGenerator
					.GetNextNumber(
						transactionIds,
						"TRN"
					);

			Transaction transaction =
				new Transaction();

			transaction.TransactionId =
				IdGenerator
					.GenerateTransactionId(
						nextNumber
					);

			transaction.ProductId =
				productId;

			transaction.Quantity =
				quantity;

			transaction.TransactionType =
				Transaction.Types.Export;

			transaction.ReferenceId =
				InvoiceId;

			_transactionRepository
				.Add(
					transaction
				);
		}

		// ─── ExportProduct (Complete ngay) ───────────────────────
		public bool ExportProduct(
	string productId,
	int quantity,
	string employeeName,
	decimal unitPrice,
	string destination = "")
		{
			List<Batch> batches =
				_batchRepository
					.GetByProductId(
						productId
					);

			List<FifoDeduction>
				deductions;

			bool ok =
				_fifoRule.Apply(
					batches,
					quantity,
					out deductions
				);

			if (!ok)
			{
				return false;
			}

			List<Batch> allBatches =
				_batchRepository
					.GetAll();

			foreach (
				FifoDeduction d
				in deductions
			)
			{
				Batch batch = null;

				foreach (
					Batch item
					in allBatches
				)
				{
					if (
						item.BatchId
						==
						d.BatchId
					)
					{
						batch = item;
						break;
					}
				}

				if (batch != null)
				{
                    batch.ExportedQuantity +=
     d.QuantityToDeduct;

                    batch.RemainingQuantity -=
                        d.QuantityToDeduct;

                    if (
                        batch.RemainingQuantity <= 0
                    )
                    {
                        batch.Status =
                            "Out of Stock";
                    }
                }
			}

			_batchRepository
				.Update(
					allBatches
				);

			List<ExportInvoice>
				invoices =
					_exportRepository
						.GetAll();

			List<string>
				invoiceIds =
					new List<string>();

			foreach (
				ExportInvoice item
				in invoices
			)
			{
				invoiceIds.Add(
					item.InvoiceId
				);
			}

			int nextNumber =
				IdGenerator
					.GetNextNumber(
						invoiceIds,
						"EXP"
					);

			ExportInvoice invoice =
				new ExportInvoice();

			invoice.InvoiceId =
				IdGenerator
					.GenerateExportId(
						nextNumber
					);

			invoice.EmployeeName =
				employeeName;

			invoice.Destination =
				destination;

			invoice.CreatedDate =
				DateTime.Now;

			invoice.Status =
				"Completed";

			OrderDetail detail =
				new OrderDetail();

			detail.ProductId =
				productId;

			detail.Quantity =
				quantity;

			detail.UnitPrice =
				unitPrice;

			detail.TotalPrice =
				quantity * unitPrice;

			invoice.OrderDetails.Add(
				detail
			);

			decimal totalAmount = 0;

			foreach (
				OrderDetail item
				in invoice.OrderDetails
			)
			{
				totalAmount +=
					item.TotalPrice;
			}

			invoice.TotalAmount =
				totalAmount;

			_exportRepository
				.Add(
					invoice
				);

			CreateTransaction(
				productId,
				quantity,
				invoice.InvoiceId
			);

			return true;
		}

		// ─── SaveDraft ────────────────────────────────────────────
		public string SaveDraft(
	List<(string ProductId,
		  int Quantity,
		  decimal UnitPrice)> items,
	string employeeName,
	string destination)
		{
			List<ExportInvoice>
				invoices =
					_exportRepository
						.GetAll();

			List<string>
				invoiceIds =
					new List<string>();

			foreach (
				ExportInvoice item
				in invoices
			)
			{
				invoiceIds.Add(
					item.InvoiceId
				);
			}

			int nextNumber =
				IdGenerator
					.GetNextNumber(
						invoiceIds,
						"EXP"
					);

			ExportInvoice invoice =
				new ExportInvoice();

			invoice.InvoiceId =
				IdGenerator
					.GenerateExportId(
						nextNumber
					);

			invoice.EmployeeName =
				employeeName;

			invoice.Destination =
				destination;

			invoice.CreatedDate =
				DateTime.Now;

			invoice.Status =
				"Draft";

			foreach (
				(string ProductId,
				 int Quantity,
				 decimal UnitPrice)
				item
				in items
			)
			{
				OrderDetail detail =
					new OrderDetail();

				detail.ProductId =
					item.ProductId;

				detail.Quantity =
					item.Quantity;

				detail.UnitPrice =
					item.UnitPrice;

				detail.TotalPrice =
					item.Quantity
					* item.UnitPrice;

				invoice.OrderDetails.Add(
					detail
				);
			}

			decimal totalAmount = 0;

			foreach (
				OrderDetail detail
				in invoice.OrderDetails
			)
			{
				totalAmount +=
					detail.TotalPrice;
			}

			invoice.TotalAmount =
				totalAmount;

			_exportRepository
				.Add(
					invoice
				);

			return invoice.InvoiceId;
		}

		// ─── CompleteDraft ────────────────────────────────────────
		public bool CompleteDraft(
	string InvoiceId)
		{
			ExportInvoice invoice =
				null;

			List<ExportInvoice>
				invoices =
					_exportRepository
						.GetAll();

			foreach (
				ExportInvoice item
				in invoices
			)
			{
				if (
					item.InvoiceId
					== InvoiceId
				)
				{
					invoice = item;
					break;
				}
			}

			if (
				invoice == null
				|| invoice.Status
				== "Completed"
			)
			{
				return false;
			}

			List<Batch>
				allBatches =
					_batchRepository
						.GetAll();

			foreach (
				OrderDetail detail
				in invoice.OrderDetails
			)
			{
				List<Batch>
					batches =
						new List<Batch>();

				foreach (
					Batch batch
					in allBatches
				)
				{
					if (
						batch.ProductId
						== detail.ProductId
					)
					{
						batches.Add(
							batch
						);
					}
				}
                List<FifoDeduction>
    deductions;

                bool ok =
					_fifoRule.Apply(
						batches,
						detail.Quantity,
						out deductions
					);

				if (!ok)
				{
					return false;
				}

				foreach (
					FifoDeduction deduction
					in deductions
				)
				{
					foreach (
						Batch batch
						in allBatches
					)
					{
						if (
							batch.BatchId
							== deduction.BatchId
						)
						{
							batch.ExportedQuantity +=
								deduction
									.QuantityToDeduct;

							if (
								batch.AvailableQuantity
								<= 0
							)
							{
								batch.Status =
									"Out of Stock";
							}

							break;
						}
					}
				}

				CreateTransaction(
					detail.ProductId,
					detail.Quantity,
					InvoiceId
				);
			}

			_batchRepository
				.Update(
					allBatches
				);

			invoice.Status =
				"Completed";

			_exportRepository
				.Update(
					invoice
				);

			return true;
		}

	}
}