
using OnlineShoppingDemo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingDemo2.Controllers
{
   
    public class ProductUserController : Controller
    {
        // GET: ProductUser
        private DataContext db = new DataContext();

       



        public ActionResult ShowDetails(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


       
        
       

       

    }
}