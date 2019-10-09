using AutoMapper;
using BookService.Lib.DTO;
using BookService.Lib.Models;
using System.Linq;

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
            CreateMap<PublisherBasicDto, Publisher>().ReverseMap();
            CreateMap<Book, BookStatisticsDto>()
                .ForMember(dest => dest.RatingsCount,
                            opts => opts.MapFrom(src => src.Ratings.Count))
                .ForMember(dest => dest.ScoreAverage,
                           opts => opts.MapFrom(src => src.Ratings.Average(r => r.Score)));
        }
    }
}
