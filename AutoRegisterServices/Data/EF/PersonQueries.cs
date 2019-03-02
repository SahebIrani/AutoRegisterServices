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
    public class PersonQueries : IPersonQueries
    {
        private readonly Context Context;
        private readonly IResultConverter RsultConverter;

        public PersonQueries(Context context, IResultConverter resultConverter)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            RsultConverter = resultConverter ?? throw new ArgumentNullException(nameof(resultConverter));
        }
        public async Task<PersonResult> GetPersonAsync(Guid id, CancellationToken cancellationToken = default)
        {
            //Person person = await Context.People.FindAsync(id, cancellationToken);
            Person person = await Context.People.SingleOrDefaultAsync(c => c.PersonId == id, cancellationToken);

            if (person == null)
                throw new SqlNullValueException($"The person {id} does not exists or is not processed yet ..");

            PersonResult personResult = RsultConverter.Map<PersonResult>(person);
            return personResult;
        }
    }
}
