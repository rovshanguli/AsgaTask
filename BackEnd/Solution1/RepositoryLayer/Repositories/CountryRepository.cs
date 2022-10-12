using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RepositoryLayer.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Country> entities;

    
        public CountryRepository(AppDbContext context) : base(context)
        {
            _context = context;
            entities = _context.Set<Country>();
        }
        public async Task<Country> GetCountryAsync(int id)
        {
            return await entities
                .Include(c => c.Cities)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
      
    }
}
