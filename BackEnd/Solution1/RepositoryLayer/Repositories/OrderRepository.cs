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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Order> orders;
        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
            orders = _context.Set<Order>();
        }

        public async Task<List<Order>> FindOrderByCountry(System.Linq.Expressions.Expression<Func<Order, bool>> predicate)
        {
            var data = await orders
                .Where(predicate)
                .Where(m => m.SoftDelete == false)
                .Include(x => x.City)
                .Include(x => x.City.Country)
                .ToListAsync();
            return  data;
        }

        public Task<List<Order>> GetAllByCities()
        {
            var data = orders
                .Where(m => m.SoftDelete == false)
                .Include(x => x.City)
                .ThenInclude(x => x.Country)
                .ToListAsync();

            return data;
        }
    }
}