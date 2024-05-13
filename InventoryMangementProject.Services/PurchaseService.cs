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
    public class PurchaseService : IPurchaseService
    {
        private readonly IInventoryManagement inventory;
        public PurchaseService(IInventoryManagement _inventory)
        {
            inventory = _inventory;
        }

        public async Task<bool> CreatePurchase(Purchase purchase)

        {
            if (purchase != null)
            {
                await inventory.Purchases.Add(purchase);
                var result = inventory.Save();
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

        public async Task<bool> DeletePurchase(int id)
        {
            if (id > 0)
            {
                var purchase = await inventory.Purchases.GetById(id);
                if (purchase != null)
                {
                    inventory.Purchases.Delete(purchase);

                    var result = inventory.Save();
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

        public async Task<IEnumerable<Purchase>> GetAllPurchase()
        {
            var purchase = await inventory.Purchases.GetAll();
            return purchase;
        }

        public async Task<Purchase> GetPurchaseById(int id)
        {
            if (id > 0)
            {
                var purchase = await inventory.Purchases.GetById(id);
                if (purchase != null)
                {
                    return purchase;
                }
            }
            return null;
        }

        public async Task<bool> UpdatePurchase(Purchase purchase)
        {
            if (purchase != null)
            {
                var proc = await inventory.Purchases.GetById(purchase.PurchaseId);
                if (proc != null)
                {
                    proc.PurchaseId = purchase.PurchaseId;
                    proc.PurchaseDate = purchase.PurchaseDate;
                    inventory.Purchases.Update(proc);
                    var result = inventory.Save();
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
