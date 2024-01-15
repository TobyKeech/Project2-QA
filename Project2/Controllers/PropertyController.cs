using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2.Business.DTO;
using Project2.Business.Services;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public IEnumerable<PropertyDTO> Index()
        {
            var property = _propertyService.FindAll().ToList();
            return property;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PropertyDTO> GetById(int id)
        {
            var property = _propertyService.FindById(id);
            return property == null ? NotFound() : property;
        }


        [HttpGet("Address/{address}")]
        public IQueryable<PropertyDTO> GetByName(string address)
        {
            var properties = _propertyService.FindByName(address);
            return properties;
        }























    }
}
