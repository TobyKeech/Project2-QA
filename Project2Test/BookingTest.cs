using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class BookingTest
    {
        private Mapper _mapper;

        public BookingTest() {
            TPCAutoMapper myProfile = new TPCAutoMapper();
            MapperConfiguration configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }

        private IServiceProvider GetBookingServiceProivder()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<EstateContext>(options => options.UseInMemoryDatabase("MockDBData"));
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<BookingController>();
            services.AddAutoMapper(typeof(Program));
            services.AddControllers();
            return services.BuildServiceProvider();
        }

        private BookingDTO GetMockBooking()
        {
            return new BookingDTO
            {
                Time = new DateTime(2024, 11, 11, 18, 32, 6),
            };
        }

        [Fact]
        public void TestGetBooking()
        {
            var services = GetBookingServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<IBookingRepository>();
                var service = new BookingService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new BookingController(service);
           
                context.Database.EnsureDeleted();

                controller.AddBooking(GetMockBooking());

                Assert.Equal(1, context.Bookings.Count());
                Assert.Equal("11/11/2024 18:32:06", context.Bookings.FirstOrDefault().Time.ToString());

            }
        }

        [Fact]

        public void TestGetBookingById()
        {
            var services = GetBookingServiceProivder();
            using (var scope = services.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<IBookingRepository>();
                var service = new BookingService(repo, _mapper);
                var context = scope.ServiceProvider.GetService<EstateContext>();
                var controller = new BookingController(service);

                context.Database.EnsureDeleted();

                var BookingDTO = new BookingDTO
                {
                    Time = new DateTime(2024, 11, 11, 18, 32, 6),

                };


                controller.AddBooking(GetMockBooking());
                var booking = context.Bookings.Single();

                Assert.Equal(1, booking.Id);
                Assert.Equal("11/11/2024 18:32:06", context.Bookings.FirstOrDefault().Time.ToString());
            }
        }
    }
}




