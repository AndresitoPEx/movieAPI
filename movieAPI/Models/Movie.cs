using System.ComponentModel.DataAnnotations;

namespace movieAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Titulo es requerido.")]
        [StringLength(100, ErrorMessage = "El titulo no debe exceder los 100 caracteres.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Director es requerido.")]
        [StringLength(50, ErrorMessage = "El nombre del director no debe exceder los 50 caracteres.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Genero es requerido.")]
        [StringLength(30, ErrorMessage = "El genero no debe exceder los 30 caracteres.")]
        public string Genre { get; set; }

        [Range(1900, 2024, ErrorMessage = "El año de realización debe ser entre 1900 y 2024.")]
        public int ReleaseYear { get; set; }
    }
}
