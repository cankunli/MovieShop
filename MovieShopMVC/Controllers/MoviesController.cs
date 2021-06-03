using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Infranstructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            // It will look for a View with  name called Index (because the action method name is index)
            // return index2, TestView
            // 1. ViewBag 2. ViewData 3.** Strongly Typed Models
            // Send List of top 30 Movies to the View
            // id, title, posterlUrl


            //ViewBag.PageTitle = "Top 30 Grossing Movies";
            var movies = _movieService.Get30HighestGrossing();



            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {

            var movie = await _movieService.GetMovieAsync(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Create(MovieCreateRequestModel model)
        {
            _movieService.CreateMovie(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Genre(int id)
        {
            var movies = await _movieService.GetMoviesByGenre(id);
            return View("Genres", movies);
        }
    }
}
