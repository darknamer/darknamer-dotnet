using Darknamer.Core.Models;
using Darknamer.Data.Data.Repositories.Base;
using Darknamer.Data.Data.Repositories.MySqls.DbContexts;

namespace Darknamer.Data.Data.Repositories.MySqls;

public interface IMySqlBaseRepository<T> : IBaseRepository<T, MySqlBaseDbContext> where T: ModelBase
{
}

public class MySqlBaseRepository<T> : BaseRepository<T, MySqlBaseDbContext>, IMySqlBaseRepository<T> where T: ModelBase
{
    public MySqlBaseRepository(MySqlBaseDbContext dbContext) : base(dbContext)
    {
    }
}