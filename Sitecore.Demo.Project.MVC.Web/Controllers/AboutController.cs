using Sitecore.Demo.Project.MVC.Web.Models;
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
        // GET: About
        public ActionResult Index()
        {
            var datasourceItem = RenderingContext.Current?.Rendering.Item;
            var model = new AboutViewModel()
            {
                Item = RenderingContext.Current?.Rendering.Item,
            };
            return View();
        }
    }
}