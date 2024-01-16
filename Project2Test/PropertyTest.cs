using AutoMapper;
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
    public class PropertyTest
    {
        private Mapper _mapper;


        public PropertyTest()
        {
            TPCAutoMapper myProfile = new TPCAutoMapper();
            MapperConfiguration configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }


        private IServiceProvider GetPropertyServiceProivder()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<EstateContext>(options => options.UseInMemoryDatabase("MockDBData"));
            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<PropertyController>();
            services.AddAutoMapper(typeof(Program));
            services.AddControllers();
            return services.BuildServiceProvider();
        }

        private PropertyDTO GetMockProperty()
        {
            return new PropertyDTO
            {
                Address = "36 Beef King",
                Postcode = "BFE 3ET",
                Type = "Detached",
                 NumberOfBedrooms= 2,
                 NumberOfBathrooms = 1,
                 Garden = true,
                 Price = 100000,
                 Status = "Available"
            };
        }

        [Fact]
        public void TestAddProperty()
        {
            var services = GetPropertyServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<IPropertyRepository>();
                var service = new PropertyService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new PropertyController(service);
                //Clear database
                context.Database.EnsureDeleted();

                var PropertyDTO = new PropertyDTO
                {
                    Address = "36 Beef King",
                    Postcode = "BFE 3ET",
                    Type = "Detached",
                    NumberOfBedrooms = 2,
                    NumberOfBathrooms = 1,
                    Garden = true,
                    Price = 100000,
                    Status = "Available"
                };

                controller.AddProperty(PropertyDTO);
                var property = context.Properties.Single();

                Assert.Equal(1, property.Id);
                Assert.Equal("36 Beef King", property.Address);
            }
        }

        [Fact]
        public void TestGetAllProperties()
        {
            var services = GetPropertyServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<IPropertyRepository>();
                var service = new PropertyService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new PropertyController(service);
                //Clear database
                context.Database.EnsureDeleted();

                var PropertyDTO = new PropertyDTO
                {
                    Address = "36 Beef King",
                    Postcode = "BFE 3ET",
                    Type = "Detached",
                    NumberOfBedrooms = 2,
                    NumberOfBathrooms = 1,
                    Garden = true,
                    Price = 100000,
                    Status = "Available"
                };

                controller.AddProperty(PropertyDTO);
                var property = context.Properties.Single();

                Assert.Equal(1, property.Id);
                Assert.Equal("36 Beef King", property.Address);
            }
        }

        [Fact]
        public void TestGetPropertyById()
        {
            var services = GetPropertyServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<IPropertyRepository>();
                var service = new PropertyService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new PropertyController(service);
                //Clear database
                context.Database.EnsureDeleted();

                var PropertyDTO = new PropertyDTO
                {
                    Address = "36 Beef King",
                    Postcode = "BFE 3ET",
                    Type = "Detached",
                    NumberOfBedrooms = 2,
                    NumberOfBathrooms = 1,
                    Garden = true,
                    Price = 100000,
                    Status = "Available"
                };

                controller.AddProperty(PropertyDTO);
                var property = context.Properties.Single();

                Assert.Equal(1, property.Id);
                Assert.Equal("36 Beef King", property.Address);
            }
        }


        [Fact]
        public void TestUpdateProperty()
        {
            var services = GetPropertyServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<IPropertyRepository>();
                var service = new PropertyService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new PropertyController(service);
                //Clear database
                context.Database.EnsureDeleted();

                var PropertyDTO = new PropertyDTO
                {
                    Address = "36 Beef King",
                    Postcode = "BFE 3ET",
                    Type = "Detached",
                    NumberOfBedrooms = 2,
                    NumberOfBathrooms = 1,
                    Garden = true,
                    Price = 100000,
                    Status = "Available"
                };

                controller.AddProperty(PropertyDTO);
                var property = context.Properties.Single();

                Assert.Equal(1, property.Id);
                Assert.Equal("36 Beef King", property.Address);
            }
        }

        [Fact]
        public void TestDeleteProperty()
        {
            var services = GetPropertyServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<IPropertyRepository>();
                var service = new PropertyService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new PropertyController(service);
                //Clear database
                context.Database.EnsureDeleted();

                var PropertyDTO = new PropertyDTO
                {
                    Address = "36 Beef King",
                    Postcode = "BFE 3ET",
                    Type = "Detached",
                    NumberOfBedrooms = 2,
                    NumberOfBathrooms = 1,
                    Garden = true,
                    Price = 100000,
                    Status = "Available"
                };

                controller.AddProperty(PropertyDTO);
                var property = context.Properties.Single();

                Assert.Equal(1, property.Id);
                Assert.Equal("36 Beef King", property.Address);
            }
        }

    }
}
