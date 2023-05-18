using Microsoft.AspNetCore.Identity;

namespace Instahach.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public DateTime LastVisit { get; set; }
}