using movieAPI.Data;
using movieAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace movieAPI.Business
{
    public class MovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id)
                ?? throw new KeyNotFoundException($"La pelicula con el ID: {id} no fue encontrada.");
        }

        public void AddMovie(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie), "Datos de la pelicula requeridos.");

            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void UpdateMovie(int id, Movie movie)
        {
            var existingMovie = _context.Movies.Find(id);
            if (existingMovie == null)
                throw new KeyNotFoundException($"La pelicula con el ID: {id} no fue encontrada.");

            existingMovie.Title = movie.Title;
            existingMovie.Director = movie.Director;
            existingMovie.Genre = movie.Genre;
            existingMovie.ReleaseYear = movie.ReleaseYear;

            _context.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
                throw new KeyNotFoundException($"La pelicula con el ID: {id} no fue encontrada.");

            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
