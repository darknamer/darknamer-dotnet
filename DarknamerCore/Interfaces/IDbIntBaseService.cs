using Darknamer.Core.Interfaces.Base;
using Darknamer.Core.Models;

namespace Darknamer.Core.Interfaces;

public interface IDbIntBaseService<T> : IDbBaseService<T> where T : ModelIntBase
{
    T? GetById(int id);
    void Delete(string username, int id);
}