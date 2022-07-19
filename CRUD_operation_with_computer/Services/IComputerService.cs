using CRUD_operation_with_computer.Data;
using CRUD_operation_with_computer.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_operation_with_computer.Services;

public interface IComputerService
{
    Task<IEnumerable<Computer?>> GetAllComputer();
    Task<Computer?> GetComputerById(int computerId);
    Task Create(Computer computer);
    Task Update(Computer computer);
    Task Delete(int computerId);
}

public class ComputerService : IComputerService
{
    private readonly AppDbContext _db;

    public ComputerService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Computer?>> GetAllComputer()
    {
        return await _db.Computers.ToListAsync();
    }

    public async Task<Computer?> GetComputerById(int computerId)
    {
        return await _db.Computers.FirstOrDefaultAsync(c => c!.Id == computerId);
    }

    public async Task Create(Computer computer)
    {
        await _db.Computers.AddAsync(computer);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Computer computer)
    {
        _db.Computers.Update(computer);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(int computerId)
    {
        _db.Computers.Remove(new Computer { Id = computerId });
        await _db.SaveChangesAsync();
    }
}