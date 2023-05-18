using System.ComponentModel.DataAnnotations;

namespace Instahach.Domain.Entities;

public abstract class BaseEntity
{
    [Key] public Guid Id { get; set; }

    public bool IsActive { get; set; }
}