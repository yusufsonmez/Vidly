using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult New()
        {
            var genreTypes = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genreTypes
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var viewModel = _context.Movies.Single(m => m.Id == movie.Id);
                viewModel.Name = movie.Name;
                viewModel.GenreId = movie.GenreId;
                viewModel.NumberInStock = movie.NumberInStock;
                viewModel.ReleaseDate = movie.ReleaseDate;
            }
            
                _context.SaveChanges();
            
            return RedirectToAction("Index", "Movies");
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                //Id = movie.Id,
                //Name = movie.Name,
                //ReleaseDate = movie.ReleaseDate,
                //NumberInStock = movie.NumberInStock,
                //GenreId = movie.GenreId,
                Genres = _context.Genres.ToList()
            };


            return View("MovieForm", viewModel);
        }
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            
            return View("ReadOnlyList");
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie(){ Name = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer {Name="Yusuf"},
                new Customer {Name="Aslı"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }
        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include("Genre").SingleOrDefault(c => c.Id == id);
            //var movies = GetMovies().SingleOrDefault(c => c.Id == id);

            if (movies == null)
                return HttpNotFound();

            return View(movies);
        }

    }
}