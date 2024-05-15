using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementProject.Core.Models
{
    public class Purchasedetails
    {
        public int Id { get;set; }
        [ForeignKey("Purchase")]
        public int purId { get;set; }
        [ForeignKey("Product")]
        public int PrdId { get; set;}
        public int Qty { get; set; }


        public virtual Purchase? Purchase { get; set; }
        public virtual Product? Product { get; set; }

    }
}