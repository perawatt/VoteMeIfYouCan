﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAC;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;
using Biz;

namespace VoteMeIfYouCan.Controllers
{
    public class VoteController : Controller
    {
        public IActionResult Index()
        {
            var a = new VoteBiz();
            return View();
        }
        public IActionResult Topics()
        {
            return View();
        }
        public async Task<IActionResult> AddTopic()
        {
            var svc = new VoteDAC();
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