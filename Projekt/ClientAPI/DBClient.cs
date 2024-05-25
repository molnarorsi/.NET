using ClientAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI
{
    public class DBClient : IDisposable
    {
        protected readonly MyDBContext _dbcontext;

        public DBClient(MyDBContext context)
        {
            _dbcontext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<T>> GetTable<T>() where T : class
        {
            
            return await _dbcontext.Set<T>().ToListAsync();
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}
