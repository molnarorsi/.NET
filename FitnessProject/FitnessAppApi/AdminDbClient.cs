using FitnessAppApi.Api;
using FitnessAppApi.Context;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FitnessAppApi
{
    public class AdminDbClient : DbClient
    {
        private new readonly MyDbContext _context;

        public AdminDbClient(MyDbContext context) : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> AddEntity<T>(T entity) where T : class
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }

        public async Task<int> UpdateEntity<T>(int id, T updatedEntity) where T : class
        {
            try
            {
                var existingEntity = await _context.Set<T>().FindAsync(id);
                if (existingEntity == null)
                {
                    return -1;
                }
                _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }

        public async Task<List<ClientTickets>> GetClientTicketsByClientId(int id)
        {
            try
            {
                return await _context.Set<ClientTickets>().Where(it => it.ClientId == id).ToListAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<Clients> GetClientByClientId(int id)
        {
            try
            {
                return await _context.Set<Clients>().FindAsync(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<TicketTypes> GetTicketTypeByTicketTypeId(int id)
        {
            try
            {
                return await _context.Set<TicketTypes>().FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<int> DeleteEntity<T>(int id) where T : class
        {
            try
            {
                var existingEntity = await _context.Set<T>().FindAsync(id);
                if (existingEntity == null)
                {
                    return -1;
                }
                _context.Entry(existingEntity).CurrentValues.SetValues(new { isDeleted = true });
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }

        public async Task<T> GetByBarcode<T>(string barcode) where T : class
        {
            try
            {
                if (typeof(T) == typeof(ClientTickets))
                {
                    return await _context.Set<ClientTickets>().FirstOrDefaultAsync(it => it.Barcode == barcode) as T;
                }
                if (typeof(T) == typeof(Entries))
                {
                    return await _context.Set<Entries>().FirstOrDefaultAsync(it => it.Barcode == barcode) as T;
                }
                if (typeof(T) == typeof(Clients))
                {
                    return await _context.Set<Clients>().FirstOrDefaultAsync(it => it.Barcode == barcode) as T;
                }
                return null;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}