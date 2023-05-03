using Labb_4___API.Data;
using Labb_4___API.Models;

namespace Labb_4___API.Services
{
    public class HobbyRepository : IAppRepository<Hobby>
    {
        private DataContext _context;

        public HobbyRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public Task<Hobby> GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Hobby> Add(Hobby obj)
        {
            throw new NotImplementedException();
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
