namespace Darknamer.Core.Interfaces.Base;

public interface IDbBaseService<T>
{
    IEnumerable<T> All();
    T? Insert(string username, T model);
    T? Update(string username, T model);
    void Delete(string username, T model);
}