using System.Data.SqlClient;

namespace Bide_API.Repositories;

public class ConnectionRepo : IConnectionRepo {
    private readonly SqlConnection _connection;

    public ConnectionRepo(IConfiguration config) {
        _connection = new SqlConnection(config.GetConnectionString("LocalConnection"));
    }

    public SqlConnection ConnectDb() {
        return _connection;
    }
}