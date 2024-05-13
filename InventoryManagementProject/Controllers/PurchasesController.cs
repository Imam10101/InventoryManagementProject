using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagementProject.Core.Models;
using InventoryMangementProject.Infrustructure;
using InventoryMangementProject.Services.Interfaces;

namespace InventoryManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseService Service;

        public PurchasesController(IPurchaseService _Service)
        {
            Service = _Service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPurchase()
        {
            var purchase = await Service.GetAllPurchase();
            if (purchase == null)
            {
                return NotFound();
            }
            return Ok(purchase);
        }

        [HttpGet("{purchaseId}")]
        public async Task<IActionResult> GetPurchaseById(int purchaseId)
        {
            var purchase = await Service.GetPurchaseById(purchaseId);
            if (purchase != null)
            {
                return Ok(purchase);
            }
            else
            {
                return BadRequest();
            }
        }

        // Post        
        [HttpPost]
        public async Task<IActionResult> CreatePurchase(Purchase purchase)
        {
            var isPurchaseCreated = await Service.CreatePurchase(purchase);
            if (isPurchaseCreated)
            {
                return Ok(isPurchaseCreated);
            }
            else
            {
                return BadRequest();
            }

            return NoContent();

        }

        //Update
        [HttpPut]
        public async Task<IActionResult> UpdatePurchase(Purchase purchase)
        {
            if (purchase != null)
            {
                var isPrchaseUpdated = await Service.UpdatePurchase(purchase);
                if (isPrchaseUpdated)
                {
                    return Ok(isPrchaseUpdated);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            var isPurchaseDeleted = await Service.DeletePurchase(id);
            if (isPurchaseDeleted)
            {
                return Ok(isPurchaseDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
