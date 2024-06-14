using Bide_API.Models;
using Bide_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bide_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController: Controller {
    private readonly IGameRepo _gameRepo;

    public GameController(IGameRepo gameRepo) {
        _gameRepo = gameRepo;
    }

    [HttpGet]
    public async Task<List<Game>> GetAllGame() {
        return await _gameRepo.GetAllGameInfo();
    }
}