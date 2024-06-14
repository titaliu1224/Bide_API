using System.Data;
using System.Data.SqlClient;
using Bide_API.Models;
using Dapper;

namespace Bide_API.Repositories;

public class GameRepo : IGameRepo {
    private readonly SqlConnection _connection;

    public GameRepo(IConnectionRepo connection) {
        _connection = connection.ConnectDb();
    }

    public async Task<List<Game>> GetAllGameInfo() {
        try {
            var games = await _connection.QueryAsync<Game>("[dbo].[GetAllGameInfo_0.1]",
                commandType: CommandType.StoredProcedure);
            Console.WriteLine("try success");
            return games.ToList();
        }
        catch (Exception e) {
            Console.WriteLine("try failed");
            Console.WriteLine(e.Message);
        }

        return [];
    }
}