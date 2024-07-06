using System.ComponentModel.DataAnnotations;

namespace BankMvc.ViewModels;

public class Register{
    [Required]
    public string? Name {get;set;}

    [Required]
    [DataType(DataType.EmailAddress)]
    public string? Email {get;set;}

    [Required]
    [DataType(DataType.Password)]
    public string? Password {get;set;}

    [Compare("Password", ErrorMessage = "Password dont match")]
    public string? ConfirmPassword {get;set;}


    [DataType(DataType.MultilineText)]
    public string? Address {get;set;}
    
}