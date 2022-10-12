using ApiMymall.Controllers;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.CityDto;
using ServiceLayer.DTOs.OrderDto;
using ServiceLayer.Services.Interfaces;

namespace EMobileApi.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> Create([FromBody] OrderDto orderDto)
        {
            await _service.CreateAsync(orderDto);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteOrder/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<IActionResult> Update([FromBody] OrderEditDto orderEditDto)
        {


            await _service.UpdateAsync(orderEditDto.Id, orderEditDto);
            return Ok();
        }


        [HttpGet]
        [Route("GetAllOrder")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetByCountryId/{countryId}")]
        public async Task<IActionResult> GetByCountryId([FromRoute] int countryId)
        {
            var result = await _service.GetByCountryIdAsync(countryId);
            return Ok(result);
        }

        //[HttpGet]
        //[Route("GetByCateId/{id}")]
        //public async Task<IActionResult> GetByCateId([FromRoute] int id)
        //{
        //    var result = await _service.GetByCateId(id);
        //    return Ok(result);
        //}
        //[HttpGet]
        //[Route("GetAllByName/{txt}")]
        //public async Task<IActionResult> GetAllByName([FromRoute] string txt)
        //{
        //    return Ok(await _service.GetAllNameAsync(txt));
        //}

    }
}
