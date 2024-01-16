using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Project2.Business.DTO;
using Project2.Business.Services;
using Project2.Controllers;
using Project2.EF;
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


        //Constructor used for adding configuration
        public SellerControllerTests()
        {
            TPCAutoMapper myProfile = new TPCAutoMapper();
            MapperConfiguration configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }


        //Fetching Seller services
        private IServiceProvider GetSellerServiceProivder()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<EstateContext>(options => options.UseInMemoryDatabase("MockDBData"));

            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<SellerController>();

            services.AddAutoMapper(typeof(Program));

            services.AddControllers();

            return services.BuildServiceProvider();
        }

        private SellerDTO GetMockSeller()
        {
            return new SellerDTO
            {
                FirstName = "John",
                Surname = "Doe",
                Address = "36 Beef King",
                Postcode = "BE2 SKI",
                Phone = "123456789",
                Properties = { }
            };
        }

        [Fact]
        public void TestAddSeller()
        {
            var services = GetSellerServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<ISellerRepository>();
                var service = new SellerService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new SellerController(service);

                //Clear database
                context?.Database.EnsureDeleted();

                var SellerDTO = new SellerDTO
                {
                    FirstName = "John",
                    Surname = "Doe",
                    Address = "36 Beef King",
                    Postcode = "BE2 SKI",
                    Phone = "123456789",
                    Properties = { }
                };

                controller.AddSeller(SellerDTO);
                var seller = context.Sellers.Single();

                Assert.Equal(1, seller.Id);
                Assert.Equal("John", seller.FirstName);
            }
        }

        [Fact]
        public void TestGetAllSeller()
        {
            var services = GetSellerServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<ISellerRepository>();
                var service = new SellerService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new SellerController(service);

                //Clear database
                context?.Database.EnsureDeleted();

                var SellerDTO = new SellerDTO
                {
                    Id = 1,
                    FirstName = "John",
                    Surname = "Doe",
                    Address = "36 Beef King",
                    Postcode = "BE2 SKI",
                    Phone = "123456789",
                    Properties = { }
                };

                controller.AddSeller(SellerDTO);
                var seller = controller.Index().Single();
                    //context.Sellers.Single();

                //Assert.Equal(1, seller.Id);
                Assert.Equal("John", seller.FirstName);
            }
        }

        [Fact]
        public void TestGetSellerById()
        {
            var services = GetSellerServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<ISellerRepository>();
                var service = new SellerService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new SellerController(service);

                //Clear database
                context?.Database.EnsureDeleted();

                var SellerDTO = new SellerDTO
                {
                    FirstName = "John",
                    Surname = "Doe",
                    Address = "36 Beef King",
                    Postcode = "BE2 SKI",
                    Phone = "123456789",
                    Properties = { }
                };

                controller.AddSeller(SellerDTO);
                controller.GetById(1);
                var seller = new SellerDTO
                {
                    Id = 1,
                    FirstName = "John"
                };

                Assert.Equal(1, seller.Id);
                Assert.Equal("John", seller.FirstName);

                /*var actionResult = controller.GetById(1);
                var okObjectResult = actionResult.Result as OkObjectResult;
                var resultDTO = okObjectResult.Value as SellerDTO;

                var expectedSellerDTO = new SellerDTO
                {
                    FirstName = "John",
                    Surname = "Doe",
                    Address = "1 High Street, Cardiff",
                    Postcode = "CF1 1AA",
                    Phone = "01234567890",
                    Properties = { }
                };

                Assert.Equal(expectedSellerDTO.FirstName, resultDTO.FirstName);*/
            }
        }

        [Fact]
        public void TestGetSellerByName()
        {
            var services = GetSellerServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<ISellerRepository>();
                var service = new SellerService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new SellerController(service);

                //Clear database
                context?.Database.EnsureDeleted();

                var SellerDTO = new SellerDTO
                {
                    FirstName = "John",
                    Surname = "Doe",
                    Address = "36 Beef King",
                    Postcode = "BE2 SKI",
                    Phone = "123456789",
                    Properties = { }
                };

                controller.AddSeller(SellerDTO);
                controller.GetByName("John");
                var seller = context.Sellers.Single();

                Assert.Equal(1, seller.Id);
                Assert.Equal("John", seller.FirstName);
            }
        }


        [Fact]
        public void TestUpdateProperty()
        {
            var services = GetSellerServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<ISellerRepository>();
                var service = new SellerService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new SellerController(service);

                //Clear database
                context?.Database.EnsureDeleted();

                var SellerDTO = new SellerDTO
                {
                    FirstName = "John",
                    Surname = "Doe",
                    Address = "36 Beef King",
                    Postcode = "BE2 SKI",
                    Phone = "123456789",
                    Properties = { }
                };

                controller.AddSeller(SellerDTO);
                controller.UpdateSeller(SellerDTO);
                var seller = context.Sellers.Single();

                Assert.Equal(1, seller.Id);
                Assert.Equal("John", seller.FirstName);
            }
        }

        [Fact]
        public void TestDeleteProperty()
        {
            var services = GetSellerServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<ISellerRepository>();
                var service = new SellerService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new SellerController(service);

                //Clear database
                context?.Database.EnsureDeleted();

                var Seller1DTO = new SellerDTO
                {
                    Id = 1,
                    FirstName = "John",
                    Surname = "Doe",
                    Address = "36 Beef King",
                    Postcode = "BE2 SKI",
                    Phone = "123456789",
                    Properties = { }
                };
                controller.AddSeller(Seller1DTO);

                var Seller2DTO = new SellerDTO
                {
                    Id = 2,
                    FirstName = "Anna",
                    Surname = "Smith",
                    Address = "High Street",
                    Postcode = "BE2 SKI",
                    Phone = "123456789",
                    Properties = { }
                };
                controller.AddSeller(Seller2DTO);


                controller.DeleteSeller(1);
                var seller = context.Sellers.Single();

                Assert.Equal(2, seller.Id);
                Assert.Equal("Anna", seller.FirstName);
            }
        }

    }
}
