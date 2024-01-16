using AutoMapper;
using Project2.Models;
using Project2.Business.DTO;
namespace Project2.Business.Services
{
    public class TPCAutoMapper:Profile
    {
        public TPCAutoMapper()
        {
            CreateMap<Property, PropertyDTO>();

            CreateMap<PropertyDTO, Property>();
            
             CreateMap<Seller, SellerDTO>();
            CreateMap<SellerDTO, Seller>();
        }
    }
}
