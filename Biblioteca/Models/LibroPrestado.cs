using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Biblioteca.Models
{
    public class LibroPrestado


    {
        [Key]
        public int PrestamoID { get; set; }
        public int LectorID { get; set; }
        public virtual Lector Lector { get; set; }
        //
        public int LibroID { get; set; }
        public virtual Libros Libro { get; set; }

    }
}