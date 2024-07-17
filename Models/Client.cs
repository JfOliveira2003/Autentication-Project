using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace BankMvc.Models;
public class Client{
    public int? Id {get;set;}
   
    public string? Name {get;set;}

    [DataType(DataType.Date)]
    public DateTime Age {get;set;} 
}