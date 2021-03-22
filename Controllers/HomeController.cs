using Assignment9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Assignment9.Models.ViewModels;
using System.Threading.Tasks;

namespace Assignment9.Controllers
{
    public class HomeController : Controller
    {
       private MovieContext context { get; set; }

        public HomeController(MovieContext con)
        {
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MovieForm(MovieForm movie) //adding movie to the Db
        {

           
            
                context.Movie.Add(movie);
                context.SaveChanges();
            
            
                
            

            return View("MovieList", new MovieViewModel
            {
                Movie = context.Movie.Where(x => x.Title != null)
            });

        }

        
        public IActionResult MovieList()
        {

            //return View();
            return View(new MovieViewModel
            {
                Movie = context.Movie
            });
        }
        [HttpPost]
        public IActionResult MovieList(int movieId)
        {

            return View("EditMovie", new MovieViewModel
            {
                Movie = context.Movie.Where(x => x.MovieId == movieId),
                
            }); ;
        }

        [HttpPost]
        public IActionResult MovieDelete (int MovieDeleteId)  //passing in movieID then removing the movie through its id
        {
            var removeMovie = context.Movie.FirstOrDefault(x => x.MovieId == MovieDeleteId);
            context.Movie.Remove(removeMovie);
            context.SaveChanges();
            return View("MovieList", new MovieViewModel
            {
                Movie = context.Movie.Where(x => x.Title != null)
            });
        }


        [HttpPost]
        public IActionResult EditMovie(MovieForm movieForm, int movieIdentity) //passing in the new edited movie and deleting old one
        {
            var removeMovie = context.Movie.FirstOrDefault(x => x.MovieId == movieIdentity);
            context.Movie.Remove(removeMovie);
            context.Movie.Add(movieForm);
            context.SaveChanges();
            return View("MovieList", new MovieViewModel
            {
                Movie = context.Movie.Where(x => x.Title != null)
            });
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
