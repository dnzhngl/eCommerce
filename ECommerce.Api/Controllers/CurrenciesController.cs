using System.Threading.Tasks;
using ECommerce.Api.Repository;
using ECommerce.Business.Abstract;
using ECommerce.Business.Model;
using ECommerce.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    public class CurrenciesController : ControllerRepository<ICurrencyService, CurrencyDto>
    {
        private readonly ICurrencyService _service;
        public CurrenciesController(ICurrencyService service) : base(service)
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
    }
}
