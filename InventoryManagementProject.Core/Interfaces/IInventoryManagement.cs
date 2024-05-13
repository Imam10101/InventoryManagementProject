using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementProject.Core.Interfaces
{
    public interface IInventoryManagement : IDisposable
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        IVendorRepository Vendors { get; }
        ICustomerReopistory Customers { get; }

        IPurchaseRepository Purchases { get; }

        int Save();
    }
}
