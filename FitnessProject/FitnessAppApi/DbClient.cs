using FitnessAppApi.Context;
using Microsoft.EntityFrameworkCore;

namespace FitnessAppApi
{
    public class DbClient : IDisposable
    {
        protected readonly MyDbContext _context;

        public DbClient(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<T>> GetTable<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
