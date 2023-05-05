using Labb_4___API.Data;
using Labb_4___API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_4___API.Services
{

    public class LinkRepository : IAppRepository<Link>
    {
        private readonly DataContext _context;
        public LinkRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        

        public async Task<IEnumerable<Link>> GetAll()
        {
            return await _context.Links.ToListAsync();
        }

        public async Task<Link> GetSingle(int id)
        {
            return await _context.Links.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Link> Add(Link obj)
        {
            var result = await _context.Links.AddAsync(obj);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        //public async Task<CreateLinkDto> Add(CreateLinkDto request)
        //{
        //    var person = await _context.Persons.FindAsync(request.PersonId);

        //    var newLink = new Link
        //    {
        //        Url = request.Url,
        //        HobbyId = request.HobbyId,
        //        Person = person
        //    };
        //    _context.Links.Add(newLink);
        //    await _context.SaveChangesAsync();

        //    return newLink;




        //}

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
