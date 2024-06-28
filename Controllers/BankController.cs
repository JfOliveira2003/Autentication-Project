using BankMvc.Data;
using Microsoft.AspNetCore.Mvc;

namespace BankMvc.Controllers;

public class BankController : Controller{
    private readonly BankDbContext?  _bankDbContext = null;

    public IActionResult Index(){
        return View();
    }

    [HttpPost]
    public IActionResult Login(BankDbContext session)
    {
        
        return View();
    }
}