

using AutoMapper;
using BlazorWebApp.Shared.Services;
using BlazorWebApp.Shared.ViewModels;

namespace BlazorWebApp.Shared.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CustomerListVm, CustomerListViewModel>().ReverseMap();
            CreateMap<CustomerDetailVm, CustomerDetailsViewModel>().ReverseMap();
            CreateMap<CustomerDetailsViewModel, CustomerCreateCommandRequest>().ReverseMap();
            CreateMap<CustomerDetailsViewModel, CustomerUpdateCommandRequest>().ReverseMap();
            CreateMap<FileUploadViewModel, FileParameter>().ReverseMap();
            
        }
    }
}
