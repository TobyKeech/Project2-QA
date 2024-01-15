using AutoMapper;
using Project2.Business.DTO;
using Project2.Models;

namespace Project2.Business.Services
{
    public class TPCAutoMapper : Profile
    {
        public TPCAutoMapper()
        {
            //Mapping for Seller
            CreateMap<Seller, SellerDTO>();
            CreateMap<SellerDTO, Seller>();
        }
    }
}
