using BankMvc.Models;
using BankMvc.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace BankMvc.Controllers{


    public class AccountController : Controller{
        private readonly SignInManager<Employee> signInManager;
        private readonly UserManager<Employee> userManager;

        public AccountController(SignInManager<Employee> signInManager, UserManager<Employee> userManager){
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginVm model){
            if(ModelState.IsValid){

                var result = await signInManager.PasswordSignInAsync(model.Username!,model.Password!, model.RememberMe, false);

                if(result.Succeeded){
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login");
                return View(model);
            }
            return View(model);
        }
        public IActionResult Register(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(Register model){
            if(ModelState.IsValid){
                Employee user = new Employee(){
                    Name = model.Name,
                    Address = model.Address

                };
                var result = await userManager.CreateAsync(user, model.Password);

                if(result.Succeeded){
                    await signInManager.SignInAsync(user, false);

                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
            }
            return View(model);
        }
    }
}