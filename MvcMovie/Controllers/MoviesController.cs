using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
	public class MoviesController : Controller
	{
		private readonly MvcMovieContext dbContext;

        public MoviesController(MvcMovieContext dbContext)
        {
			this.dbContext = dbContext;
        }

        [HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddMovieViewModel viewModel)
		{
			v ar movie = new Movie {
				Title = viewModel.Title,
				Genre = viewModel.Genre,
				Price = viewModel.Price,
			};
			await dbContext.Movie.AddAsync(movie);

			await dbContext.SaveChangesAsync();

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> List()
		{
			var movies = await dbContext.Movie.ToListAsync();

			return View(movies);
		}
	}
}
