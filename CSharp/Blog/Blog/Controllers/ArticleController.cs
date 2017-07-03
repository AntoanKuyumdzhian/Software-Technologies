namespace Blog.Controllers
{
    using Blog.Models;
    using System.Data.Entity;
    using System.Web.Mvc;
    using System.Linq;
    using System.Net;
    using Microsoft.AspNet.Identity;

    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            using(var db = new BlogDbContext())
            {
                var articles = db.Articles.Include(a => a.Author).ToList();
                return View(articles);
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    var authorId = User.Identity.GetUserId();

                    article.AuthorId = authorId;
                    db.Articles.Add(article);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(article);
        }

        public ActionResult Details(int id)
        {
            using (var db = new BlogDbContext())
            {
                var article = db.Articles.Where(a => a.Id == id).Include(a => a.Author).First();
                if (article == null)
                {
                    return HttpNotFound();
                }

                return View(article);
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using(var db = new BlogDbContext())
            {
                var article = db.Articles.Where(a => a.Id == id).First();

                if (article == null)
                {
                    return HttpNotFound();
                }

                return View(article);
            }
        }
    }
}