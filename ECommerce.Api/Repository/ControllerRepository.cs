using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using EShop.Business.Repositories;
using EShop.Core.Exceptions;
using EShop.Core.Signatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Api.Repository
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerRepository<TService,TDto> : ControllerBase
    where TDto:class,IBaseDto, new()
    where TService:IServiceRepository<TDto>
    {
        private readonly TService _service;

        public ControllerRepository(TService service)
        {
            _service = service;
        }
        
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var data =await _service.GetAsync(id);
            if (data == null) throw new NotFoundException(typeof(TDto).Name+" is Not found");
            return Ok(data);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Create([FromBody] TDto dto)
        {
            var id = await _service.InsertAsync(dto);
            return CreatedAtAction(null, id);
        }
        
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> Update([FromRoute] int id,[FromBody] TDto dto)
        {
            await _service.UpdateAsync(id,dto);
            return StatusCode(204);
        }
        
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return StatusCode(204);
        }
        
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromQuery, Required] List<int> listOfId)
        {
            await _service.DeleteRangeAsync(listOfId);
            return StatusCode(204);
        }
        
        [HttpPost("RemoveCache")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public virtual async Task<IActionResult> RemoveCache()
        {
            await _service.RemoveCacheAsync();
            return StatusCode(204);
        }
    }
}