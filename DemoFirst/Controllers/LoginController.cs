using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectDemo1.Migrations;

namespace ProjectDemo1.Controllers;

[Route("api/")]
[ApiController]
public class LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    : Controller
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var user = new AppUser { UserName = model.Username, Email = model.Email };
        var result = await userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            return Ok(new { Result = "Registration successful" });
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

        if (result.Succeeded)
        {
            return Ok(new { Result = "Login successful" });
        }

        return Unauthorized();
    }
}

public class RegisterModel(string username, string email, string password)
{
    public string Username { get; set; } = username;
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
}

public class LoginModel(string username, string password)
{
    public string Username { get; set; } = username;
    public string Password { get; set; } = password;
}