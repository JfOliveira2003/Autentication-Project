namespace BankMvc.Models;
public class AccountClient{
    public int? Id {get;set;}
    public required string Number{get;set;}
    public required string Holder {get;set;}

    public bool Premium {get;set;}
}