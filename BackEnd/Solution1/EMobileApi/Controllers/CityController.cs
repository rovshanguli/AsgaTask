using ApiMymall.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.CityDto;
using ServiceLayer.Services.Interfaces;
using System.Data;

namespace EMobileApi.Controllers
{
    public class CityController : BaseController
    {
        private readonly ICityService _service;
        public CityController(ICityService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreateCity")]
        public async Task<IActionResult> Create([FromBody] CityDto cityDto)
        {
            await _service.CreateAsync(cityDto);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteCity/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateCity")]
        public async Task<IActionResult> Update([FromBody] CityEditDto cityEditDto)
        {


            await _service.UpdateAsync(cityEditDto.Id, cityEditDto);
            return Ok();
        }


        [HttpGet]
        [Route("GetAllCity")]
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

        //[HttpGet]
        //[Route("GetByCateId/{id}")]
        //public async Task<IActionResult> GetByCateId([FromRoute] int id)
        //{
        //    var result = await _service.GetByCateId(id);
        //    return Ok(result);
        //}
        [HttpGet]
        [Route("GetAllByName/{txt}")]
        public async Task<IActionResult> GetAllByName([FromRoute] string txt)
        {
            return Ok(await _service.GetAllNameAsync(txt));
        }

        //get all citis by country id
        [HttpGet]
        [Route("GetAllByCountryId/{id}")]
        public async Task<IActionResult> GetAllByCountryId([FromRoute] int id)
        {
            return Ok(await _service.GetAllCountryIdAsync(id));
        }
    }
}
