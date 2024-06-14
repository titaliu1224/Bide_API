using System.Data.SqlClient;

namespace Bide_API.Repositories;

public interface IConnectionRepo {
    public SqlConnection ConnectDb();
}