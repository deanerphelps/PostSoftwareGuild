using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicTacToeRemix.Models;

namespace TicTacToeRemix.Controllers
{
    public class GamesController : Controller
    {
        [HttpGet]
        public ActionResult GetName()
        {
            Player player = new Player();
            player.Name = Request.QueryString["name"];
            player.Option = Request.QueryString["option"];
            return View("TicTacToe", player);
        }

        [HttpGet]
        public ActionResult TicTacToe()
        {
            Player player = new Player();
            player.Name = "Dean";
            player.Option = "X";
            return View("TicTacToe", player);
        }
    }
}