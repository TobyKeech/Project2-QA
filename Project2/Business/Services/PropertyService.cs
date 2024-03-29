﻿using AutoMapper;
using Project2.Business.DTO;
using Project2.Models;
using Project2.Persistence.Repositories;
using System.Linq.Expressions;


namespace Project2.Business.Services
{
    public class PropertyService : IPropertyService 
    {

        IPropertyRepository _propertyrepository;
        IBookingRepository _bookingRepository;
        private IMapper _mapper;


        public PropertyService(IPropertyRepository repository, IBookingRepository bookingRepository, IMapper mapper)
        {
            _propertyrepository = repository;
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }
        public IQueryable<PropertyDTO> FindAll()
        {
            var properties = _propertyrepository.FindAll().ToList();
            List<PropertyDTO> dtoProperties = new List<PropertyDTO>();
            foreach (Property property in properties)
            {
                dtoProperties.Add(_mapper.Map<PropertyDTO>(property));
            }
            return dtoProperties.AsQueryable();
        }


        public PropertyDTO FindById(int id)
        {
            Property property = _propertyrepository.FindById(id);
            PropertyDTO dtoProperty = _mapper.Map<PropertyDTO>(property);
            return dtoProperty;
        }

        public IQueryable<PropertyDTO> FindByName(string PropertyAddress)
        {
            IQueryable<Property> properties = _propertyrepository.FindByCondition(b => b.Address == PropertyAddress);
            List<PropertyDTO> dtoProperties = new List<PropertyDTO>();
            foreach (Property property in properties)
            {
                PropertyDTO dtoProperty = _mapper.Map<PropertyDTO>(property);
                dtoProperties.Add(dtoProperty);
            }
            return dtoProperties.AsQueryable<PropertyDTO>();
        }

        public PropertyDTO Create(PropertyDTO dtoProperty)
        {
            Property propertyData = _mapper.Map<Property>(dtoProperty);
            propertyData = _propertyrepository.Create(propertyData);
            dtoProperty = _mapper.Map<PropertyDTO>(propertyData);
            return dtoProperty;
        }

        public void Delete(PropertyDTO dtoProperty)
        {
            Property property = _mapper.Map<Property>(dtoProperty);

            //remove all bookings which have a matching PropertyId from DB
            var bookings = _bookingRepository.FindAll().ToList();
            foreach (Booking booking in bookings)
            {
                if (booking.PropertyId == dtoProperty.Id)
                {
                    _bookingRepository.Delete(booking);
                }
            }
            _propertyrepository.Delete(property);
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

            p.Address = propertyData.Address;
            p.Postcode = propertyData.Postcode;
            p.Type = propertyData.Type;
            p.NumberOfBedrooms = propertyData.NumberOfBedrooms;
            p.NumberOfBathrooms = propertyData.NumberOfBathrooms;
            p.Garden = propertyData.Garden;
            p.Price = propertyData.Price;
            p.Status = propertyData.Status;

            Property prop = _propertyrepository.Update(p);
            PropertyDTO dtoProperty = _mapper.Map<PropertyDTO>(prop);
            return dtoProperty;
        }

    }
}
