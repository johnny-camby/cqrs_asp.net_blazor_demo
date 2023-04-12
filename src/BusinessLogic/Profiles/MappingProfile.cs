using AutoMapper;
using BusinessLogic.CQRS.Customers.Dtos;
using BusinessLogic.CQRS.Customers.Queries;
using BusinessLogic.CQRS.FullAddresses.Dtos;
using DataLayer.Entities;

namespace BusinessLogic.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Customer, CustomerListVm>();
            CreateMap<FullAddress, FullAddressDto>();
        }
    }
}
