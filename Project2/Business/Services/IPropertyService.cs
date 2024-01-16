using Project2.Business.DTO;

namespace Project2.Business.Services
{
    public interface IPropertyService
    {
        IQueryable<PropertyDTO> FindAll();
        IQueryable<PropertyDTO> FindByName(string title);
        PropertyDTO FindById(int id);
        PropertyDTO Create(PropertyDTO entity);
        PropertyDTO Update(PropertyDTO entity);
        void Delete(PropertyDTO entity);
    }
}

