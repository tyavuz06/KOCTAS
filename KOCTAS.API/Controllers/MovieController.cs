using KOCTAS.Business.Core;
using KOCTAS.Business.Interfaces;
using KOCTAS.Common;
using KOCTAS.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace KOCTAS.API.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieBusiness _business;
        public MovieController(IMovieBusiness movieBusiness) => (_business) = (movieBusiness);

        /// <summary>
        /// Gets All Movies
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/movies")]
        public IActionResult GetALl()
        {
            var response = _business.GetAll();

            switch (response.Code)
            {
                case (int)SystemConstans.CODES.SUCCESS:
                    return Ok(response);
                case (int)SystemConstans.CODES.NOTFOUND:
                    return NotFound(response);
                case (int)SystemConstans.CODES.SYSTEMERROR:
                    return StatusCode(500, response);
                default:
                    return NotFound();
            }
        }

        /// <summary>
        /// Gets Movie For Specified Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/movie/{id}")]
        public IActionResult Get(int id)
        {
            var response = _business.Get(id);

            switch (response.Code)
            {
                case (int)SystemConstans.CODES.SUCCESS:
                    return Ok(response);
                case (int)SystemConstans.CODES.NOTFOUND:
                    return NotFound(response);
                case (int)SystemConstans.CODES.SYSTEMERROR:
                    return StatusCode(500, response);
                default:
                    return NotFound();
            }
        }

        /// <summary>
        /// Creates A Movie
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("/api/movies")]
        public IActionResult Create([FromBody] MovieDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = _business.Create(model);
                switch (response.Code)
                {
                    case (int)SystemConstans.CODES.SUCCESS:
                        return Ok(response);
                    case (int)SystemConstans.CODES.NOTFOUND:
                        return NotFound(response);
                    case (int)SystemConstans.CODES.SYSTEMERROR:
                        return StatusCode(500, response);
                    default:
                        return NotFound();
                }
            }

            return StatusCode(200,"Model Is Not Valid");
        }

        /// <summary>
        /// Updates Movie For Specified Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("/api/movies/{id}")]
        public IActionResult Update(int id, [FromBody] MovieDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = _business.Update(id, model);

                switch (response.Code)
                {
                    case (int)SystemConstans.CODES.SUCCESS:
                        return Ok(response);
                    case (int)SystemConstans.CODES.NOTFOUND:
                        return NotFound(response);
                    case (int)SystemConstans.CODES.SYSTEMERROR:
                        return StatusCode(500, response);
                    default:
                        return NotFound();
                }
            }

            return StatusCode(200, "Model Is Not Valid");
        }

        /// <summary>
        /// Deletes Movie For Speficies Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/movies/{id}")]
        public IActionResult Delete(int id)
        {
            var response = _business.Delete(id);

            switch (response.Code)
            {
                case (int)SystemConstans.CODES.SUCCESS:
                    return Ok(response);
                case (int)SystemConstans.CODES.NOTFOUND:
                    return NotFound(response);
                case (int)SystemConstans.CODES.SYSTEMERROR:
                    return StatusCode(500, response);
                default:
                    return NotFound();
            }
        }
    }
}
