using Azure.Identity;

namespace Bide_API.Models;

public class GameInfo {
    public string userName { get; set; }
    public DateTime completeDate { get; set; }
    public int mode { get; set; }
    public int number { get; set; }
    public int score { get; set; }
    public int gameTime { get; set; }
}