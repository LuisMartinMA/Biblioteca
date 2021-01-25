using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class Libros
    {
        [Key]
        public int LibroID { get; set; }

        [Display(Name = "Nombre ")]                    // se personaliza el nombre de la etiqueta del campo
        [Required(ErrorMessage = "Se necesita ingresar {0}")]  // {0} se inidca el campo en el que  se esta trabajando 
        [StringLength(30, ErrorMessage = "El registro {0} No esta en el rango de {2} a {1} caracteres", MinimumLength = 3)]
        public String Nombre { get; set; }
        [Display(Name = "Autor")]                    // se personaliza el nombre de la etiqueta del campo
        [Required(ErrorMessage = "Se necesita ingresar {0}")]  // {0} se inidca el campo en el que  se esta trabajando 
        [StringLength(30, ErrorMessage = "El registro {0} No esta en el rango de {2} a {1} caracteres", MinimumLength = 3)]
        public String Autor { get; set; }

        //
        public int GeneroID { get; set; }

        public virtual TipoLibro TipoLibros { get; set; }

            
    }
}