using System;
using WarehouseManagementSystem.WinForms.Models;
using WarehouseManagementSystem.WinForms.Repositories;

namespace WarehouseManagementSystem.WinForms.Services
{
    internal class ImportService
    {
        private readonly InventoryRepository
            _inventoryRepository;

        private readonly BatchRepository
            _batchRepository;

        private readonly LocationRepository
            _locationRepository;

        private readonly ImportRepository
            _importRepository;

        public ImportService()
        {
            _inventoryRepository =
                new InventoryRepository();

            _batchRepository =
                new BatchRepository();

            _locationRepository =
                new LocationRepository();

            _importRepository =
                new ImportRepository();
        }

        public bool ImportProduct(
            InventoryItem item,
            string locationCode)
        {
            WarehouseLocation location =
                _locationRepository
                .FindByCode(locationCode);

            if (location == null)
            {
                return false;
            }

            if (location.UsedCapacity
                + item.Quantity
                > location.Capacity)
            {
                return false;
            }

            Batch batch =
                new Batch();

            batch.BatchId =
                Guid.NewGuid().ToString();

            batch.ProductId =
                item.ProductId;

            batch.LocationCode =
                locationCode;

            batch.Quantity =
                item.Quantity;

            batch.ImportDate =
                DateTime.Now;

            item.BatchId =
                batch.BatchId;

            item.LocationCode =
                locationCode;

            _batchRepository.Add(batch);

            _inventoryRepository.Add(item);

            location.UsedCapacity +=
                item.Quantity;

            _locationRepository.Update();

            ImportInvoice invoice =
                new ImportInvoice();

            invoice.ImportId =
                Guid.NewGuid().ToString();

            invoice.ProductId =
                item.ProductId;

            invoice.BatchId =
                batch.BatchId;

            invoice.LocationCode =
                locationCode;

            invoice.Quantity =
                item.Quantity;

            invoice.ImportDate =
                DateTime.Now;

            _importRepository.Add(invoice);

            return true;
        }
    }
}