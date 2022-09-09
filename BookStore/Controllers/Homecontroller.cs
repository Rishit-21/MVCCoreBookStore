using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using BookStore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BookStore.Controllers
{
    public class Homecontroller : Controller
    {
        [ViewData]
        public string Title { get; set; }

        private readonly NewBookAlertConfig _newBookALertconfiguration;
        public Homecontroller(IOptionsSnapshot<NewBookAlertConfig> newBookALertconfiguration)
        {

          _newBookALertconfiguration= newBookALertconfiguration.Value;
        }

        public ViewResult Index()
        {

            //var newBookAlert = new NewBookAlertConfig();
            //_newBookALertconfiguration.Bind("NewBookalert", newBookAlert);
            //bool isDisplay = newBookAlert.DisplayNewBookAlert;
            Title = "Index";
            return View();
        }

        [Route("about-us")]
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
