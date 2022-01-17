using Darknamer.Core.Interfaces.Base;
using Darknamer.Core.Models;

namespace Darknamer.Core.Interfaces;

public interface IDbStrBaseService<T> : IDbBaseService<T> where T : ModelStrBase
{
    T? GetById(string id);
    void Delete(string username, string id);
}