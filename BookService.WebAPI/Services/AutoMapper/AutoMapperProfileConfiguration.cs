using AutoMapper;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Services.AutoMapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("MyProfile")
        {

        }

        protected AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {
            CreateMap<BookBasicDto, Book>().ReverseMap();
            //CreateMap<Book, BookBasicDto>();
            CreateMap<Book, BookDetail>()
                .ForMember(
                dest => dest.AuthorName,
                opts => opts.MapFrom(src => $"{src.Author.LastName} {src.Author.FirstName}")
                );
        }
    }
}
