using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementProject.Core.Models
{
    public class SalesDetails
    {
        public int Id { get; set; }
        [ForeignKey("Sale")]
        public int purId { get; set; }
        [ForeignKey("Product")]
        public int PrdId { get; set; }
        public int Qty { get; set; }


        public virtual Sale? Sale { get; set; }
        public virtual Product? Product { get; set; }
    }
}
