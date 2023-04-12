using AutoMapper;
using BusinessLogic.CQRS.Customers.Commands.Create;
using BusinessLogic.CQRS.Customers.Commands.Update;
using BusinessLogic.CQRS.Customers.Dtos;
using BusinessLogic.CQRS.Customers.Queries.GetDetails;
using BusinessLogic.CQRS.Customers.Queries.GetList;
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
            CreateMap<Customer, CustomerCreateCommandRequest>().ReverseMap();
            CreateMap<Customer, CustomerUpdateCommandRequest>().ReverseMap();
            CreateMap<Customer, CustomerDetailVm>().ReverseMap();
            CreateMap<FullAddress, FullAddressDto>();
        }
    }
}
