using AutoMapper;
using InitialAssignment.CRUD.Entities;
using InitialAssignment.CRUD.UI.WebApp.Models.ViewModels;

namespace InitialAssignment.CRUD.UI.WebApp.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, VMBook>().ReverseMap();

        }
    }
}
