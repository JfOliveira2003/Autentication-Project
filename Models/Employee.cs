namespace BankMvc.Models;
public class Employee : IdentityUser{
    public required string Name{get;set;}
    public required string password {get;set;} 
}