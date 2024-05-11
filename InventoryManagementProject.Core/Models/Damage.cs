using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementProject.Core.Models
{
    public class Damage
    {
        [Key]
        public int DamageId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string DamageDescription { get; set; } = null!;
        public Product? Product { get; set; }

    }
}
