using Project2.Business.DTO;

namespace Project2.Business.Services
{
    public interface IBookingService
    {
        IQueryable<BookingDTO> FindAll();
        BookingDTO FindById(int id);
        BookingDTO Create(BookingDTO entity);
        BookingDTO Update(BookingDTO entity);
        void Delete(BookingDTO entity);
    }
}

