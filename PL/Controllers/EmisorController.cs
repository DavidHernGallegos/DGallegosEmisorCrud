using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EmisorController : Controller
    {
        // GET: Emisor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll ()
        {
            Dictionary<string,object> respuesta = BL.Emisor.GetAll();
            bool resultado = (bool)respuesta["Resultado"];
            string mensaje = (string)respuesta["Mensaje"];
            if (resultado)
            {
                ML.Emisor emisor = (ML.Emisor)respuesta["Emisor"];

                View(emisor);
            }
            else
            {

                ViewBag.Mensaje = mensaje;
                PartialView("Modal");
            }

            return View();
        }


        [HttpPost]
        public ActionResult Form(ML.Emisor emisor)
        {

            if (emisor.IdEmisor > 0)
            {
                Dictionary<string, object> result = BL.Emisor.Update(emisor);
                bool resultado = (bool)result["Resultado"];
                if (resultado == true)
                {
                    ViewBag.Mensaje = "Se ha actualizado el registro";
                    return PartialView("Modal");
                }
                else
                {
                    string exepcion = (string)result["Mensaje"];
                    ViewBag.Mensaje = "El emisor no se pudo actualizar" + exepcion;
                    return PartialView("Modal");
                }
            }
            else
            {
                Dictionary<string, object> result = BL.Emisor.Add(emisor);
                bool resultado = (bool)result["Resultado"];

                if (resultado == true)
                {
                    ViewBag.Mensaje = "El emisor ha sido insertado";
                    return PartialView("Modal");
                }
                else
                {
                    string exepcion = (string)result["Mensaje"];
                    ViewBag.Mensaje = "El emisor no se pudo registrar" + exepcion;
                    return PartialView("Modal");
                }

            }

        }

        [HttpGet]
        public ActionResult Form(int? idEmisor)
        {

            ML.Emisor emisor = new ML.Emisor();
            if (idEmisor != null)
            {
                Dictionary<string, object> result = BL.Emisor.GetById(idEmisor.Value);
                bool resultado = (bool)result["Resultado"];

                if (resultado == true)
                {
                   
                    emisor = (ML.Emisor)result["Emisor"];
                    View(emisor);

                }
                else
                {
                    string exepcion = (string)result["Mensaje"];
                    ViewBag.Mensaje = "Ocurrio un error al recuperar la informacion" + exepcion;
                    return PartialView("Modal");
                }
            }
            else
            {
                
                return View(emisor);
            }
           

            return View();
       
        }

        [HttpGet]
        public ActionResult Delete(int idEmisor)
        {
            Dictionary<string, object> respuesta = BL.Emisor.Delete(idEmisor);
            bool resultado = (bool)respuesta["Resultado"];
            string mensaje = (string)respuesta["Mensaje"];
            if (resultado == true)
            {

                ViewBag.Mensaje = mensaje;
                return PartialView("Modal");
            }
            else
            {

                ViewBag.Mensaje = mensaje;
                return PartialView("Modal");
            }
   
        }


    }
}