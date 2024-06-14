using System.ComponentModel.DataAnnotations;

namespace Bide_API.Models;

public class User {
    [Key]public string userId { get; set; }
    public string password { get; set; }
    public string userName { get; set; }
}