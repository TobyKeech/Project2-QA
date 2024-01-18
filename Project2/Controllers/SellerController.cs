using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project2.Business.DTO;
using Project2.Business.Services;
using System.Net;


namespace Project2.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<SellerDTO> Index()
        {
            var seller = _sellerService.FindAll().ToList();
            return seller;
        }

        //Find seller by Id
        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SellerDTO> GetById(int id)
        {
            var seller = _sellerService.FindById(id);
            return seller == null ? NotFound() : seller;
        }

        //Find by name
        [AllowAnonymous]
        [HttpGet("Seller/{name}")]
        public IQueryable<SellerDTO> GetByName(string name)
        {
            var seller = _sellerService.FindByName(name);
            return seller; 
                //== null ? NotFound() : seller;
        }

        // POST api/<SellerController>
        //Create Seller
        [HttpPost()]
        public SellerDTO AddSeller(SellerDTO seller)
        {
            seller = _sellerService.Create(seller);
            //_sellerService.Save();
            return seller;
        }

        //Update Seller
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SellerDTO> UpdateSeller(SellerDTO seller)
        {

            seller = _sellerService.Update(seller);
            return seller;
        }

        //Selete Seller
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public HttpStatusCode DeleteSeller(int id)
        {
            var seller = _sellerService.FindById(id);
            if (seller == null)
                return HttpStatusCode.NotFound;

            _sellerService.Delete(seller);
            //_sellerService.Save();
            return HttpStatusCode.NoContent;
        }
    }
}
