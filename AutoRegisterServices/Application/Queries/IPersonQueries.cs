using AutoRegisterServices.Application.Results;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace AutoRegisterServices.Application.Queries
{
    public interface IPersonQueries
    {
        Task<PersonResult> GetPersonAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
