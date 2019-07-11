using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicTacToeGOTY.Models.Home;

namespace TicTacToeGOTY.Controllers
{
    public class RockPaperScissorsController : Controller
    {
        // GET: RockPaperScissors
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PlayGame(string name)
        {
            if (name.Length > 18)
            {
                return RedirectToAction("Index", "Home");
            }
            ChooseGameResponse chooseGameResponse = new ChooseGameResponse()
            {
                Name = name
            };

            return View(chooseGameResponse);
        }
    }
}