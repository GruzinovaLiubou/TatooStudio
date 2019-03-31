using ITAcademy.Gallery.Bl;
using Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web16.Controllers
{
    public class HomeController : Controller
    {
        IPhotoService _photoService;

        public HomeController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        //[Dependency]
        //public IPhotoService _photoService { get; set; }

        public ActionResult Index()
        {
            return View(_photoService.GetPhotos());
        }
    }
}