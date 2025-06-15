using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using todolist.Areas.Identity.Data;
using todolist.Models;
namespace todolist.Data;

public class todoDbContext : IdentityDbContext<ApplicationUser>
{
    public todoDbContext(DbContextOptions<todoDbContext> options)
        : base(options)
    {

    }

    public DbSet<ToDo> ToDos { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Status> Statuses { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = "work", Name = "Work" },
            new Category { CategoryId = "home", Name = "Home" },
            new Category { CategoryId = "ex", Name = "Exercise" },
            new Category { CategoryId = "shop", Name = "Shopping" },
            new Category { CategoryId = "call", Name = "Contact" }
        );
        modelBuilder.Entity<Status>().HasData(
            new Status { StatusId = "open", Name = "Open" },
            new Status { StatusId = "closed", Name = "Completed" }
        );
    }
}
