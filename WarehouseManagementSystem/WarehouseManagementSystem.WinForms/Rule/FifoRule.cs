using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseManagementSystem.WinForms.Models;

namespace WarehouseManagementSystem.WinForms.Rule
{
    public class FifoRule
    {
        public bool Apply(
            IEnumerable<Batch> batches,
            int requiredQuantity,
            out List<
                (string BatchId,
                int QuantityToDeduct)
            > deductions)
        {
            if (batches == null)
            {
                throw new ArgumentNullException(
                    nameof(batches)
                );
            }

            deductions =
                new List<
                    (string, int)
                >();

            if (requiredQuantity <= 0)
            {
                return false;
            }

            List<Batch>
                orderedBatches =
                    batches
                    .Where(
                        x =>
                        x.AvailableQuantity > 0
                    )
                    .OrderBy(
                        x =>
                        x.ImportDate
                    )
                    .ToList();

            int totalQuantity =
                orderedBatches
                .Sum(
                    x =>
                    x.AvailableQuantity
                );

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

                deductions.Add(
                    (
                        batch.BatchId,
                        takeQuantity
                    )
                );

                remaining -=
                    takeQuantity;
            }

            return true;
        }

        public int
        GetAvailableQuantity(
            IEnumerable<Batch>
            batches)
        {
            if (
                batches == null
            )
            {
                return 0;
            }

            return batches
                .Where(
                    x =>
                    x.Quantity > 0
                )
                .Sum(
                    x =>
                    x.AvailableQuantity
                );
        }
    }
}