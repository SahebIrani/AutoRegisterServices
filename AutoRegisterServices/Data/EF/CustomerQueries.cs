using AutoRegisterServices.Application;
using AutoRegisterServices.Application.Entities;
using AutoRegisterServices.Application.Queries;
using AutoRegisterServices.Application.Results;

using Microsoft.EntityFrameworkCore;

using System;
using System.Data.SqlTypes;
using System.Threading;
using System.Threading.Tasks;

namespace AutoRegisterServices.Data.EF
{
    public class CustomerQueries : ICustomerQueries
    {
        private readonly Context Context;
        private readonly IResultConverter RsultConverter;

        public CustomerQueries(Context context, IResultConverter resultConverter)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            RsultConverter = resultConverter ?? throw new ArgumentNullException(nameof(resultConverter));
        }
        public async Task<CustomerResult> GetCustomerAsync(Guid id, CancellationToken cancellationToken = default)
        {
            //Customer customer = await Context.Customers.FindAsync(id, cancellationToken);
            Customer customer = await Context.Customers.SingleOrDefaultAsync(c => c.CustomerId == id, cancellationToken);

            if (customer == null)
                throw new SqlNullValueException($"The customer {id} does not exists or is not processed yet ..");

            CustomerResult customerResult = RsultConverter.Map<CustomerResult>(customer);
            return customerResult;
        }
    }
}
