using Sitecore.Data.Fields;
using Sitecore.Demo.Project.MVC.Web.Models;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Demo.Project.MVC.Web.Controllers
{
    public class CarouselController : Controller
    {
        // GET: Carousel
        public ActionResult Index()
        {
            var model = new CarouselModel();
            List<Slide> slides = new List<Slide>();
            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField slidesField = dataSource.Fields["Slides"];
            if(slides?.Count > 0 )
            {
                var slideItems = slidesField.GetItems();
                foreach( var slideItem in slideItems )
                {
                    var titleField = slideItem.Fields["Title"];
                    var title = titleField?.Value;
                    var subTitle = new MvcHtmlString(Sitecore.Web.UI.WebControls.FieldRenderer.Render
                        (RenderingContext.Current?.Rendering.Item, "Sub_Title"));
                    
                    var image = new MvcHtmlString(Sitecore.Web.UI.WebControls.FieldRenderer.Render
                        (RenderingContext.Current?.Rendering.Item, "Image"));

                    var callToAction = new MvcHtmlString(Sitecore.Web.UI.WebControls.FieldRenderer.Render
                        (RenderingContext.Current?.Rendering.Item, "Call_To_Action", "class=btn animated fadeInUp"));
                    slides.Add(new Slide
                    {
                        Title = title,
                        SubTitle = subTitle,
                        Image = image,
                        CallToAction = callToAction,
                    });
                }
                model.Slides = slides;
            }
            return View(model);

        }
    }
}