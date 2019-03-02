using AutoRegisterServices.Application.Results;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace AutoRegisterServices.Application.Queries
{
    public interface ICustomerQueries
    {
        Task<CustomerResult> GetCustomerAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
