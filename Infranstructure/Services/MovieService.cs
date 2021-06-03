using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;

namespace Infranstructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<MovieCardResponseModel>> Get30HighestGrossing()
        {
            var movies = await _movieRepository.GetTop30HighestGrossingMovies();
            var result = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                result.Add(
                new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return result;
        }

        public void CreateMovie(MovieCreateRequestModel model)
        {
            // take model and convert it to Movie Entity and send it to repository
            // if repository saves successfully return true/id:2
        }

        public async Task<MovieDetailsResponseModel> GetMovieAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            //if (movie == null) throw new NotFoundException("Movie", id);
            //var favoritesCount = await _favoriteRepository.GetCountAsync(f => f.MovieId == id);
            //var response = _mapper.Map<MovieDetailsResponseModel>(movie);
            //response.FavoritesCount = favoritesCount;
            //return response;
            //var favoriteCount = await _movieRepository.GetCountAsync(f => f.Id == id);

            var movieCast = new List<MovieDetailsResponseModel.CastResponseModel>();
            foreach (var cast in movie.MovieCasts)
                movieCast.Add(new MovieDetailsResponseModel.CastResponseModel
                {
                    Id = cast.CastId,
                    Gender = cast.Cast.Gender,
                    Name = cast.Cast.Name,
                    ProfilePath = cast.Cast.ProfilePath,
                    TmdbUrl = cast.Cast.TmdbUrl,
                    Character = cast.Character
                });

            var genreList = new List<GenreModel>();
            foreach (var genre in movie.Genres)
            {
                genreList.Add(new GenreModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }

            MovieDetailsResponseModel movieDetailResponseModel = new MovieDetailsResponseModel();
            var response = movieDetailResponseModel;
            response.Id = movie.Id;
            response.Title = movie.Title;
            response.PosterUrl = movie.PosterUrl;
            response.BackdropUrl = movie.BackdropUrl;
            response.Rating = movie.Rating;
            response.Overview = movie.Overview;
            response.Tagline = movie.Tagline;
            response.Budget = movie.Budget;
            response.Revenue = movie.Revenue;
            response.ImdbUrl = movie.ImdbUrl;
            response.TmdbUrl = movie.TmdbUrl;
            response.ReleaseDate = movie.ReleaseDate;
            response.RunTime = movie.RunTime;
            response.Price = movie.Price;
            //response.FavoritesCount = favoriteCount;
            response.Casts = movieCast;
            response.Genres = genreList;
            return response;
        }

        
        //public async Task<MovieDetailsResponseModel> GetGenreByMovie(int id)
        //{
        //    var movie = await _movieRepository.GetByIdAsync(id);
        //    var result = new List<GenreModel>();
        //    foreach (var genre in movie.Genres)
        //    {
        //        result.Add(
        //        new GenreModel
        //        {
        //            Id = genre.Id,
        //            Name = genre.Name
        //        });
        //    }
        //}

        
        public async Task<List<MovieCardResponseModel>> GetMoviesByGenre(int genreId)
        {
            var movies = await _movieRepository.GetMoviesByGenre(genreId);
            var result = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                result.Add(
                new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return result;
        }

        //public List<MovieDetailsResponseModel.CastResponseModel> GetCastsAsync(IEnumerable<MovieCast> srcMovieCasts)
        //{
        //    //var movies = await _movieRepository.GetCasts(id);
        //    var movieCast = new List<MovieDetailsResponseModel.CastResponseModel>();
        //    foreach (var cast in srcMovieCasts)
        //        movieCast.Add(new MovieDetailsResponseModel.CastResponseModel
        //        {
        //            Id = cast.CastId,
        //            Gender = cast.Cast.Gender,
        //            Name = cast.Cast.Name,
        //            ProfilePath = cast.Cast.ProfilePath,
        //            TmdbUrl = cast.Cast.TmdbUrl,
        //            Character = cast.Character
        //        });

        //    return movieCast;
        //}



        //public async Task<List<MovieDetailsResponseModel.CastResponseModel>> GetCasts(MovieCast srcMovieCasts)
        //{
        //    var movieCast = new List<MovieDetailsResponseModel.CastResponseModel>();
        //    foreach (var cast in movieCast)
        //        movieCast.Add(new MovieDetailsResponseModel.CastResponseModel
        //        {
        //            Id = cast.Id,
        //            Gender = cast.Gender,
        //            Name = cast.Name,
        //            ProfilePath = cast.ProfilePath,
        //            TmdbUrl = cast.TmdbUrl,
        //            Character = cast.Character
        //        });

        //    return movieCast;
        //}
    }
}
