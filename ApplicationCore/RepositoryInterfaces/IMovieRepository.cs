using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetTop30HighestGrossingMovies();

        //Task<PaginatedList<Movie>> GetMoviesByGenre(int genreId, int pageSize = 25, int page = 1);
        Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId);

        //Task<IEnumerable<MovieCast>> GetCasts(IEnumerable<MovieCast> movieCasts);
    }
}
