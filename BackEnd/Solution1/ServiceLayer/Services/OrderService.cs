using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.CityDto;
using ServiceLayer.DTOs.CountryDto;
using ServiceLayer.DTOs.OrderDto;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(OrderDto orderDto)
        {
            var model = _mapper.Map<Order>(orderDto);
            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var country = await _repository.GetAsync(id);
            await _repository.DeleteAsync(country);
        }

        public async Task<List<OrderGetDto>> GetAllAsync()
        {
            var model = await _repository.GetAllByCities();
            var res = _mapper.Map<List<OrderGetDto>>(model);
            return res;
        }

        public async Task<OrderDto> GetAsync(int id)
        {
            var model = await _repository.GetAsync(id);
            var res = _mapper.Map<OrderDto>(model);
            return res;
        }

        //public async Task<CountryDto> GetAllCountryCitiesAsync(int id)
        //{
        //    var model = await _repository.GetCountryAsync(id);
        //    var res = _mapper.Map<CountryDto>(model);
        //    return res;
        //}

        public async Task UpdateAsync(int Id, OrderEditDto orderedit)
        {
            var entity = await _repository.GetAsync(Id);

            _mapper.Map(orderedit, entity);

            await _repository.UpdateAsync(entity);
        }
        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var model = await _repository.GetAsync(id);
            var res = _mapper.Map<OrderDto>(model);
            return res;
        }

        public async Task<List<OrderGetDto>> GetByCountryIdAsync(int countryId)
        {
            var datas = await _repository.FindOrderByCountry(x => x.City.Country.Id == countryId);
            var res = _mapper.Map<List<OrderGetDto>>(datas);
            return res;

        }
     
    }
}