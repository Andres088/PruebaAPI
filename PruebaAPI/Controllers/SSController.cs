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
            using (Entities obj = new Entities())
            {
                var pato = obj.patologia;
                var patologias = pato.ToList();
                //var js = new JavaScriptSerializer().Serialize(patologias);
                return Json(patologias, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ProductoPatologia()
        {
            var old_id = Request.QueryString["id"];
            int id = int.Parse(old_id.ToString());

            using (Entities obj = new Entities())
            {

                var x = from popa in obj.patologia_producto
                        where popa.idPatologia == id
                        select popa.idProducto;

                var productos_id = x.ToList();

                var y = obj.producto;
                var productos_obj = y.ToList();
                List<producto> productos = new List<producto>();


                foreach (producto prod in productos_obj)
                {
                    if (productos_id.Contains(prod.idProducto)) {
                        productos.Add(prod);
                    }
                }
                return Json(productos, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult DetalleProducto()
        {
            var old_id = Request.QueryString["id"];
            //int id = int.Parse(old_id.ToString());

            using (Entities obj = new Entities())
            {

                var x =  obj.producto.ToList();

                List<producto> productos = new List<producto>();

                foreach (producto prod in x)
                {
                    if (prod.idProducto.Equals(old_id)) productos.Add(prod);
                }
                

                return Json(productos, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult FavoritoProducto()
        {
            var id = Request.QueryString["id"];
            var old_bool = Request.QueryString["fav"];
            bool favi = Convert.ToBoolean(old_bool);
            

            using (Entities obj = new Entities())
            {

                var x = obj.patologia_producto.ToList();

                foreach (patologia_producto papo in x)
                {
                    if (papo.idProducto.Equals(id)) papo.flagfav = favi;
                }

                obj.SaveChanges();


                string vacio = "Subida completada";
                //producto vacio = new producto();
             
                return Json(vacio, JsonRequestBehavior.AllowGet);
            }
           
        }
    }




}