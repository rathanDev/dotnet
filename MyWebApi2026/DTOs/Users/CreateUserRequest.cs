using System.ComponentModel.DataAnnotations;

namespace MyWebApi2026.DTOs.Users;

public class CreateUserRequest
{

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

}
