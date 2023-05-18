using System.ComponentModel.DataAnnotations;

namespace Instahach.Domain.Entities;

public class Like : BaseEntity
{
    [Required] public Image Image { get; set; }

    [Required] public User? Sender { get; set; }

    [Required] public DateTime CreatedAt { get; set; }
}