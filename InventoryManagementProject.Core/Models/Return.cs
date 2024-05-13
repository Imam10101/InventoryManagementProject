using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementProject.Core.Models
{
    public class Return
    {
        [Key]
        public int ReturnId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public string ReturnReason { get; set; } = null!;
        public DateTime ReturnDate { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}
