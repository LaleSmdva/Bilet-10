using DataAccess.Contexts;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Implementations;

public class Repository<T> : IRepository<T> where T:class,new()
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> _table => _context.Set<T>();

    public IEnumerable<T> GetAll()
    {
        return _table.AsEnumerable();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _table.FindAsync(id);
    }

    public async Task CreateAsync(T model)
    {
        await _table.AddAsync(model);
    }

    
    public void Update(T entity)
    {
        _table.Update(entity);
    }
    public void Delete(T entity)
    {
        _table.Remove(entity);
    }


    public async Task SaveAsync()
    {
       await _context.SaveChangesAsync();
    }

  
}
