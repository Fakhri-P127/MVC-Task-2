using Microsoft.AspNetCore.Mvc;
using MVC_Task_2.DAL;
using MVC_Task_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Task_2.Controllers
{
    public class HomeController:Controller
    {
        private readonly AppDbContext _options;
        public HomeController(AppDbContext options)
        {
            _options = options;
        }
        public IActionResult Index()
        {
            List<Card> cards= _options.Cards.ToList();
            return View(cards);
            //TempData["Link"] = cards;
            //return RedirectToAction("Details");
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Card card = _options.Cards.FirstOrDefault(i=>i.Id== id);
            return View(card);

        }
    }
}
