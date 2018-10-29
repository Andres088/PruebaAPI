using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaAPI.Models;
using System.Web.Script.Serialization;
namespace PruebaAPI.Controllers
{
    public class SSController : Controller
    {
        // GET: SS
        public ActionResult ListadoPatologias()
        {

            patologia[] patologias = { new patologia() { Nombre = "Diarrea" }, new patologia() {Nombre = "Nauseas" } };

            //var js = new JavaScriptSerializer().Serialize(patologias);
            return Json(patologias,JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductoPorPatologia()
        {
            var id = Request.QueryString["id"];
            return Json(id, JsonRequestBehavior.AllowGet);
        }
        
    }
}