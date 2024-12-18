using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{
    private const string ConnectionString = "Server=localhost; Port=5432; Database=test;User Id=postgres; Password=1234";


    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(ConnectionString);
    }
    
}