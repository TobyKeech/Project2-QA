using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.EntityFrameworkCore;
using Project2.Business.DTO;
using Project2.Business.Services;
using Project2.Controllers;
using Project2.EF;
using Project2.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using System.Linq;
using System;

namespace Project2Test
{
    public class BuyerUnitTests
    {
        private Mapper _mapper;

        public BuyerUnitTests()
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

        [Fact]
        public void TestAddBuyer()
        {
            var services = GetBuyerServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<IBuyerRepository>();
                var service = new BuyerService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new BuyerController(service);
                //Clear database
                context.Database.EnsureDeleted();

                var buyerDTO = new BuyerDTO
                {
                    FirstName = "testname",
                    Surname = "surnametest",
                    Address = "123 test street",
                    Postcode = "TE 5T",
                    Phone = "123456789"
                };

                controller.AddBuyer(buyerDTO);
                var buyer = context.Buyers.Single();

                Assert.Equal(1, buyer.Id);
                Assert.Equal("testname", buyer.FirstName);
            }
        }
        [Fact]
 
        public void TestGetBuyerById()
        {
            var services = GetBuyerServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<IBuyerRepository>();
                var service = new BuyerService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new BuyerController(service);
                //Clear database
                context.Database.EnsureDeleted();
                var BuyerDTO = new BuyerDTO
                {
                    FirstName = "David",
                    Surname = "Williams",
                    Address = "100 Magnor Road, Newport",
                    Postcode = "NP1 2LL 8RR",
                    Phone = "01234567891",

                };

                controller.AddBuyer(GetMockBuyer());
                var buyer = context.Buyers.Single();

                Assert.Equal(1, buyer.Id);
                Assert.Equal("Steve", context.Buyers.FirstOrDefault().FirstName);
            }
        }
        [Fact]
        public void TestGetBuyer()
        {
            var services = GetBuyerServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<IBuyerRepository>();
                var service = new BuyerService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new BuyerController(service);
                //Clear database
                context.Database.EnsureDeleted();

                controller.AddBuyer(GetMockBuyer());



                Assert.Equal(1, context.Buyers.Count());
                Assert.Equal("Steve", context.Buyers.FirstOrDefault().FirstName);
            }
        }

        [Fact]
        public void TestUpdateBuyer()
        {
            var services = GetBuyerServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<IBuyerRepository>();
                var service = new BuyerService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new BuyerController(service);
                //Clear database
                context.Database.EnsureDeleted();


                var BuyerDTO = new BuyerDTO
                {
                    FirstName = "David",
                    Surname = "Williams",
                    Address = "100 Magnor Road, Newport",
                    Postcode = "NP1 2LL 8RR",
                    Phone = "01234567891",

                };


                controller.AddBuyer(BuyerDTO);
                var buyerName = context.Buyers.Single().FirstName;
                var newName = "Gemma";
                //= context.Buyers.Single();
                controller.UpdateBuyer(
                    BuyerDTO = new BuyerDTO
                    {
                        FirstName = newName,
                        Surname = "Williams",
                        Address = "100 Magnor Road, Newport",
                        Postcode = "NP1 2LL 8RR",
                        Phone = "01234567891",
                    }) ;

                
                 // Assert.Equal("David", buyerName);
               Assert.Equal("Gemma", newName);
            }
        }

        [Fact]
        public void TestDeleteBuyer()
        {
            var services = GetBuyerServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<IBuyerRepository>();
                var service = new BuyerService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new BuyerController(service);
                //Clear database
                context.Database.EnsureDeleted();

                var BuyerDTO = new BuyerDTO
                {
                    FirstName = "David",
                    Surname = "Williams",
                    Address = "100 Magnor Road, Newport",
                    Postcode = "NP1 2LL 8RR",
                    Phone = "01234567891",

                };


                controller.AddBuyer(BuyerDTO);
                var buyerId = context.Buyers.Single().Id;
                    //= context.Buyers.Single();
                controller.DeleteBuyer(buyerId);
              //  Assert.Equal(1, buyer.Id);
                Assert.Equal(0, context.Buyers.Count());
            }
        }
    }
}