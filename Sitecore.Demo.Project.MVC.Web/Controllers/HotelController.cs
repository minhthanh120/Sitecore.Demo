using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Demo.Project.MVC.Web.Models;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Extensions;
using Sitecore.Mvc.Presentation;
using Sitecore.Resources.Media;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Image = Sitecore.Demo.Project.MVC.Web.Models.Image;

namespace Sitecore.Demo.Project.MVC.Web.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            var model = new HotelModel();
            List<Hotel> hotels = new List<Hotel>();

            var dataSource = RenderingContext.Current?.Rendering.Item;
            MultilistField slidesField = dataSource.Fields["List Hotels"];

            //Rendering Parameters
            var slideCountParam = RenderingContext.Current?.Rendering.Parameters["SlideCount"];
            int.TryParse(slideCountParam, out int result);
            int slideCount = result == 0 ? 20 : result;

            if (slidesField?.Count > 0)
            {
                var slideItems = slidesField.GetItems();

                foreach (var slideItem in slideItems.Take(slideCount))
                {
                    //Title
                    var titleField = slideItem.Fields["Title"];
                    var title = titleField?.Value;

                    //Sub Title
                    var subTitle = new MvcHtmlString(FieldRenderer.Render
                        (slideItem, "Address"));
                    //Image
                    var image = new MvcHtmlString(FieldRenderer.Render
                        (slideItem, "Image"));
                    var price = new MvcHtmlString(FieldRenderer.Render
                        (slideItem, "Price"));
                    //Call to action
                    var callToAction = slideItem.Fields["Call_To_Action"]?.Value;
                    var score = slideItem.Fields["Score"]?.Value;
                    var id = slideItem.Fields["Id"]?.Value;
                    MultilistField images = slideItem.Fields["Images"];
                    Item[] items = images.GetItems();

                    hotels.Add(new Hotel
                    {
                        Title = title,
                        Address = subTitle,
                        Image = (items != null && items.Length > 0) ? new MvcHtmlString(string.Format("<img src=\"{0}\" ></>", MediaManager.GetMediaUrl(new MediaItem(items[0])))) : image,
                        CallToAction = callToAction,
                        Score = score,
                        Price = price,
                        Id = id,
                    });
                }
                model.Hotels = hotels;
            }
            return View(model);
        }
        public ActionResult Detail(string itemId = "")
        {
            if (string.IsNullOrEmpty(itemId))
            {
                itemId = "/sitecore/content/DemoSitecore/Data/Hotels/Livotel Hotel";
            }
            //Data.Database master = Configuration.Factory.GetDatabase("master");
            Data.Items.Item hotel = Context.Database.GetItem(itemId);
            //Title
            var titleField = hotel.Fields["Title"];
            var title = titleField?.Value;

            //Sub Title
            var subTitle = new MvcHtmlString(FieldRenderer.Render
                (hotel, "Address"));

            //Image
            var image = new MvcHtmlString(FieldRenderer.Render
                (hotel, "Image"));
            var price = new MvcHtmlString(FieldRenderer.Render
                (hotel, "Price"));
            //Call to action
            var callToAction = hotel.Fields["Call_To_Action"]?.Value;
            var score = hotel.Fields["Score"]?.Value;
            var id = hotel.Fields["Id"]?.Value;
            MultilistField images = hotel.Fields["Images"];
            Item[] items = images.GetItems();
            var hotelImages = new List<MvcHtmlString>();
            if (items != null && items.Length > 0)
            {
                foreach (var item in items)
                {
                    hotelImages.Add(
                        new MvcHtmlString(string.Format("<img \"class= img-fluid\" src=\"{0}\" ></>", MediaManager.GetMediaUrl(new MediaItem(item))))
                        );
                }
            }
            var model = new Hotel()
            {
                Title = title,
                Address = subTitle,
                Image = (items != null && items.Length > 0) ? new MvcHtmlString(FieldRenderer.Render(items.LastOrDefault(), "Image")) : image,
                CallToAction = callToAction,
                Score = score,
                Price = price,
                Images = hotelImages,
                Id = id
            };
            ViewBag.Title = model.Title;
            return View(model);
        }

    }
}