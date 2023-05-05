﻿using Labb_4___API.Data;
using Labb_4___API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_4___API.Services
{
    public class PersonRepository : IAppRepository<Person>
    {
        private DataContext _context;

        public PersonRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            var persons = await _context.Persons
        .Select(p => new { p.Id, p.Name, p.Phone })
        .ToListAsync();

            return persons.Select(p => new Person
            {
                Id = p.Id,
                Name = p.Name,
                Phone = p.Phone
            });


            //return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetSingle(int id)
        {
            return await _context.Persons.Include(p => p.Hobbys).FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<Person> Update(Person obj)
        {
            throw new NotImplementedException();

        }

        public Task<Person> Add(Person obj)
        {

            throw new NotImplementedException();


        }

        public Task<Person> Delete(int id)
        {
            throw new NotImplementedException();
        }








    }
}
