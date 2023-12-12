using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Demo.Project.MVC.Web.Models
{
    public class HotelModel
    {
        public List<Hotel> Hotels { get; set; }
        
    }
    public class Hotel
    {
        public string Title { get; set; }
        public MvcHtmlString Address { get; set; }
        public MvcHtmlString Image { get; set; }
        public string CallToAction { get; set; }
        public string Score { get; set; }
        public string Phone { get; set; }
        public string Id { get; set; }
        public MvcHtmlString Price { get; set; }
        public List<MvcHtmlString> Images { get; set; }
        public Item Avatar { get; set; }
    }
    public class Image
    {
        public MvcHtmlString Name { get; set; }
    }
}