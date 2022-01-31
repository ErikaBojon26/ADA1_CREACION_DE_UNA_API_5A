using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Peliculas.Models.Response;
using Peliculas.Models;
using Peliculas.Models.Request;

namespace Peliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();


            try
            {
                using (PeliculasContext db = new PeliculasContext())
                {
                    var lst = db.Peliculas.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }


        [HttpPost]
        public IActionResult Add(PeliculasRequest Models)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PeliculasContext db = new PeliculasContext())
                {
                    Pelicula Pelicula = new Pelicula();
                    Pelicula.Titulo = Models.Titulo;
                    Pelicula.Director = Models.Director;
                    Pelicula.Genero = Models.Genero;
                    Pelicula.Puntuacion = Models.Puntuacion;
                    Pelicula.Rating = Models.Rating;
                    Pelicula.FechaPublicacion = Models.FechaPublicacion;
                    db.Peliculas.Add(Pelicula);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        //METODO PARA EDITAR
        [HttpPut]
        public IActionResult Editar(PeliculasRequest Models)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PeliculasContext db = new PeliculasContext())
                {

                    //ID para modificar los datos
                    Pelicula Pelicula = db.Peliculas.Find(Models.IdPeliculas);
                    Pelicula.Titulo = Models.Titulo;
                    Pelicula.Director = Models.Director;
                    Pelicula.Genero = Models.Genero;
                    Pelicula.Puntuacion = Models.Puntuacion;
                    Pelicula.Rating = Models.Rating;
                    Pelicula.FechaPublicacion = Models.FechaPublicacion;
                    //Indica que se modifico
                    db.Entry(Pelicula).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        //METODO PARA ELIMINAR EL ID
        [HttpDelete("{IdPeliculas}")]
        public IActionResult Eliminar(int IdPeliculas)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (PeliculasContext db = new PeliculasContext())
                {

                    //para eliminar una pelicula con el ID
                    Pelicula eli = db.Peliculas.Find(IdPeliculas);

                    //
                    //elimina los datos en el Registro
                    db.Remove(eli);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }


    }
    
}


