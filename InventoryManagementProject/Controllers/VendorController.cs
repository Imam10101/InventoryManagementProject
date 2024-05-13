using InventoryManagementProject.Core.Models;
using InventoryMangementProject.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        public readonly IVendorService vendorService;
        public VendorController(IVendorService vendorService)
        {
            this.vendorService = vendorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllVendors()
        {
            var vendors = await vendorService.GetAllVendors();
            if (vendors == null)
            {
                return NotFound();
            }
            return Ok(vendors);
        }
        [HttpGet("{vendorId}")]
        public async Task<IActionResult> GetVendorById(int vendorId)
        {
            var vendor = await vendorService.GetVendorById(vendorId);
            if (vendor != null)
            {
                return Ok(vendor);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateVendor(Vendor vendor)
        {
            var isVendorCreated = await vendorService.CreateVendor(vendor);
            if (isVendorCreated)
            {
                return Ok(isVendorCreated);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateVendor(Vendor vendor)
        {
            if (vendor != null)
            {
                var isVendorCreated = await vendorService.UpdateVendor(vendor);
                if (isVendorCreated)
                {
                    return Ok(isVendorCreated);
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor(int id)
        {
            var isVendorDeleted = await vendorService.DeleteVendor(id);
            if (isVendorDeleted)
            {
                return Ok(isVendorDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
