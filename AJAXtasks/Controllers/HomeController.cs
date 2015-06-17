using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AJAXtasks.Models;

namespace AJAXtasks.Controllers
{
    public class HomeController : Controller
    {
        static List<string> comments;
        static List<IdComment> idComments;

        public ActionResult Index()
        {
            //for clear the list
            comments = new List<string>(0);
            idComments = new List<IdComment>(0);
            return View();
        }

        #region FormAjax
        public ActionResult FormAjax()
        {
            return View(comments);
        }

        [HttpPost]
        public ActionResult FormAjax(string comment)
        {
            comments.Add(comment);
            if (Request.IsAjaxRequest())
            {
                return PartialView("FormAjaxPartial",comment);
            }
            return RedirectToAction("FormAjax");
        }
        #endregion

        #region JqueryAjax
        public ActionResult JqueryAjax()
        {
            ViewBag.comments = idComments;
            return View();
        }

        [HttpPost]
        public ActionResult JqueryAjax(IdComment idComment)
        {
            idComments.Add(idComment);
            if (Request.IsAjaxRequest())
            {
                return Json(idComment);
            }
            return RedirectToAction("JqueryAjax");
        }
        #endregion
    }
}
