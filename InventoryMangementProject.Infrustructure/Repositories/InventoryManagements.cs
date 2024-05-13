using InventoryManagementProject.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMangementProject.Infrustructure.Repositories
{
    public class InventoryManagements : IInventoryManagement
    {
        private readonly InventoryManagmentContext _context;
        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }
        public IVendorRepository Vendors { get; }
        public ICustomerReopistory Customers { get; }
        public IPurchaseRepository Purchases { get; }
        public InventoryManagements(InventoryManagmentContext context,
                                ICategoryRepository categories,
                                IProductRepository productRepository,
                                IVendorRepository vendorRepository,
                                ICustomerReopistory customerReopistory,
                                IPurchaseRepository purchaseRepository)
        {
            _context = context;
            Categories = categories;
            Products = productRepository;
            Vendors = vendorRepository;
            Customers = customerReopistory;
            Purchases = purchaseRepository;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
