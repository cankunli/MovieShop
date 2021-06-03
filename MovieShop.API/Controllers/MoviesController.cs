using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.Get30HighestGrossing();
            if (!movies.Any())
                return NotFound("We did not find any movies");
            return Ok(movies);
        }

        //[HttpGet]
        //[Route("")]
        //public async Task<IActionResult> GetAllMovies([FromQuery] int pageSize = 30, [FromQuery] int page = 1,
        //    string title = "")
        //{
        //    var movies = await _movieService.GetMoviesByPagination(pageSize, page, title);
        //    return Ok(movies);
        //}

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> MoviesDetails(int id)
        {
            var movies = await _movieService.GetMovieAsync(id);

            if (movies == null)
            {
                return NotFound("We did not find information about this movie");
            }
            return Ok(movies);
        }
        
        

        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> GetMoviesByGenre(int genreId)
        {
            var movies = await _movieService.GetMoviesByGenre(genreId);
            return Ok(movies);
        }
    }
}