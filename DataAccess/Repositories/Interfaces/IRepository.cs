using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces;

public interface IRepository<T> where T : class,new()
{
    IEnumerable<T> GetAll();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T model);
    void Update(T entity);
    void Delete(T entity);
    Task SaveAsync();
    public DbSet<T> _table { get; }

}
