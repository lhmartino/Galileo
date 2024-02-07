using Dapper;
using GalileoAPI.Endpoints.Employees;
using Microsoft.Data.SqlClient;

namespace GalileoAPI.Infra.Data;

public class QueryAllUsersWithClaimName
{
    private readonly IConfiguration configuration;

    public QueryAllUsersWithClaimName(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public IEnumerable<EmployeeResponse> Execute(int page, int rows)
    {
        //TODO: validar page e rows

        var db = new SqlConnection(configuration["ConnectionStrings:Galileo"]);
        var query = @"select Email, ClaimValue as Name
            from AspNetUsers as u
            inner join AspNetUserClaims as c on
	            c.UserId = u.Id
	            and ClaimType = 'Name'
            order by Name
            OFFSET (@page-1) * @rows ROWS FETCH NEXT @rows ROWS ONLY";
        return db.Query<EmployeeResponse>(
            query,
            new { page, rows }
        );
    }
}
