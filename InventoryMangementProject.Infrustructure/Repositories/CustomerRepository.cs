using InventoryManagementProject.Core.Interfaces;
using InventoryManagementProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMangementProject.Infrustructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerReopistory
    {
        public CustomerRepository(InventoryManagmentContext dbContext) : base(dbContext) { }
    }
}
