using Microsoft.AspNetCore.Identity;

namespace BankMvc.Models;
public class Employee : IdentityUser{
    public required string Name{get;set;}
    public string Address {get;set;} = "";
    public required string password {get;set;} 
}