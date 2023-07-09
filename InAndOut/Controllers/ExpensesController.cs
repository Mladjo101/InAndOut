using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InAndOut.Controllers
{
	public class ExpensesController : Controller
	{

		private readonly ApplicationDbContext _db;

		public ExpensesController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<Expense> objList = _db.Expenses;
			return View(objList);
		}

		//GET
        public IActionResult Create()
		{
			return View();
		}
		//POST CREATE
		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Create(Expense obj)
		{
			if(ModelState.IsValid)
			{
				_db.Expenses.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}


		//GET DELETE

		public IActionResult Delete(int? id)
		{

			if(id == null || id==0)
			{
				return NotFound();
			}

			var obj = _db.Expenses.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);

		}

		//POST DELETE
		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult DeletePost(int? id)
		{
			var obj = _db.Expenses.Find(id);
			if(obj == null) { 
				return NotFound();
			}
			
			
				_db.Expenses.Remove(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			
		}

		//GET Update

		public IActionResult Update(int? id)
		{

			if (id == null || id == 0)
			{
				return NotFound();
			}

			var obj = _db.Expenses.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			return View(obj);

		}

		//POST UPDATE
		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult Update(Expense obj)
		{
			if (ModelState.IsValid)
			{
				_db.Expenses.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}

	}
}
