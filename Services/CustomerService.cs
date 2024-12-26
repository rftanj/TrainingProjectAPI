using TrainingProjectAPI.Models;
using TrainingProjectAPI.Models.DB;

namespace TrainingProjectAPI.Services
{
    public class CustomerService
    {
        private readonly ApplicationContext _context;
        public CustomerService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Customer> GetListCustomer()
        {
            var datas = _context.Customers.ToList();
            return datas;
        }

        public bool CreateCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool UpdateCustomer(Customer customer) 
        {
            try
            {
                var customerOld = _context.Customers.Where(x => x.Id == customer.Id).FirstOrDefault();

                if (customerOld != null) {
                    customerOld.Name = customer.Name;
                    customerOld.Address = customer.Address;
                    customerOld.City = customer.City;
                    customerOld.PhoneNumber = customer.PhoneNumber;
                    
                    _context.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Customer GetCustomerById(int id)
        {
            var costumerData = _context.Customers.Where(x => x.Id == id).FirstOrDefault();
            if (costumerData == null) {
                return null;
            }
            
            return costumerData; 

        }

        public bool DeleteCustomer(int id) {
            try
            {
                var costumerData = _context.Customers.
                    FirstOrDefault(x => x.Id == id);

                if (costumerData != null)
                {
                    _context.Customers.Remove(costumerData);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
