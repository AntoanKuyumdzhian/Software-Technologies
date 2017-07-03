using System.CodeDom;
using System.Linq;
using System.Web.Mvc;
using Ads.Models;
using PagedList;
using System;

namespace Ads.Controllers
{
    public class HomeController : Controller
    {
        private AdsDbContext db = new AdsDbContext();

        public ActionResult Index(int page = 1, string search = null, string category = null)
        {
            ViewBag.pageSize = 6;
            ViewBag.Categories = Enum.GetValues(typeof(Categories)).Cast<Categories>();
            
            var adsQuery = db.Ads.AsQueryable();

            if (search != null)
            {
                adsQuery = adsQuery.Where(a => a.Title.ToLower().Contains(search.ToLower()) ||
                                               a.Description.ToLower().Contains(search.ToLower()));
            }

            adsQuery = adsQuery.Where(a => a.IsActive);

            ViewBag.totalAds = adsQuery.Count();
            var ads = adsQuery
                .OrderByDescending(a => a.Id)     
                .Select(a => new MultiItemsView
                {
                    Id = a.Id,
                    Title = a.Title,
                    Condition = a.Condition.ToString(),
                    Category = a.Category.ToString(),
                    Price = a.Price,
                    Image = a.ImageUrl
                })
                .Skip((page - 1) * 6)
                .Take(6)
                .ToList();
            
            ViewBag.Page = page;

            return View(ads);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}