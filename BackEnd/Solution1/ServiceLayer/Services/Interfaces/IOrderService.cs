using ServiceLayer.DTOs.CityDto;
using ServiceLayer.DTOs.CountryDto;
using ServiceLayer.DTOs.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(OrderDto orderDto);

        Task UpdateAsync(int Id, OrderEditDto orderEditDto);
        Task DeleteAsync(int id);
        Task<List<OrderGetDto>> GetAllAsync();
        Task<OrderDto> GetAsync(int id);
        Task<OrderDto> GetByIdAsync(int id);

        Task<List<OrderGetDto>> GetByCountryIdAsync(int countryId);


     

    }
}
