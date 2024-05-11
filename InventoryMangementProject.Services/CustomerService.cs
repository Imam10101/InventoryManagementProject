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
    public class CustomerService : ICustomerService
    {
        public IInventoryManagement _inventory;
        public CustomerService(IInventoryManagement inventory)
        {
            _inventory = inventory;
        }
        public async Task<bool> CreateCustomer(Customer customer)
        {
            if (customer != null)
            {
                await _inventory.Customers.Add(customer);
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

        public async Task<bool> DeleteCustomer(int id)
        {
            if (id > 0)
            {
                var customer = await _inventory.Customers.GetById(id);
                if (customer != null)
                {
                    _inventory.Customers.Delete(customer);
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
            return false;
        }

        public Task<IEnumerable<Customer>> GetAllCustomers()
        {
            var customers = _inventory.Customers.GetAll();
            return customers;
        }

        public Task<Customer> GetCustomerById(int id)
        {
            if (id > 0)
            {
                var customer = _inventory.Customers.GetById(id);
                if (customer != null)
                {
                    return customer;
                }
            }
            return null;
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            if (customer != null)
            {
                var customers = await _inventory.Customers.GetById(customer.CustomerId);
                if (customers != null)
                {
                    customers.CustomerName = customer.CustomerName;
                    customers.CustomerContact = customer.CustomerContact;
                    customers.CustomerAddress = customer.CustomerAddress;

                    _inventory.Customers.Update(customers);
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
