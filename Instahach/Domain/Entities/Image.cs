using System.ComponentModel.DataAnnotations;

namespace Instahach.Domain.Entities;

public class Image : BaseEntity
{
    [Required] public string Path { get; set; }

    public User Sender { get; set; }
}