using InventoryManagementProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMangementProject.Services.Interfaces
{
    public interface IPurchaseService
    {

        Task<bool> CreatePurchase(Purchase purchase);
        Task<IEnumerable<Purchase>> GetAllPurchase();
        Task<Purchase> GetPurchaseById(int id);
        Task<bool> UpdatePurchase(Purchase purchase);
        Task<bool> DeletePurchase(int id);

    }
}
