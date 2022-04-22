using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Customer_Repository
    {
        public readonly List<Customers> _customersInDB = new List<Customers>();
        private int _count;
        public List<Customers> GetCustomers()
        {
            return _customersInDB.OrderBy(c => c.LastName).ToList();
        }
        public Customers GetCustomerByID(int id)
        {
            foreach(var customer in _customersInDB)
            {
                if(customer.ID == id)
                {
                    return customer;
                }
            }
            return null;
        }
        public bool AddCustomer(Customers customer)
        {
            if(customer != null)
            {
                _count++;
                customer.ID = _count;
                _customersInDB.Add(customer);
                return true;
            }
            return false;
        }
        public bool RemoveCustomer(int id)
        {
            var customer = GetCustomerByID(id);
            if(customer != null)
            {
                _customersInDB.Remove(customer);
                return true;
            }
            return false;
        }
        public bool UpdateCustomer(int customerID, Customers newCustomerData)
        {
            Customers oldCustomerData = GetCustomerByID(customerID);

            if(oldCustomerData != null)
            {
                oldCustomerData.FirstName = newCustomerData.FirstName;
                oldCustomerData.LastName = newCustomerData.LastName;
                oldCustomerData.CustomerType = newCustomerData.CustomerType;
                return true; 
            }
            else
            {
                return false;
            }
        }

    }
