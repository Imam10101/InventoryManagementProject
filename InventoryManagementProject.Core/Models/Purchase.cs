using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementProject.Core.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseId { get; set; }
        [ForeignKey("Vendor")]
        public int VendorId { get; set; }

        public Vendor? Vendor { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime PurchaseDate { get; set; }
        public double TotalPrice { get; set; }


    }
}
