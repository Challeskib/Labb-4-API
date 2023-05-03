using Labb_4___API.Data;
using Labb_4___API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_4___API.Services
{

    public class LinkRepository : IAppRepository<Link>
    {
        private readonly DataContext _dataContext;
        public LinkRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<IEnumerable<Link>> GetAll()
        {
            return await _dataContext.Links.ToListAsync();
        }

        public async Task<Link> GetSingle(int id)
        {
            return await _dataContext.Links.Include(l => l.PersonId)
                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Link> Add(Link obj)
        {
            return await _dataContext.Add(obj);
        }

        public Task<Link> Delete(int id)
        {
            throw new NotImplementedException();
        }


        public Task<Link> Update(Link obj)
        {
            throw new NotImplementedException();
        }
    }
}
