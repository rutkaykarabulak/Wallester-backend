using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wallester.Api.DbModels;
using Wallester.Api.Services;
using Wallester.Api.EFModels;
using Customer = Wallester.Api.DbModels.Customer;

namespace Wallester.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Actions
        [HttpGet]
        public IActionResult Get()
        {
            List<Customer> customers = customerService.GetAll();

            if (customers == null)
            {
                return BadRequest("There is no customer in the context");
            }

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(modelStateErrorMessage);
            }

            Customer? customer = await customerService.GetCustomer(id);

            if (customer == null)
            {
                return NotFound("There is no customer with specified Id");
            }

            return Ok(customer);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CustomerPut putObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(modelStateErrorMessage);
            }

            bool isSuccessfull = await customerService.Update(putObject);

            if (!isSuccessfull)
            {
                return BadRequest(isSuccessfull);
            }

            return Ok(isSuccessfull);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(modelStateErrorMessage);
            }

            customerService.Create(customer);

            return Ok(customer);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(modelStateErrorMessage);
            }

            bool isSuccessfull = await customerService.Remove(id);

            if(!isSuccessfull)
            {
                return NotFound("There is no customer associated with this id");
            }

            return Ok($"Customer with id {id} is successfully deleted.");
        }
        #endregion

        #region Fields
        private readonly CustomerService customerService;
        private const string modelStateErrorMessage = "Model state is not valid";
        #endregion

        public CustomerController(PostgresDbContext postgresDbContext)
        {
            customerService = new CustomerService(postgresDbContext);
        }
       
    }
}
