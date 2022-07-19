using CRUD_operation_with_computer.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_operation_with_computer.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Computer> Computers { get; set; }
}