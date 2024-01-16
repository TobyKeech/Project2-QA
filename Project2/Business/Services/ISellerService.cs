using Microsoft.AspNetCore.Mvc;
using Project2.Business.DTO;

namespace Project2.Business.Services
{
    public interface ISellerService
    {
        IQueryable<SellerDTO> FindAll();
        IQueryable<SellerDTO> FindByName(string title);
        SellerDTO FindById(int id);
        SellerDTO Create(SellerDTO entity);
        SellerDTO Update(SellerDTO entity);
        void Delete(SellerDTO entity);
    }
}
