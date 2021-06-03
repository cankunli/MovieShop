using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;

namespace Infrastructure.Services
{
   public class CastService: ICastService
    {
            private readonly ICastRepository _castRepository;

            public CastService(ICastRepository castRepository)
            {
                _castRepository = castRepository;
            }
            public async Task<CastDetailsResponseModel> GetCastDetailsWithMovies(int castId)
            {
                var cast = await _castRepository.GetByIdAsync(castId);
                if (cast == null)
                {
                    throw new NotFoundException("Cast", castId);
                }

                var movieList = new List<MovieResponseModel>();
                foreach (var movie in cast.MovieCasts)
                {
                    movieList.Add(
                    new MovieResponseModel()
                    {
                        Id = movie.MovieId,
                        Title = movie.Movie.Title,
                        PosterUrl = movie.Movie.PosterUrl
                    });
                }
                //lksdjflkj

            CastDetailsResponseModel CastDetailsResponseModel = new CastDetailsResponseModel();
                var response = CastDetailsResponseModel;
                response.Id = cast.Id;
                response.Name = cast.Name;
                response.Gender = cast.Gender;
                response.TmdbUrl = cast.TmdbUrl;
                response.ProfilePath = cast.ProfilePath;
                response.Movies = movieList;

            return response;
            }
    }
}
