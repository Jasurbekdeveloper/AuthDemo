using AuthDemo.Aplication.DTO;
using Library.Models.Domain;
using System.Net.Http.Headers;

namespace AuthDemo.Aplication.Mapper;

public static class MovieMapper
{
    public static Movie MapToMovie(MovieCreationDto movieCreationDto)
    {
        return new Movie
        {
            Id = Guid.NewGuid(),
            Title = movieCreationDto.title,
            Description = movieCreationDto.description,
            Rating = movieCreationDto.rating
        };
    }
    public static MovieDto MapToMovieDto(Movie movie)
    {
        return new MovieDto(movie.Id, movie.Title, movie.Description, movie.Rating);
    }

    public static void MapToMovie(Movie movie,
        MovieModificationDto movieModificationDto) 
    {
        movie.Title = movieModificationDto.title ?? movie.Title;
        movie.Description = movieModificationDto.description ?? movie.Description;
        movie.Rating = movieModificationDto.rating ?? movie.Rating;
    }
}
