using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WWW.Controllers
{
    public class ByCountryController : Controller
    {
        //
        // GET: /ByCountry/

        public ActionResult Index(string code)
        {
            if (code == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View();
            }
            
        }

    }
}
