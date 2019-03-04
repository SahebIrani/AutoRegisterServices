namespace AutoRegisterServices.UseCases.GetCustomerDetails
{
    using AutoRegisterServices.Application.Queries;
    using AutoRegisterServices.Application.Results;

    using Microsoft.AspNetCore.Mvc;

    using System;
    using System.Threading;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonQueries PersonQueries;

        public PersonController(IPersonQueries personQueries) => PersonQueries = personQueries ?? throw new ArgumentNullException(nameof(personQueries));

        [HttpGet("{personId}", Name = "GetPerson")]
        public async Task<IActionResult> GetPerson(Guid personId, CancellationToken cancellationToken)
        {
            PersonResult personResult = await PersonQueries.GetPersonAsync(personId, cancellationToken);

            return Ok(personResult);
        }
    }
}
