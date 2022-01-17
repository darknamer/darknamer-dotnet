using Darknamer.Core.Models;
using Darknamer.Data.Data.Repositories.Base;
using Darknamer.Data.Data.Repositories.SqlServers.DbContexts;

namespace Darknamer.Data.Data.Repositories.SqlServers;

public interface ISqlServerBaseRepository<T> : IBaseRepository<T, SqlServerBaseDbContext> where T: ModelBase
{
}

public class SqlServerBaseRepository<T> : BaseRepository<T, SqlServerBaseDbContext>, ISqlServerBaseRepository<T> where T : ModelBase
{
    public SqlServerBaseRepository(SqlServerBaseDbContext dbContext) : base(dbContext)
    {
    }
}