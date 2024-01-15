using Project2.Business.DTO;
using Project2.Models;
using AutoMapper;

namespace Project2.Business.Services
{
    public class TCPAutoMapper: Profile
    {

        public TCPAutoMapper()
        {
            CreateMap<Buyer, BuyerDTO>();
            CreateMap<BuyerDTO, Buyer>();
        }

     }
}
