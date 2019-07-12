using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult Index(string searchTerm = null)
        {

            var model =
                _db.Restaurants
                .OrderByDescending(r => r.Reviews.Count)
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                .Select( r=> new RestaturantListViewModel
                {
                    Id =r.Id,
                    Name = r.Name,
                    Country = r.Country,
                    City = r.City,
                    CountOfReviews = r.Reviews.Count()
                });

            return View(model);
        }

        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Chatzipetros";
            model.Location = "Athens, GR";

            ViewBag.Message = "Your application description page.";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}