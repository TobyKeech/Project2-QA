using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Project2.Business.DTO;
using Project2.Models;
using Project2.Persistence.Repositories;
using System.Net;
using System.Numerics;

namespace Project2.Business.Services
{
    public class SellerService : ISellerService
    {
        ISellerRepository _sellerRepository;
        private IMapper _mapper;

        public SellerService(ISellerRepository sellerRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }

        public IQueryable<SellerDTO> FindAll()
        {
            var sellers = _sellerRepository.FindAll().ToList();
            List<SellerDTO> dtoSeller = new List<SellerDTO>();
            foreach (Seller seller in sellers)
            {
                dtoSeller.Add(_mapper.Map<SellerDTO>(seller));
            }
            return dtoSeller.AsQueryable();
        }

        public SellerDTO FindById(int id)
        {
            Seller seller = _sellerRepository.FindById(id);
            SellerDTO dtoSeller = _mapper.Map<SellerDTO>(seller);
            return dtoSeller;
        }

        public IQueryable<SellerDTO> FindByName(string firstName)
        {
            IQueryable<Seller> sellers = _sellerRepository.FindByCondition(b => b.FirstName == firstName);
            List<SellerDTO> dtoSellers = new List<SellerDTO>();
            foreach (Seller seller in sellers)
            {
                SellerDTO dtoSeller = _mapper.Map<SellerDTO>(seller);
                dtoSellers.Add(dtoSeller);
            }
            return dtoSellers.AsQueryable<SellerDTO>();
        }

        public SellerDTO Create(SellerDTO dtoSeller)
        {
            Seller sellerData = _mapper.Map<Seller>(dtoSeller);
            sellerData = _sellerRepository.Create(sellerData);
            dtoSeller = _mapper.Map<SellerDTO>(sellerData);
            return dtoSeller;
        }

        public void Delete(SellerDTO dtoSeller)
        {
            Seller seller = _mapper.Map<Seller>(dtoSeller);
            _sellerRepository.Delete(seller);
        }

        public SellerDTO Update(SellerDTO seller)
        {
            Seller sellerData = _mapper.Map<Seller>(seller);
            var s = _sellerRepository.FindById(sellerData.Id);
            if (s == null)
                return null;

            //s.SellerId = sellerData.SellerId;
            s.FirstName = sellerData.FirstName;
            s.Surname = sellerData.Surname;
            s.Address = sellerData.Address;
            s.Postcode = sellerData.Postcode;
            s.Phone = sellerData.Phone;
            s.Properties = sellerData.Properties;

            Seller sel = _sellerRepository.Update(s);
            SellerDTO dtoSeller = _mapper.Map<SellerDTO>(sel);
            return dtoSeller;
        }
    }
}

