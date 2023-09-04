using AutoMapper;
using FilmFusion.Application.Dtos.Models;
using FilmFusion.Domain.Entities;

namespace FilmFusion.Application.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<EntertainmentDto, Entertainment>().ReverseMap();
            CreateMap<MovieBackdropDto, MovieBackdrop>().ReverseMap();
            CreateMap<MovieBoxOfficeDto, MovieBoxOffice>().ReverseMap();
            CreateMap<MovieDirectoryDto, MovieDirectory>().ReverseMap();
            CreateMap<MoviePosterDto, MoviePoster>().ReverseMap();
            CreateMap<MovieRatingDto, MovieRating>().ReverseMap();
            CreateMap<MovieTrailerDto, MovieTrailer>().ReverseMap();
            CreateMap<MovieDetailDto, MovieDetail>().ReverseMap();
        }
    }
}
