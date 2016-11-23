using BlogSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BlogSystemDbContext context = new BlogSystemDbContext();
            var test = context.Posts.Count();
            return View();
        }

    }
}