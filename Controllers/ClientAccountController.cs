
using System.Net.Http.Headers;
using System.Security.Permissions;
using BankMvc.Data;
using BankMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace BankMvc.Controllers
{

    public class ClientAccountController : Controller
    {
        private readonly BankDbContext _context;
        string baseUrl = "http://localhost:5155";

        public ClientAccountController(BankDbContext _context)
        {
            this._context = _context;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _context.accountClient.ToListAsync();

            return View(clients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountClient Model)
        {

            string? holderName;
            using (var client = new HttpClient())
            {
                var stringGet = $"/ClientItem/{Model.Id}";

                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

                HttpResponseMessage res = await client.GetAsync(stringGet);

                if (res.IsSuccessStatusCode)
                {
                    var EmpResponse = res.Content.ReadAsStringAsync().Result;
                    holderName = JsonConvert.DeserializeObject<Client>(EmpResponse).Name;
                    if (ModelState.IsValid)
                    {
                        AccountClient acc = new AccountClient()
                        {
                            Number = Model.Number,
                            Holder = Model.Holder,
                            Premium = Model.Premium
                        };
                        var result = _context.Add(acc);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index", "Home");
                    }
                    else return RedirectToAction("Error", "Home");
                }else return RedirectToAction("Error", "Home");
            }

            // if(ModelState.IsValid){
            //     AccountClient acc = new AccountClient(){
            //         Number = Model.Number,
            //         Holder = Model.Holder,
            //         Premium = Model.Premium
            //     };
            //     var result = _context.AddAsync(acc);
            //     if(result.IsCompletedSuccessfully)
            //     return RedirectToAction("Index", "Home");
            // }else return RedirectToAction("Error", "Home");
        }
    }
}