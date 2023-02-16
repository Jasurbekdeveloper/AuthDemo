using AuthDemo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AuthDemo.Infrastructure.Repositories;

public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity , Guid> 
    where TEntity : class
{
    private readonly AuthDbContext authDbContext;

    public GenericRepository(AuthDbContext authDbContext)
    {
        this.authDbContext = authDbContext;
    }

    public async ValueTask<TEntity> DeleteAsync(TEntity entity)
    {
        var entityEntry = this.authDbContext
            .Set<TEntity>()
            .Remove(entity);
        await this.authDbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<TEntity> InsertAsync(TEntity entity)
    {
        var entityEntry = this.authDbContext
            .Set<TEntity>().Add(entity);

        await this.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async ValueTask<int> SaveChangesAsync()
    {
         return await this.authDbContext.SaveChangesAsync();
    }

    public IQueryable<TEntity> SelectAll()
    {
        return this.authDbContext.Set<TEntity>();
    }

    public async ValueTask<TEntity> SelectByIdAsync(Guid id)
    {
        var entityEntry = await this.authDbContext
            .Set<TEntity>().FindAsync(id);

        return entityEntry;
    }

    public async ValueTask<TEntity> SelectByIdWithDetailsAsync(Expression<Func<TEntity,
        bool>> expression, string[] includes)
    {
        IQueryable<TEntity> entities = this.SelectAll();

        foreach(var include in includes)
        {
            entities = entities.Include(include);
        }

        return await entities.FirstOrDefaultAsync(expression);
    }

    public async ValueTask<TEntity> UpdateAsync(TEntity entity)
    {
        var entryEntity = this.authDbContext
            .Set<TEntity>().Update(entity);

        await this.authDbContext.SaveChangesAsync();
        return entryEntity.Entity;
    }
}
