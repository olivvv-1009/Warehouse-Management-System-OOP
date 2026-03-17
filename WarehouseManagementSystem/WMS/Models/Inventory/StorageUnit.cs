using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Models.Inventory
{
    public abstract class StorageUnit
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
