using BlogSystem.Data;
using BlogSystem.Models;
using BlogSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Controllers
{
    public class PostController : BaseController
    {
        public PostController()
        {

        }
        public ActionResult Index()
        {
            ICollection<PostViewModel> posts = this.Context.Posts.Select(p=> new PostViewModel()
            {
                Content = p.Content,
                DateCreated = p.DateCreated,
                Name = p.Name,
                UserName = p.User.UserName
            }
            )
            .OrderByDescending(p => p.DateCreated)
            .ToList();
            
            
            return View(posts);
        }

        [HttpGet]
        public ActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PostViewModel postViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Create");
            }

            var user = this.Context.Users.FirstOrDefault(u => u.UserName ==
            HttpContext.User.Identity.Name

            );

            Post post = new Post()
            {
                Name = postViewModel.Name,
                Content = postViewModel.Content,
                DateCreated = DateTime.Now,
                User = user
            };

            this.Context.Posts.Add(post);
            this.Context.SaveChanges();

            return RedirectToAction("Index");
            
        }

    }
}