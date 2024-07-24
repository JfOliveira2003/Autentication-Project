
using System.ComponentModel.DataAnnotations;

namespace BankMvc.Models;

public class Client{
    public int Id {get;set;}
    [Required]
    public string? Name{get;set;}

    [DataType(DataType.Date)]
    public DateOnly Age {get;set;}


    [Required]
    public string? Cpf {get;set;}

}