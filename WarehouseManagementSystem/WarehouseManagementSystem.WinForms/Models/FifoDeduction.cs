using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.WinForms.Models
{
    public class FifoDeduction
    {
        public string BatchId { get; set; }

        public int QuantityToDeduct { get; set; }
    }
}
