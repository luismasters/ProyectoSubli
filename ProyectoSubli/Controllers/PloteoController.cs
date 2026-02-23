using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoSubli.Data;
using ProyectoSubli.Models;

namespace ProyectoSubli.Controllers
{
    public class PloteoController : Controller
    {
        private readonly AppDbContext _context;

        public PloteoController(AppDbContext context)
        {
            _context = context;
        }

        // --- PANTALLA PRINCIPAL ---
        public IActionResult Index()
        {
            // Ahora traemos la categoría e INCLUIMOS videos, imágenes y notas
            var categoria = _context.Categorias
                                    .Include(c => c.Videos)
                                    .Include(c => c.Imagenes)
                                    .Include(c => c.Notas)
                                    .FirstOrDefault(c => c.Nombre == "Ploteo");

            if (categoria == null)
            {
                categoria = new CategoriaNegocio { Nombre = "Ploteo", Descripcion = "Área de vinilos y corte" };
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
            }

            // Enviamos el "paquete completo" (la categoría con todas sus listas) a la vista
            return View(categoria);
        }

        // ==========================================
        // SECCIÓN VIDEOS
        // ==========================================
        [HttpPost]
        public IActionResult AgregarVideo(string titulo, string urlIframe)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Nombre == "Ploteo");
            if (categoria != null && !string.IsNullOrEmpty(urlIframe))
            {
                _context.Videos.Add(new RecursoVideo { Titulo = titulo, UrlIframe = urlIframe, CategoriaNegocioId = categoria.Id });
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost] // NUEVO: Función para eliminar
        public IActionResult EliminarVideo(int id)
        {
            var video = _context.Videos.Find(id);
            if (video != null)
            {
                _context.Videos.Remove(video);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // ==========================================
        // SECCIÓN IMÁGENES (CARRUSEL)
        // ==========================================
        [HttpPost]
        public IActionResult AgregarImagen(string descripcion, string urlImagen)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Nombre == "Ploteo");
            if (categoria != null && !string.IsNullOrEmpty(urlImagen))
            {
                _context.Imagenes.Add(new RecursoImagen { Descripcion = descripcion, UrlImagen = urlImagen, CategoriaNegocioId = categoria.Id });
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EliminarImagen(int id)
        {
            var imagen = _context.Imagenes.Find(id);
            if (imagen != null)
            {
                _context.Imagenes.Remove(imagen);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // ==========================================
        // SECCIÓN NOTAS Y OBSERVACIONES
        // ==========================================
        [HttpPost]
        public IActionResult AgregarNota(string titulo, string contenido)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Nombre == "Ploteo");
            if (categoria != null && !string.IsNullOrEmpty(contenido))
            {
                _context.Notas.Add(new NotaObservacion { Titulo = titulo, Contenido = contenido, CategoriaNegocioId = categoria.Id });
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EliminarNota(int id)
        {
            var nota = _context.Notas.Find(id);
            if (nota != null)
            {
                _context.Notas.Remove(nota);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}