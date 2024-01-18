using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2.Business.DTO;
using Project2.Business.Services;
using Project2.EF;
using System.Net;

namespace Project2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private  IBuyerService _buyerService;

        public BuyerController(IBuyerService service) 
        {
            _buyerService = service; 
        }

        [HttpGet]
        public IEnumerable<BuyerDTO> Index()
        {
            var buyers = _buyerService.FindAll().ToList();
            return buyers;
        }

        // GET: Buyer/2
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BuyerDTO> GetById(int id)
        {
            var buyer = _buyerService.FindById(id);
            return buyer == null ? NotFound() : buyer;
        }

        // GET: Buyer/Name/ET
        [HttpGet("Name/{title}")]
        public IQueryable<BuyerDTO> GetByName(string title)
        {
            var buyer = _buyerService.FindByName(title);
            return buyer;
        }

        // POST: buyer
        [HttpPost()]
        public BuyerDTO AddBuyer(BuyerDTO buyer)
        {
            buyer = _buyerService.Create(buyer);
            //_genreService.Save();
            return buyer;
        }

        // UPDATE: Buyer
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BuyerDTO> UpdateBuyer(BuyerDTO buyer)
        {

            buyer = _buyerService.Update(buyer);
            // _genreService.Save();
            return buyer;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public HttpStatusCode DeleteBuyer(int id)
        {
            var buyer = _buyerService.FindById(id);
            if (buyer == null)
                return HttpStatusCode.NotFound;
            _buyerService.Delete(buyer);
            //_movieService.Save();
            return HttpStatusCode.NoContent;
        }
    }

}
