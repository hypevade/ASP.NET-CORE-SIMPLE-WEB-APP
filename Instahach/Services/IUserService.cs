using Instahach.Controllers;
using Instahach.Domain.Entities;
using Instahach.Models;

namespace Instahach.Services;

public interface IUserService
{
    public User? RegisterUser(RegisterRequest registerRequest);
    public bool LoginUser(LoginRequest loginRequest);
}