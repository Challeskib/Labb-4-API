using Labb_4___API.Data;
using Labb_4___API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_4___API.Services
{
    public class HobbyRepository : IAppRepository<Hobby>
    {
        private DataContext _context;

        public HobbyRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<Hobby> GetSingle(int id)
        {
            return await _context.Hobbys.Include(h => h.Persons)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Hobby> Add(Hobby obj)
        {
            var result = await _context.Hobbys.AddAsync(obj);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public Task<Hobby> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Hobby>> GetAll()
        {
            throw new NotImplementedException();
        }

        

        public Task<Hobby> Update(Hobby obj)
        {
            throw new NotImplementedException();
        }
    }
}
