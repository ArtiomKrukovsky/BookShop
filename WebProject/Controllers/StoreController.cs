using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Domain.Interfaces;
using WebProject.Domain.Model;

namespace WebProject.Controllers
{
    public class StoreController : Controller
    {
        private IUnitOfWork context;
        public StoreController(IUnitOfWork _context)
        {
            context = _context;
        }

        public ActionResult MainPage()
        {
            var product = context.Products.GetAll();
            return View(product);
        }

        public ActionResult GetProduct(int id)
        {
            var product=context.Products.Get(id);
            if (product==null)
                return HttpNotFound();
            return View(product);
        }

        [HttpPost]
        public ActionResult ToOrder(Product product, int Count)
        {
            if (Count < 0) Count = 1;
            else if (Count > 10) Count = 10;
                    
            return View();
        }
    }
}