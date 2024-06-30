using System.ComponentModel.DataAnnotations;

namespace Bide_API.Models;

public class User {
    [Key]public string userId { get; set; }
    public string password { get; set; }
    public string userName { get; set; }
}

// Q: 這個應該要放在 Model 裡面，還是分別放在 controller 和 service 中？
public class LoginInfo {
    public string userId { get; set; }
    public string userName { get; set; }
    public string message { get; set; }
}