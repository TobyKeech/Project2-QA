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

        // GET api/<SellerController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

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
