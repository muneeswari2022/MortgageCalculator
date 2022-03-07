using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MortgageCalculator.Dto;
using MortgageCalculator.Web.Services;

namespace MortgageCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        IMortgageService MortgageService;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MortgageList()
        {
            Mortgage mortgagedto = new Mortgage();
            MortgageService = new MortgageService();
            var Mortgage_List = MortgageService.GetAllMortgages();
            return View(Mortgage_List);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Mortgage ObjMortgage)
        {
            try
            {
                MortgageService = new MortgageService();
                MortgageService.SaveMortage(ObjMortgage);
                return View(ObjMortgage);
            }
            catch (Exception ex)
            {
                return Json(new { msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}