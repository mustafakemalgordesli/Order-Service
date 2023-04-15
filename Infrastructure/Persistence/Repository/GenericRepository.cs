using Application.Interfaces.Repository;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext dbContext;
    public GenericRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public virtual List<T> FindAllByCondition(Expression<Func<T, bool>> expression)
    {
        return dbContext.Set<T>()
            .Where(expression).AsNoTracking().ToList();
    }

    public void Update(T entity)
    {
        dbContext.Set<T>().Update(entity);
    }
    public void Delete(T entity)
    {
        dbContext.Set<T>().Remove(entity);
    }

    public async Task AddAsync(T entity)
    {
        await dbContext.Set<T>().AddAsync(entity);
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await dbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await dbContext.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
    }
}
