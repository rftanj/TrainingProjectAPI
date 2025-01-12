using Microsoft.AspNetCore.Mvc;
using TrainingProjectAPI.Models;
using TrainingProjectAPI.Models.DB;
using TrainingProjectAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrainingProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var customerList = _customerService.GetListCustomer();
                var response = new GeneralResponse
                {
                    StatusCode = "01",
                    StatusDesc = "Success",
                    Data = customerList
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new GeneralResponse
                {
                    StatusCode = "99",
                    StatusDesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };
                return BadRequest(response);
            }
            
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound("Not found");
            }

            return Ok("Delete OK");
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            try
            {
                var insertCustomer = _customerService.CreateCustomer(customer);
                if (insertCustomer)
                {
                    var responseSuccess = new GeneralResponse
                    {
                        StatusCode = "01",
                        StatusDesc = "Insert Customer Success",
                        Data = null
                    };
                    return Ok(responseSuccess);
                }

                var responseFailed = new GeneralResponse
                {
                    StatusCode = "02",
                    StatusDesc = "Insert Customer Failed",
                    Data = null
                };

                return BadRequest(responseFailed);
            }
            catch (Exception ex)
            {
                var responseFailed = new GeneralResponse
                {
                    StatusCode = "99",
                    StatusDesc = "Failed | " + ex.Message.ToString(),
                    Data = null
                };

                return BadRequest(responseFailed);
            }
            
        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        public IActionResult Put(Customer customer)
        {
            try
            {
                var updateCustomer = _customerService.UpdateCustomer(customer);
                if (updateCustomer)
                {
                    return Ok("Update Customer Success");
                }

                return BadRequest("Update Customer Failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
                throw;
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
