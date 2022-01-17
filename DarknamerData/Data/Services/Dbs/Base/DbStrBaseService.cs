using Darknamer.Core.Interfaces;
using Darknamer.Core.Models;
using Darknamer.Data.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Darknamer.Data.Data.Services.Dbs.Base;

public class DbStrBaseService<T, TU> : IDbStrBaseService<T> where T : ModelStrBase where TU: DbContext
{
    private readonly IBaseRepository<T, TU> _repository;

    public DbStrBaseService(IBaseRepository<T, TU> repository)
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

    public T? GetById(string id)
    {
        return _repository
            .Find(x => x.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase))
            .FirstOrDefault();
    }

    public void Delete(string username, string id)
    {
        var model = GetById(id);
        if (model != null)
        {
            Delete(username, model);
        }
    }
}