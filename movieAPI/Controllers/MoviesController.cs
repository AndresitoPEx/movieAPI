using Microsoft.AspNetCore.Mvc;
using movieAPI.Business;
using movieAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly MovieService _movieService;

    public MoviesController(MovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public IActionResult GetMovies()
    {
        var movies = _movieService.GetAllMovies();
        return Ok(movies);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovie(int id)
    {
        try
        {
            var movie = _movieService.GetMovieById(id);
            return Ok(movie);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult CreateMovie([FromBody] Movie movie)
    {
        try
        {
            _movieService.AddMovie(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] Movie movie)
    {
        try
        {
            _movieService.UpdateMovie(id, movie);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        try
        {
            _movieService.DeleteMovie(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
