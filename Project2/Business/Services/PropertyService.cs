using AutoMapper;
using Project2.Business.DTO;
using Project2.Models;
using Project2.Persistence.Repositories;
using System.Linq.Expressions;


namespace Project2.Business.Services
{
    public class PropertyService : IPropertyService
    {

        IPropertyRepository _propertyrepository;
        private IMapper _mapper;


        public PropertyService(IPropertyRepository repository, IMapper mapper)
        {
            _propertyService = repository;
            _mapper = mapper;
        }
        public IQueryable<PropertyDTO> FindAll()
        {
            var properties = _propertyService.FindAll().ToList();
            List<PropertyDTO> dtoProperties = new List<PropertyDTO>();
            foreach (Property property in properties)
            {
                dtoProperties.Add(_mapper.Map<PropertyDTO>(property));
            }
            return dtoProperties.AsQueryable();
        }


        public PropertyDTO FindById(int id)
        {
            Property property = _propertyService.FindById(id);
            PropertyDTO dtoProperty = _mapper.Map<PropertyDTO>(property);
            return dtoProperty;
        }

        public IQueryable<PropertyDTO> FindByName(string PropertyName)
        {
            IQueryable<Property> properties = _propertyService.FindByCondition(b => b.PropertyName == GenreName);
            List<GenreDTO> dtoGenres = new List<GenreDTO>();
            foreach (Genre genre in genres)
            {
                GenreDTO dtoGenre = _mapper.Map<GenreDTO>(genre);
                dtoGenres.Add(dtoGenre);
            }
            return dtoGenres.AsQueryable<GenreDTO>();
        }

        public PropertyDTO Create(PropertyDTO dtoProperty)
        {
            Genre genreData = _mapper.Map<Genre>(dtoGenre);
            genreData = _genrerepository.Create(genreData);
            dtoGenre = _mapper.Map<GenreDTO>(genreData);
            return dtoGenre;
        }

        public void Delete(Property dtoProperty)
        {
            Genre genre = _mapper.Map<Genre>(dtoGenre);
            _genrerepository.Delete(genre);
        }

        public IQueryable<PropertyDTO> FindByCondition(Expression<Func<PropertyDTO, bool>> expression)
        {
            Property propertyData = _mapper.Map<Property>(expression);
            //return _repository.FindByCondition(movieData);
            return null;
        }

        public PropertyDTO Update(PropertyDTO property)
        {
            Property propertyData = _mapper.Map<Property>(property);
            var p = _propertyrepository.FindById(propertyData.Id);
            if (p == null)
                return null;

            p.PropertyAddress = propertyData.Address;

            Property prop = _propertyrepository.Update(p);
            PropertyDTO dtoProperty = _mapper.Map<Property>(prop);
            return dtoProperty;
        }




    }
}
