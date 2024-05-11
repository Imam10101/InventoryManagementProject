using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementProject.Core.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public bool IsDeliver { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime SaleDate { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public Customer Customer { get; set; }
    }
}
