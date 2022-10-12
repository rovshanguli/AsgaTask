using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Interfaces
{
    public interface IOrderRepository : IRespository<Order>
    {
        Task<List<Order>> GetAllByCities();
        Task<List<Order>> FindOrderByCountry(Expression<Func<Order, bool>> predicate);
    }
}
