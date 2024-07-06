using System.ComponentModel.DataAnnotations;

namespace BankMvc.ViewModels;
public class LoginVm{
    [Required(ErrorMessage = "Username is required my friend!")]
    public string? Username {get;set;}

    [Required(ErrorMessage = "Password is required my friend!")]
    [DataType(DataType.Password)]
    public string? Password {get;set;}
    public bool RememberMe {get;set;}
}