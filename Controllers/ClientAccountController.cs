
using BankMvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankMvc.Controllers{

    public class ClientAccountController : Controller{
        private readonly BankDbContext _context;

        public ClientAccountController(BankDbContext _context){
            this._context = _context;
        }
        
        public async Task<IActionResult> Index(){
            var clients = await _context.accountClient.ToListAsync();

            return View(clients);
        }
        
    }
}