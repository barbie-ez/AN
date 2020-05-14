using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AN.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}


        //[HttpPost]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}