using Instahach.Domain.Entities;
using Instahach.Models;

namespace Instahach.Services;

class MockUserService : IUserService
{
    public User? RegisterUser(RegisterRequest registerRequest)
    {
        return new User()
        {
            Email = registerRequest.Email,
            Name = registerRequest.Name
        };
    }

    public bool LoginUser(LoginRequest registerRequest)
    {
        throw new NotImplementedException();
    }
}