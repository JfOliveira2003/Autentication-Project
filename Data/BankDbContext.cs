using System.ComponentModel;
using BankMvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace BankMvc.Data;

public class BankDbContext : IdentityDbContext<Employee>{

    public BankDbContext(DbContextOptions options) : base(options) {}
    public DbSet<Employee> employee => Set<Employee>();
    public DbSet<AccountClient> accountClient => Set<AccountClient>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;port=3306;database=Banco02;user=root;password=Fabricio123;", ServerVersion.AutoDetect("server=localhost;port=3306;database=Banco02;user=root;password=Fabricio123;"));
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var admin = new IdentityRole("admin");
        admin.NormalizedName = "admin";

        var employee = new IdentityRole("employee");
        employee.NormalizedName = "employee";

        builder.Entity<IdentityRole>().HasData(admin, employee);
    }
}