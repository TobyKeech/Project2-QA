using AutoMapper;
using Project2.Business.DTO;
using Project2.Models;
using Project2.Persistence.Repositories;
using System.Linq.Expressions;
namespace Project2.Business.Services
{
    public class PropertyService : IPropertyService
    {

        IPropertyService _propertyService;
        private IMapper _mapper;


        public PropertyService(IPropertyService repository, IMapper mapper)
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

        public GenreDTO Create(GenreDTO dtoGenre)
        {
            Genre genreData = _mapper.Map<Genre>(dtoGenre);
            genreData = _genrerepository.Create(genreData);
            dtoGenre = _mapper.Map<GenreDTO>(genreData);
            return dtoGenre;
        }

        public void Delete(GenreDTO dtoGenre)
        {
            Genre genre = _mapper.Map<Genre>(dtoGenre);
            _genrerepository.Delete(genre);
        }

        public IQueryable<GenreDTO> FindByCondition(Expression<Func<GenreDTO, bool>> expression)
        {
            Genre genreData = _mapper.Map<Genre>(expression);
            //return _repository.FindByCondition(movieData);
            return null;
        }

        public GenreDTO Update(GenreDTO genre)
        {
            Genre genreData = _mapper.Map<Genre>(genre);
            var g = _genrerepository.FindById(genreData.Id);
            if (g == null)
                return null;

            g.GenreName = genreData.GenreName;

            Genre gen = _genrerepository.Update(g);
            GenreDTO dtoGenre = _mapper.Map<GenreDTO>(gen);
            return dtoGenre;
        }




    }
}
