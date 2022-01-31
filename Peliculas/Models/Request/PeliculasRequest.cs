using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peliculas.Models.Request
{
    public class PeliculasRequest
    {
        public int IdPeliculas { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Genero { get; set; }
        public string Puntuacion { get; set; }
        public string Rating { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
}
