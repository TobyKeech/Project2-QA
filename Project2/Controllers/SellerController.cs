using Microsoft.AspNetCore.Mvc;
using Project2.Business.DTO;
using Project2.Business.Services;
using System.Net;


namespace Project2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellerController : ControllerBase
    {
        private ISellerService _sellerService;

        public SellerController(ISellerService service)
        {
            _sellerService = service;
        }


        // GET: api/<SellerController>
        [HttpGet]
        public IEnumerable<SellerDTO> Index()
        {
            var seller = _sellerService.FindAll().ToList();
            return seller;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SellerDTO> GetById(int id)
        {
            var seller = _sellerService.FindById(id);
            return seller == null ? NotFound() : seller;
        }

        // POST api/<SellerController>
        /*[HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SellerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SellerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
