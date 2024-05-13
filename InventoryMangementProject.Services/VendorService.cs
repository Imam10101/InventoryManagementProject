using InventoryManagementProject.Core.Interfaces;
using InventoryManagementProject.Core.Models;
using InventoryMangementProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMangementProject.Services
{
    public class VendorService : IVendorService
    {
        public IInventoryManagement _inventory;
        public VendorService(IInventoryManagement inventory)
        {
            _inventory = inventory;
        }

        public async Task<bool> CreateVendor(Vendor vendor)
        {
            if (vendor != null)
            {
                await _inventory.Vendors.Add(vendor);
                var result = _inventory.Save();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> DeleteVendor(int id)
        {
            if (id > 0)
            {
                var vendor = await _inventory.Vendors.GetById(id);
                if (vendor != null)
                {
                    _inventory.Vendors.Delete(vendor);

                    var result = _inventory.Save();
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return false;
        }

        public async Task<IEnumerable<Vendor>> GetAllVendors()
        {
            var vendors = await _inventory.Vendors.GetAll();
            return vendors;
        }

        public async Task<Vendor> GetVendorById(int id)
        {
            if (id > 0)
            {
                var vendor = await _inventory.Vendors.GetById(id);
                if (vendor != null)
                {
                    return vendor;
                }
            }
            return null;
        }

        public async Task<bool> UpdateVendor(Vendor vendor)
        {
            if (vendor != null)
            {
                var prod = await _inventory.Vendors.GetById(vendor.VendorId);
                if (prod != null)
                {
                    prod.VendorName = vendor.VendorName;
                    prod.VendorContact = vendor.VendorContact;
                    _inventory.Vendors.Update(prod);
                    var result = _inventory.Save();
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
