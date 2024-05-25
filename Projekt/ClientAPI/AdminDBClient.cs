using ClientAPI.API;
using ClientAPI.Context;
using Microsoft.EntityFrameworkCore;
using static ClientAPI.API.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ClientAPI
{
    public class AdminDBClient : DBClient
    {
        private new readonly MyDBContext _dbContext;
        public AdminDBClient(MyDBContext dbContext) : base(dbContext) { 
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<int> AddEntity<T>(T entity) where T : class
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
                await _dbContext.SaveChangesAsync();
                return 1;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }

        public async Task<int> UpdateEntity<T>(int ID, T updatedEntity) where T : class
        {
            try
            {
                var existingEntity = await _dbcontext.Set<T>().FindAsync(ID);
                if(existingEntity == null)
                {
                    return -1;
                }
                _dbcontext.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
                await _dbcontext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }

        public async Task<List<ClientMemberships>> GetClientMembershipsByClientID(int ID)
        {
            try
            {
                return await _dbContext.Set<ClientMemberships>().Where(x => x.clientID == ID).ToListAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<Clients> GetClientByID(int ID)
        {
            try
            {
                return await _dbContext.Set<Clients>().FindAsync(ID);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<Memberships> GetMembershipsByID(int ID)
        {
            try
            {
                return await _dbContext.Set<Memberships>().FindAsync(ID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<T?> GetMembershipByBarcode<T>(string barcode) where T : class
        {
            try
            {
                if(typeof(T) == typeof(ClientMemberships))
                {
                    return await _dbContext.Set<ClientMemberships>().FirstOrDefaultAsync(x => x.barcode == barcode) as T;
                }
                if(typeof(T) == typeof(Entries))
                {
                    return await _dbContext.Set<Entries>().FirstOrDefaultAsync(x => x.barcode == barcode) as T;
                }
                if(typeof(T) == typeof(Clients))
                {
                    return await _dbContext.Set<Clients>().FirstOrDefaultAsync(x => x.barcode == barcode) as T;
                }
                return null;
            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<int> DeleteEntity<T>(int ID) where T : class
        {
            try
            {
                var existingEntity = await _dbContext.Set<T>().FindAsync(ID);
                if (existingEntity == null)
                {
                    return -1;
                }
                _dbContext.Entry(existingEntity).CurrentValues.SetValues(new { isDeleted = true });
                await _dbContext.SaveChangesAsync();
                return 1;
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return -1;
            }
        }

    }
}
