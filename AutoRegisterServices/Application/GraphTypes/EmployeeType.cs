using AutoRegisterServices.Application.Entities;

using GraphQL.Types;

namespace AutoRegisterServices.GraphTypes
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType()
        {
            Field(x => x.Id).Description("Id of an employee");
            Field(x => x.FirstName).Description("FirstName of an employee");
            Field(x => x.FamilyName).Description("FamilyName of an employee");
            Field(x => x.EndDateAtBench).Description("EndDateAtBench of an employee");
            Field(x => x.Skillset).Description("Skill of an employee");
            Field(x => x.StartDateAtBench).Description("StartDateAtBench of an employee");
        }
    }
}
