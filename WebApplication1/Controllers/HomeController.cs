using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Blog> blogs;
            // want to do a database call here
            using (var db = new BloggingContext())
            {
                // Create and save a new Blog
                //Console.Write("Enter a name for a new Blog: ");
                //var name = Console.ReadLine();
                var name = "Dave";

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();

                // Display all Blogs from the database
                IOrderedQueryable<Blog> query = from b in db.Blogs
                    orderby b.Name
                    select b;

                blogs = db.Blogs.ToList();

                //Console.WriteLine("All blogs in the database:");
                //foreach (var item in query)
                //{
                //    Console.WriteLine(item.Name);
                //}

                //Console.WriteLine("Press any key to exit...");
                //Console.ReadKey();
            }


            return View(blogs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}