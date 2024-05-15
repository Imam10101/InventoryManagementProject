using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InventoryManagementProject.Core.Models
{
    public class Sale
    {
        public Sale()
        {
            SalesDetails = new HashSet<SalesDetails>();
        }
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
        [JsonIgnore]
        public Product? Product { get; set; }
        [JsonIgnore]
        public Order? Order { get; set; }
        [JsonIgnore]
        public Customer? Customer { get; set; }
        public ICollection<SalesDetails>? SalesDetails { get; set; }
    }
}
