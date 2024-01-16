using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Project2.Business.DTO;
using Project2.Models;
using Project2.Persistence.Repositories;
using System.Linq.Expressions;

namespace Project2.Business.Services
{
    public class BuyerService: IBuyerService
    {
        IBuyerRepository _buyerRepository;
        private IMapper _mapper;

        public BuyerService (IBuyerRepository buyerRepository, IMapper mapper)
        {
            _buyerRepository = buyerRepository;
            _mapper = mapper;
        }

        public IQueryable<BuyerDTO> FindAll()
        {
            var buyers = _buyerRepository.FindAll().ToList();
            List<BuyerDTO> dtoBuyers = new List<BuyerDTO>();
            foreach (Buyer buyer in buyers)
            {
                dtoBuyers.Add(_mapper.Map<BuyerDTO>(buyer));
            }
            return dtoBuyers.AsQueryable();
        }

        public BuyerDTO FindById(int id)
        {
            Buyer buyer = _buyerRepository.FindById(id);
            BuyerDTO dtoBuyer = _mapper.Map<BuyerDTO>(buyer);
            return dtoBuyer;
        }

        public IQueryable<BuyerDTO> FindByName(string title)
        {
            IQueryable<Buyer> buyers = _buyerRepository.FindByCondition(b => b.FirstName == title);
            List<BuyerDTO> dtoBuyers = new List<BuyerDTO>();
            foreach (Buyer buyer in buyers)
            {
                BuyerDTO dtoBuyer = _mapper.Map<BuyerDTO>(buyer);
                dtoBuyers.Add(dtoBuyer);
            }
            return dtoBuyers.AsQueryable<BuyerDTO>();
        }

        public BuyerDTO Create(BuyerDTO dtoBuyer)
        {
            Buyer buyerData = _mapper.Map<Buyer>(dtoBuyer);
            buyerData = _buyerRepository.Create(buyerData);
            dtoBuyer = _mapper.Map<BuyerDTO>(buyerData);
            return dtoBuyer;
        }

        public void Delete(BuyerDTO dtoBuyer)
        {
            Buyer buyer = _mapper.Map<Buyer>(dtoBuyer);
            _buyerRepository.Delete(buyer);
        }

        public IQueryable<BuyerDTO> FindByCondition(Expression<Func<BuyerDTO, bool>> expression)
        {
            Buyer buyerData = _mapper.Map<Buyer>(expression);
            //return _repository.FindByCondition(movieData);
            return null;
        }

        public BuyerDTO Update(BuyerDTO buyer)
        {
            Buyer buyerData = _mapper.Map<Buyer>(buyer);
            var b = _buyerRepository.FindById(buyerData.Id);
            if (b == null)
                return null;

            b.FirstName = buyerData.FirstName;
            b.Surname = buyerData.Surname;
            b.Address = buyerData.Address;
            b.Postcode = buyerData.Postcode;
            b.Phone = buyerData.Phone;

            Buyer buyr = _buyerRepository.Update(b);
            BuyerDTO dtoGenre = _mapper.Map<BuyerDTO>(buyr);
            return dtoGenre;
        }
    }
}
