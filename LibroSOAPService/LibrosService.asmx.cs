using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LibrosSOAPServer
{
    [WebService(Namespace = "http://miservicio.com/libros")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class LibrosService : WebService
    {
        // Base de datos simulada (Lista estática)
        private static List<Libro> libros = new List<Libro>
        {
            new Libro { Id = 1, Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", Anio = 1967 },
            new Libro { Id = 2, Titulo = "Don Quijote de la Mancha", Autor = "Miguel de Cervantes", Anio = 1605 }
        };

        [WebMethod]
        public List<Libro> ObtenerLibros()
        {
            return libros;
        }

        [WebMethod]
        public string AgregarLibro(string titulo, string autor, int anio)
        {
            int nuevoId = libros.Any() ? libros.Max(l => l.Id) + 1 : 1;
            libros.Add(new Libro { Id = nuevoId, Titulo = titulo, Autor = autor, Anio = anio });
            return $"Libro '{titulo}' agregado con éxito.";
        }

        [WebMethod]
        public string EditarLibro(int id, string titulo, string autor, int anio)
        {
            var libro = libros.FirstOrDefault(l => l.Id == id);
            if (libro == null) return $"Libro con ID {id} no encontrado.";
            libro.Titulo = titulo;
            libro.Autor = autor;
            libro.Anio = anio;
            return $"Libro con ID {id} actualizado con éxito.";
        }

        [WebMethod]
        public string EliminarLibro(int id)
        {
            var libro = libros.FirstOrDefault(l => l.Id == id);
            if (libro == null) return $"Libro con ID {id} no encontrado.";
            libros.Remove(libro);
            return $"Libro con ID {id} eliminado con éxito.";
        }
    }

    // Modelo de datos
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Anio { get; set; }
    }
}
