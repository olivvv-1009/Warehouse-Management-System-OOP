using System.Collections.Generic;

namespace WMS.Models.Inventory
{
    public class Shelf : StorageUnit
    {
        public List<Batch> Batches { get; set; }

        public Shelf()
        {
            Batches = new List<Batch>();
        }

        public void AddBatch(Batch batch)
        {
            Batches.Add(batch);
        }
    }
}