using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AspNetCoreFiltersExamples.Infrastructure;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreFiltersExamples.Controllers
{
    //[HttpsOnly]
    //[Profile]
    [ViewResultDetails]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View("Message", "this is the Index action from the Home Controller");
        //}


         
        /// <summary>
        /// 在Action中过滤
        /// </summary>
        /// <returns></returns>
        //public IActionResult Index()
        //{
        //    if(!Request.IsHttps)
        //    {
        //        return new StatusCodeResult(StatusCodes.Status403Forbidden);
        //    }
        //    else
        //    {
        //       return View("Message", "This is the Index action on the Home Controller");
        //    } 
        //}

        //使用特性过滤
        //[RequireHttps]
        //public ViewResult Index()
        //{
        //    return View("Message", "This is the Index action on the Home Controller");
        //}

        public ViewResult Index()
        {
            return View("Message", "This is the Index action on the Home Controller");
        }
    }
}
