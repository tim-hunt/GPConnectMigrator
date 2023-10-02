using Dapper;
using Microsoft.Data.SqlClient;

namespace GPMigratorApp.Data;

public class ExampleTable2
{
    private readonly string _connectionString;
    
    public ExampleTable2(string connectionString)
    {
        _connectionString = connectionString;
    }
    public async Task Add(CancellationToken cancellationToken, SqlTransaction transaction)
    {
        const string insert =
            @"INSERT [dbo].[example2]
                            (
                                [Id]
                            )
   
                    VALUES
                            (
                                @Id
                            )";

        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);
        

        var insertResult = await connection.ExecuteAsync(insert, new
        {
            Id = Guid.NewGuid()
            
        }, transaction: transaction);
    }
}