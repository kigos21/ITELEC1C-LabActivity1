using LabActivity1.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LabActivity1.ViewModels;

namespace LabActivity1.Controllers
{
  public class AccountController : Controller
  {
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
    {
      _signInManager = signInManager;
      _userManager = userManager;
    }

    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginInfo)
    {
      if (!ModelState.IsValid)
      {
        return View();
      }

      var result = await _signInManager.PasswordSignInAsync(loginInfo.UserName, loginInfo.Password, loginInfo.RememberMe, false);

      if (result.Succeeded)
      {
        return RedirectToAction("Index", "Instructor");
      }
      else
      {
        ModelState.AddModelError("", "Failed to login.");
      }

      return View();
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel registerInfo)
    {
      if (ModelState.IsValid)
      {
        User newUser = new User();
        newUser.UserName = registerInfo.UserName;
        newUser.Firstname = registerInfo.FirstName;
        newUser.Lastname = registerInfo.LastName;
        newUser.Email = registerInfo.Email;
        newUser.PhoneNumber = registerInfo.Phone;

        var result = await _userManager.CreateAsync(newUser, registerInfo.Password);

        if (result.Succeeded)
        {
          return RedirectToAction("Index", "Instructor");
        }
        else
        {
          foreach (var error in result.Errors)
          {
            ModelState.AddModelError("", error.Description);
          }
        }
      }

      return View(registerInfo);
    }

    public async Task<IActionResult> Logout()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index", "Instructor");
    }
  }
}