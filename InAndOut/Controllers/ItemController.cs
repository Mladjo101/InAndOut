﻿using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
            return View(objList);
        }
        //GET - uzima
		public IActionResult Create()
		{
			return View();
		}
        //POST - salje
        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Create(Item obj)
		{
            _db.Items.Add(obj);
            _db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
