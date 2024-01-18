using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2.Business.DTO;
using Project2.Business.Services;
using System.Net;

namespace Project2.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        //Get all properties
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<PropertyDTO> Index()
        {
            var property = _propertyService.FindAll().ToList();
            return property;
        }

        //Get property by id
        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PropertyDTO> GetById(int id)
        {
            var property = _propertyService.FindById(id);
            return property == null ? NotFound() : property;
        }

        //Get property by address
        [AllowAnonymous]
        [HttpGet("Address/{address}")]
        public IQueryable<PropertyDTO> GetByName(string address)
        {
            var properties = _propertyService.FindByName(address);
            return properties;
        }

        //Add property
        [HttpPost()]
        public PropertyDTO AddProperty(PropertyDTO property)
        {
            property = _propertyService.Create(property);
            //_propertyService.Save();
            return property;
        }


        // UPDATE: Property
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PropertyDTO> UpdateProperty(PropertyDTO property)
        {

            property = _propertyService.Update(property);
            // _propertyService.Save();
            return property;
        }

        //Delete property via id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public HttpStatusCode DeleteProperty(int id)
        {
            var property = _propertyService.FindById(id);
            if (property == null)
                return HttpStatusCode.NotFound;
            _propertyService.Delete(property);
            // _propertyService();
            return HttpStatusCode.NoContent;
        }
















    }
}
