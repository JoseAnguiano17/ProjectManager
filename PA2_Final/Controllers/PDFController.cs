using PA2_Final.DAL;
using PA2_Final.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace PA2_Final.Controllers
{
    public class PDFController : Controller
    {
        SystemContext db = new SystemContext();

        // GET: PDF
        public ActionResult Index()
        {
            return View(db.Proyectoes.ToList());
        }
    }
}