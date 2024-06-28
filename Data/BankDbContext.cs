using System.ComponentModel;
using BankMvc.Models;
using Microsoft.EntityFrameworkCore;
namespace BankMvc.Data;

public class BankDbContext : DbContext{
    public DbSet<Employee> employee => Set<Employee>();
    public DbSet<Account> account => Set<Account>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;port=3306;database=Banco02;user=root;password=Fabricio123;", ServerVersion.AutoDetect("server=localhost;port=3306;database=Banco02;user=root;password=Fabricio123;"));
    }
}