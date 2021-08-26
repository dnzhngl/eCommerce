using System.Threading.Tasks;
using ECommerce.Api.Repository;
using ECommerce.Business.Abstract;
using ECommerce.Business.Model;
using ECommerce.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    public class ProductsController : ControllerRepository<IProductService, ProductDto>
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service) : base(service)
        {
            _service = service;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAll([FromQuery]Filter filter)
        {
            var data =await _service.GetAllAsync(filter);
            return Ok(data);
        }
        
        [HttpGet("{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllByCategoryAsync([FromQuery]Filter filter, int categoryId)
        {
            var data =await _service.GetAllByCategoryAsync(filter, categoryId);
            return Ok(data);
        }
    }
}