using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Project2.Business.DTO;
using Project2.Business.Services;
using Project2.Controllers;
using Project2.EF;
using Project2.Models;
using Project2.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2Test
{
    public class SellerControllerTests
    {

        private Mapper _mapper;

        public SellerControllerTests()
        {
            TPCAutoMapper myProfile = new TPCAutoMapper();
            MapperConfiguration configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }


        private IServiceProvider GetBuyerServiceProivder()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<EstateContext>(options => options.UseInMemoryDatabase("MockDBData"));
            services.AddScoped<IBuyerService, BuyerService>();
            services.AddScoped<IBuyerRepository, BuyerRepository>();
            services.AddScoped<BuyerController>();
            services.AddAutoMapper(typeof(Program));
            services.AddControllers();
            return services.BuildServiceProvider();
        }

        private BuyerDTO GetMockBuyer()
        {
            return new BuyerDTO
            {
                FirstName = "Steve",
                Surname = "Smith",
                Address = "1 Main Street",
                Postcode = "TE 5T",
                Phone = "12345"
            };
        }
    }
}
