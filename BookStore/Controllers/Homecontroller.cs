using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class Homecontroller : Controller
    {
        [ViewData]
        public string Title { get; set; }
        public ViewResult Index()
        {
            Title = "Index";
            return View();
        }
        public ViewResult AboutUs()
        {
            Title = "AboutUs";
            return View();
        }
        public ViewResult ContactUs()
        {
            Title = "ContactUs";
            return View();
        }
    }
}
