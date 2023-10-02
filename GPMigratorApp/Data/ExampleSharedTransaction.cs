using Dapper;
using GPConnect.Provider.AcceptanceTests.Logger;
using Microsoft.Data.SqlClient;

namespace GPMigratorApp.Data;


public class ExampleSharedTransaction
{
    private readonly string _connectionString;
    private readonly ExampleTable _exampleTable;
    private readonly ExampleTable2 _exampleTable2;
    
    public ExampleSharedTransaction(string connectionString,ExampleTable exampleTable, ExampleTable2 exampleTable2)
    {
        _connectionString = connectionString;
        _exampleTable = exampleTable;
        _exampleTable2 = exampleTable2;
    }
    
    public async Task AddNewEntry(CancellationToken cancellationToken)
    {
        await using var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(cancellationToken);

        await using var transaction = connection.BeginTransaction();

        try
        {
            await _exampleTable.Add(cancellationToken, transaction);
            await _exampleTable2.Add(cancellationToken, transaction);
            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            Log.WriteLine(ex.Message);
        }

    }
}