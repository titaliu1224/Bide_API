using Bide_API.Models;

namespace Bide_API.Repositories;

public interface IGameRepo {
    public Task<List<Game>> GetAllGameInfo();
    public Task<bool> SaveGameResult(Game game);
}