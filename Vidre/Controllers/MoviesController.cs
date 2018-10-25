using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidre.Models;
using Vidre.ViewModel;

namespace Vidre.Controllers
{
    public class MoviesController : Controller
    {
        //Action Results
        // GET: Movies/Random
        [Route("movies/random")]
        public ActionResult Random()
        {
            var movie = new Movie() {Name = "Shrek"};

            /*An action result can return any of following values*/

            //return View(movie);
            //return content("hello world");
            //return httpnotfound();
            //return new emptyresult();

            /*
             redirect to another page
             sometimes need to pass a annonymous objectnnZ144
             here, it has values for page and sortby prop
             --------------------------------------------
             */
            //return RedirectToAction("index", "home", new {page = 1, sortby = "name"});

            /*View Bag, not recommended*/
            //ViewBag.Movie = movie;


            var customers = new List<Customer>
            {
                new Customer{Name="customer 1"},
                new Customer{Name = "customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            /*recommended method to pass data to View*/
            return View(viewModel);   
        }



        //demo -  parameter binding
        /*
         if parameter name changed into something other than id
         in url (but not in query string) must use "id". no any other name
         cz, default route set as "{controller}/{action}/{id}"
        */
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            //returning a content
            //passing pageIndex as first para and sortBy as second para
            return Content(String.Format("pageIndex={0}&sortby={1}", pageIndex, sortBy));

            //to check on browser
            //http://localhost:62738/movies/Index?pageIndex=1&sortBy=Name2
            //http://localhost:62738/movies/Index
            //http://localhost:62738/movies/Index?pageIndex=2
            // all above will work
        }


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + " /" + month);
        }
    }
}