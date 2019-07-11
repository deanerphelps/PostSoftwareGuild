using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicTacToeGOTY.Models.Home;

namespace TicTacToeGOTY.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChooseGame(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return RedirectToAction("Index", "Home");
            }

            else if (name.Length > 18)
            {
                return RedirectToAction("Index", "Home");
            }

            ChooseGameResponse chooseGameResponse = new ChooseGameResponse();
            {
                chooseGameResponse.Name = name;
            }
            return View(chooseGameResponse);
        }
    }
}