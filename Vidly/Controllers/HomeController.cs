using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
            public ActionResult Index()
            {
                var movie = new Movie { Name = "First" };
                var randomMovie = new RandomMovieViewModel
                {
                    Movie = movie
                };
                return View(randomMovie);
            }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            var movie = new Movie { Name = "Second" };
            var randomMovie = new RandomMovieViewModel
            {
                Movie = movie
            };

            return View(randomMovie);
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            var movie = new Movie { Name = "Third" };
            var randomMovie = new RandomMovieViewModel
            {
                Movie = movie
            };

            return View(randomMovie);
        }
    }
}