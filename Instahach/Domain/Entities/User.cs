using System.ComponentModel.DataAnnotations;

namespace Instahach.Domain.Entities;

public class User : BaseEntity
{
    [Required] [MaxLength(100)] public string Email { get; set; }

    public string Name { get; set; }

    [Required] public DateTime CreatedAt { get; set; }

    public DateTime LastVisit { get; set; }
}