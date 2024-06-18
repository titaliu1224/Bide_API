using System.ComponentModel.DataAnnotations;

namespace Bide_API.Models;

public class Game {
    [Key] public string userId { get; set; }
    [Key] public DateTime completeDate { get; set; }
    public int mode { get; set; }
    public int score { get; set; }
    public int gameTime { get; set; }
}