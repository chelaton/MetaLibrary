using AutoMapper;
using MetaLibrary.Core.Models;
using MetaLibrary.Data.Entities;

namespace MetaLibrary.ViewModels;

public class MappingProfiles : Profile
{
  public MappingProfiles()
  {
    CreateMap<BookPostViewModel, BookDto>();
    CreateMap<BookDto, Book>()
      .ForMember(dest => dest.Id, opt => opt.Ignore())
      .ForMember(dest => dest.Created, opt => opt.Ignore())
      .ForMember(dest => dest.Updated, opt => opt.Ignore())
      .ForMember(dest => dest.Deleted, opt => opt.Ignore());
    CreateMap<BookPutViewModel, BookDto>();
  }
}
