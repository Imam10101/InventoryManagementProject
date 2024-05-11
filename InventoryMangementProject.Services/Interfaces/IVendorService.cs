using InventoryManagementProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMangementProject.Services.Interfaces
{
    public interface IVendorService
    {
        Task<bool> CreateVendor(Vendor vendor);
        Task<IEnumerable<Vendor>> GetAllVendors();
        Task<Vendor> GetVendorById(int id);
        Task<bool> UpdateVendor(Vendor vendor);
        Task<bool> DeleteVendor(int id);
    }
}
