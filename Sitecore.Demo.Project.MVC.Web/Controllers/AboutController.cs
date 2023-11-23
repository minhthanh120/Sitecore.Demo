using Sitecore.Demo.Project.MVC.Web.Models;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Demo.Project.MVC.Web.Controllers
{
    public class AboutController : Controller
    {
        public AboutController()
        {
            
        }
        // GET: About
        public ActionResult Index()
        {
            var model = new AboutViewModel()
            {
                InnerItem = RenderingContext.Current?.Rendering.Item,
            };
            return View(model);
        }
    }
}