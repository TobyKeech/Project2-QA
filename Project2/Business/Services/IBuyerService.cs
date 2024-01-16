using Project2.Business.DTO;

namespace Project2.Business.Services
{
    public interface IBuyerService
    {
        IQueryable<BuyerDTO> FindAll();
        IQueryable<BuyerDTO> FindByName(string name);
        BuyerDTO FindById(int id);
        BuyerDTO Create(BuyerDTO entity);
        BuyerDTO Update(BuyerDTO entity);
        void Delete(BuyerDTO entity);
    }
}