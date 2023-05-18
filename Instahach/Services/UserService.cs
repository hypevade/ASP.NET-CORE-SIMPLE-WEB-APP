using Instahach.Controllers;
using Instahach.Domain;
using Instahach.Domain.Entities;
using Instahach.Models;
using Microsoft.EntityFrameworkCore;

namespace Instahach.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UserService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public User? RegisterUser(RegisterRequest registerRequest)
    {
        if (_applicationDbContext.Users.Any(user => user != null && user.Email == registerRequest.Email))
            return null;
        _applicationDbContext.Users.Add(new User
        {
            /*CreatedAt = DateTime.Now,*/
            Email = registerRequest.Email,
            Id = Guid.NewGuid(),
            IsActive = true,
            //LastVisit = DateTime.Now,
            Name = registerRequest.Name
        });
        _applicationDbContext.SaveChanges();
        return _applicationDbContext.Users.First(user => user != null && user.Email == registerRequest.Email);
    }

    public bool LoginUser(LoginRequest loginRequest)
    {
        var firstOrDefault = _applicationDbContext.Users.FirstOrDefault(user => user != null && user.Email == loginRequest.Email);
        return firstOrDefault != null && firstOrDefault.Name == loginRequest.Name;
    }
}