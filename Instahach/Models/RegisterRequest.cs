using System.ComponentModel.DataAnnotations;

namespace Instahach.Models;

public class RegisterRequest
{
    [Required(ErrorMessage = "Введите имя пользователя.")]
    [MaxLength(25, ErrorMessage = "Введите имя до 25 симаолов")]
    [MinLength(5, ErrorMessage = "Введите имя от 5 симаолов")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Введите электронную почту .")]
    [EmailAddress]
    public string Email { get; set; }
}