using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<List<MovieCardResponseModel>> Get30HighestGrossing();
        void CreateMovie(MovieCreateRequestModel model);

        Task<MovieDetailsResponseModel> GetMovieAsync(int id);
        //Task<PaginatedList<MovieResponseModel>> GetMoviesByGenre(int genreId, int pageSize = 25, int page = 1);

        //Task<List<MovieDetailsResponseModel>> GetGenreByMovie(int id);

        //List<MovieDetailsResponseModel> GetCastsAsync(int id);

        Task<List<MovieCardResponseModel>> GetMoviesByGenre(int genreId);

        //Task<List<MovieDetailsResponseModel.CastResponseModel>> GetCasts(MovieCast srcMovieCasts);
    }
}
