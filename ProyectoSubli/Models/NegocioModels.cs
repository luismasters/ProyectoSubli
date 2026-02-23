namespace ProyectoSubli.Models
{
    public class CategoriaNegocio
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        // Ahora una categoría tiene Videos, Imágenes y Notas
        public List<RecursoVideo> Videos { get; set; } = new List<RecursoVideo>();
        public List<RecursoImagen> Imagenes { get; set; } = new List<RecursoImagen>();
        public List<NotaObservacion> Notas { get; set; } = new List<NotaObservacion>();
    }

    public class RecursoVideo
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string UrlIframe { get; set; } = string.Empty;

        public int CategoriaNegocioId { get; set; }
        public CategoriaNegocio? Categoria { get; set; }
    }

    // NUEVO: Modelo para las imágenes
    public class RecursoImagen
    {
        public int Id { get; set; }
        public string UrlImagen { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public int CategoriaNegocioId { get; set; }
        public CategoriaNegocio? Categoria { get; set; }
    }

    // NUEVO: Modelo para las notas y observaciones
    public class NotaObservacion
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Contenido { get; set; } = string.Empty;

        public int CategoriaNegocioId { get; set; }
        public CategoriaNegocio? Categoria { get; set; }
    }
}