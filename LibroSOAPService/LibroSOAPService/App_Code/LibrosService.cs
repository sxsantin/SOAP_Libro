using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
public class LibrosService : WebService
{
    // Simulación de una base de datos en memoria
    private static List<Libro> libros = new List<Libro>();

    // Método para agregar un libro
    [WebMethod]
    public string AgregarLibro(string titulo, string autor, int anioPublicacion)
    {
        var nuevoLibro = new Libro
        {
            Id = Guid.NewGuid(),
            Titulo = titulo,
            Autor = autor,
            AnioPublicacion = anioPublicacion
        };
        libros.Add(nuevoLibro);
        return "Libro agregado correctamente.";
    }

    // Método para obtener todos los libros
    [WebMethod]
    public List<Libro> ObtenerLibros()
    {
        return libros;
    }

    // Método para actualizar un libro
    [WebMethod]
    public string ActualizarLibro(Guid id, string titulo, string autor, int anioPublicacion)
    {
        var libro = libros.Find(l => l.Id == id);
        if (libro == null)
        {
            return "Libro no encontrado.";
        }

        libro.Titulo = titulo;
        libro.Autor = autor;
        libro.AnioPublicacion = anioPublicacion;
        return "Libro actualizado correctamente.";
    }

    // Método para eliminar un libro
    [WebMethod]
    public string EliminarLibro(Guid id)
    {
        var libro = libros.Find(l => l.Id == id);
        if (libro == null)
        {
            return "Libro no encontrado.";
        }

        libros.Remove(libro);
        return "Libro eliminado correctamente.";
    }

    // Clase para representar un libro
    public class Libro
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnioPublicacion { get; set; }
    }
}
