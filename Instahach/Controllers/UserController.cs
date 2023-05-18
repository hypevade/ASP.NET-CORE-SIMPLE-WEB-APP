using Instahach.Models;
using Instahach.Services;
using Microsoft.AspNetCore.Mvc;

namespace Instahach.Controllers;

[Route("users")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]

    public IActionResult Register()
    {
        var model = new RegisterRequest();
        return View(model);
    }
    
    [HttpPost]
    public IActionResult Register(RegisterRequest model)
    {
        if (ModelState.IsValid)
        {
            // Выполните здесь логику регистрации пользователя
            // Можно сохранить данные из модели в базе данных или выполнить другие необходимые действия
            _userService.RegisterUser(model);
            return RedirectToAction("Login");
        }
        
        return View(model);
    }
    
    [HttpGet]
    [Route("login")]
    
    public IActionResult Login()
    {
        var model = new LoginRequest();
        return View(model);
    }
    
    [HttpPost]
    [Route("login")]
    public IActionResult Login(LoginRequest model)
    {
        if (ModelState.IsValid)
        {
            // Выполните здесь логику регистрации пользователя
            // Можно сохранить данные из модели в базе данных или выполнить другие необходимые действия
            if(_userService.LoginUser(model)) 
                return RedirectToAction("GetImages","ImageControllers");
        }
        
        return View(model);
    }
    
    [HttpGet]
    [Route("registerSuccess")]
    public IActionResult RegistrationSuccess()
    {
        return View();
    }
}