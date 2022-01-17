using Darknamer.Core.Interfaces;
using Darknamer.Core.Models;
using Darknamer.Data.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Darknamer.Data.Data.Services.Dbs.Base;

public class DbIntBaseService<T> : IDbIntBaseService<T> where T : ModelIntBase
{
    private readonly IBaseRepository<T, DbContext> _repository;

    public DbIntBaseService(IBaseRepository<T, DbContext> repository)
    {
        _repository = repository;
    }
    
    public IEnumerable<T> All()
    {
        return _repository.FindAll().ToList();
    }

    public T? Insert(string username, T model)
    {
        model.CreatedAt = DateTime.Now;
        model.CreatedBy = username;
        model.UpdatedAt = DateTime.Now;
        model.UpdatedBy = username;
        _repository.Create(model);
        _repository.Save();
        return GetById(model.Id) ?? model;
    }

    public T? Update(string username, T model)
    {
        model.UpdatedAt = DateTime.Now;
        model.UpdatedBy = username;
        _repository.Update(model);
        _repository.Save();
        return GetById(model.Id) ?? model;
    }

    public void Delete(string username, T model)
    {
        _repository.Delete(model);
        _repository.Save();
    }

    public T? GetById(int id)
    {
        return _repository
            .Find(x => x.Id == id)
            .FirstOrDefault();
    }

    public void Delete(string username, int id)
    {
        var model = GetById(id);
        if (model != null)
        {
            Delete(username, model);
        }
    }
}