namespace AutoRegisterServices.UseCases.GetCustomerDetails
{
    using AutoRegisterServices.Application.Queries;
    using AutoRegisterServices.Application.Results;

    using Microsoft.AspNetCore.Mvc;

    using System;
    using System.Threading;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerQueries CustomerQueries;

        public CustomerController(ICustomerQueries customerQueries) => CustomerQueries = customerQueries ?? throw new ArgumentNullException(nameof(customerQueries));

        [HttpGet("{customerId}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(Guid customerId, CancellationToken cancellationToken)
        {
            CustomerResult customerResult = await CustomerQueries.GetCustomerAsync(customerId, cancellationToken);

            return Ok(customerResult);
        }
    }
}
