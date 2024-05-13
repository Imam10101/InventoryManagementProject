using InventoryManagementProject.Core.Models;
using InventoryMangementProject.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await customerService.GetAllCustomers();
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }
        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            var customer = await customerService.GetCustomerById(customerId);
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            var isCustomerCreated = await customerService.CreateCustomer(customer);
            if (isCustomerCreated)
            {
                return Ok(isCustomerCreated);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            if (customer != null)
            {
                var isCustomerUpdated = await customerService.UpdateCustomer(customer);
                if (isCustomerUpdated)
                {
                    return Ok(isCustomerUpdated);
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
        public async Task<IActionResult> DeleteCustomr(int id)
        {
            var isCustomerDeleted = await customerService.DeleteCustomer(id);
            if (isCustomerDeleted)
            {
                return Ok(isCustomerDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
