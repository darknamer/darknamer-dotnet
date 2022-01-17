using System.Linq.Expressions;
using Darknamer.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Darknamer.Data.Data.Repositories.Base;

public interface IBaseRepository<T, TU> where T : ModelBase where TU : DbContext
{
    TU DbContext { get; }
    IEnumerable<T> FindAll();
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    void Save();
}

public class BaseRepository<T, TU> : IBaseRepository<T, TU> where T : ModelBase where TU : DbContext
{
    public BaseRepository(TU dbContext)
    {
        DbContext = dbContext;
    }

    public TU DbContext { get; }

    public IEnumerable<T> FindAll()
    {
        return DbContext.Set<T>();
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return DbContext.Set<T>().Where(expression);
    }

    public void Create(T entity)
    {
        DbContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        DbContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        DbContext.Set<T>().Remove(entity);
    }

    public void Save()
    {
        DbContext.SaveChanges();
    }
}