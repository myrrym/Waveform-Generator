using Microsoft.Extensions.Configuration;

public class DatabaseManager
{
    private readonly IConfiguration _configuration;

    public DatabaseManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetConnectionString()
    {
        return _configuration.GetConnectionString("MyDatabaseConnection");
    }
}
