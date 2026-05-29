using System;
using System.Collections.Generic;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Rule
{
    public class FifoRule
    {
        public bool Apply(
            IEnumerable<Batch> batches,
            int requiredQuantity,
            out List<FifoDeduction> deductions)
        {
            if (batches == null)
            {
                throw new ArgumentNullException(
                    nameof(batches)
                );
            }

            deductions =
                new List<FifoDeduction>();

            if (requiredQuantity <= 0)
            {
                return false;
            }

            List<Batch> orderedBatches =
                new List<Batch>();

            foreach (
                Batch batch
                in batches
            )
            {
                if (
                    batch.AvailableQuantity > 0
                )
                {
                    orderedBatches.Add(
                        batch
                    );
                }
            }

            // Sắp xếp theo CreatedDate tăng dần
            for (
                int i = 0;
                i < orderedBatches.Count - 1;
                i++
            )
            {
                for (
                    int j = i + 1;
                    j < orderedBatches.Count;
                    j++
                )
                {
                    if (
                        orderedBatches[i]
                            .CreatedDate
                        >
                        orderedBatches[j]
                            .CreatedDate
                    )
                    {
                        Batch temp =
                            orderedBatches[i];

                        orderedBatches[i] =
                            orderedBatches[j];

                        orderedBatches[j] =
                            temp;
                    }
                }
            }

            int totalQuantity = 0;

            foreach (
                Batch batch
                in orderedBatches
            )
            {
                totalQuantity +=
                    batch.AvailableQuantity;
            }

            if (
                totalQuantity
                <
                requiredQuantity
            )
            {
                return false;
            }

            int remaining =
                requiredQuantity;

            foreach (
                Batch batch
                in orderedBatches
            )
            {
                if (remaining <= 0)
                {
                    break;
                }

                int takeQuantity =
                    Math.Min(
                        batch.AvailableQuantity,
                        remaining
                    );

                FifoDeduction deduction =
                    new FifoDeduction();

                deduction.BatchId =
                    batch.BatchId;

                deduction.QuantityToDeduct =
                    takeQuantity;

                deductions.Add(
                    deduction
                );

                remaining -=
                    takeQuantity;
            }

            return true;
        }

        public int GetAvailableQuantity(
            IEnumerable<Batch> batches)
        {
            if (
                batches == null
            )
            {
                return 0;
            }

            int total = 0;

            foreach (
                Batch batch
                in batches
            )
            {
                if (
                    batch.Quantity > 0
                )
                {
                    total +=
                        batch.AvailableQuantity;
                }
            }

            return total;
        }
    }
}