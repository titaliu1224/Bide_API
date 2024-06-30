using System.Data;
using System.Data.SqlClient;
using Bide_API.Models;
using Dapper;

namespace Bide_API.Repositories;

public class UserRepo: IUserRepo {
    private readonly SqlConnection _connection;

    public UserRepo(IConnectionRepo connection) {
        _connection = connection.ConnectDb();
    }
    
    public async Task<IEnumerable<User>> GetUserInfo(string userId) {
        try {
            var userInfo = await _connection.QueryAsync<User>("[dbo].[GetUserInfo_0.1]", new{userId},
                commandType: CommandType.StoredProcedure);
            return userInfo;
        }
        catch {
            // TODO: handle exceptions
            throw;
        }
    }

    public async Task CreateUser(User user) {
        try {
            await _connection.QueryAsync("[dbo].[CreateUser_0.1]", user, commandType: CommandType.StoredProcedure);
        }
        catch {
            // TODO: handle exceptions
            throw;
        }
    }
}