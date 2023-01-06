using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InitialAssignment.CRUD.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Autor")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Author { get; set; } = null!;

        [Display(Name = "Clasificación")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Classification { get; set; } = null!;

        [Display(Name = "Edición")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Edition { get; set; }

        [Display(Name = "Editorial")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Editorial { get; set; } = null!;

        [Display(Name = "Titulo")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Title { get; set; } = null!;

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal Price { get; set; }

        [Display(Name = "Fecha de Publicación")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime PublicationDate { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
