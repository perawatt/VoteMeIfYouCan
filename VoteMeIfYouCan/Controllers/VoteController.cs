using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VoteMeIfYouCan.Controllers
{
    public class VoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Topics()
        {
            return View();
        }
        public IActionResult AddTopic()
        {
            return View();
        }
        public IActionResult VoteChoice()
        {
            return View();
        }
        public IActionResult ViewVoted()
        {
            return View();
        }
        public IActionResult AddChoice()
        {
            return View();
        }
    }
}