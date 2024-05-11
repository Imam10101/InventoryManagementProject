using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementProject.Core.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int VendorId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderPrice { get; set; }
        public bool IsEmergency { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime? EmDeliveryDate { get; set; }
    }
}
