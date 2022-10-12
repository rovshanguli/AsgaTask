using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<City> _cities;
        public CityRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _cities = _context.Set<City>();
        }
        
        public async Task<List<City>> GetCitiesByCountryId(int countryId)
        {
            var data = await _cities.Where(x => x.Country.Id == countryId).ToListAsync();
            return data;
        }
    }
}