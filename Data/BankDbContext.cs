using System.ComponentModel;
using BankMvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace BankMvc.Data;

public class BankDbContext : IdentityDbContext<Employee>{
    public DbSet<Employee> employee => Set<Employee>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;port=3306;database=Banco02;user=root;password=Fabricio123;", ServerVersion.AutoDetect("server=localhost;port=3306;database=Banco02;user=root;password=Fabricio123;"));
    }
}