using KOCTAS.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace KOCTAS.API.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/api/movies")]
        public void GetMovies()
        {
        }

        [HttpGet("/api/movie/{id}")]
        public void GetMovie(int id)
        {
        }

        [HttpPut("/api/movies")]
        public void AddMovie([FromBody] AddMovieModel model)
        {
            if (ModelState.IsValid)
            {

            }
        }

        [HttpPost("/api/movies/{id}")]
        public void UpdateMovie(int id, [FromBody] AddMovieModel model)
        {
            if (ModelState.IsValid)
            {

            }
        }

        [HttpDelete("/api/movies/{id}")]
        public void DeleteMov(int id)
        {
            if (ModelState.IsValid)
            {

            }
        }
    }
}
