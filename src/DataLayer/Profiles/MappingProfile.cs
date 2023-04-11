using AutoMapper;
using DataLayer.CQRS.Customers.Commands;
using DataLayer.CQRS.Customers.Queries;
using DataLayer.CQRS.FullAddresses;
using DataLayer.Entities;

namespace DataLayer.Profiles
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
