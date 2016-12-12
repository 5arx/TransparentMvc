using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransparentMvcLib.Classes;

namespace TransparentMvc.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var model = new ProductDb().GetProducts();

            return View(model);
        }

        public ActionResult Details(int id) {
            var model = new ProductDb().GetProducts().FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                return HttpNotFound(string.Format("Product with Id:{0} was not found!", id));
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new ProductDb().GetProducts().FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                return HttpNotFound(string.Format("Product with Id:{0} was not found!", id));
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Product p) {
            if (ModelState.IsValid) {
                new ProductDb().Save(p);
            }
            return View(p);


        }
    }
}