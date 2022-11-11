using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _context.Item.ToList();
            return View("Index", model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(Models.Item item)
        {
            _context.Item.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var item = _context.Item.FirstOrDefault(e => e.Id == Id);
            _context.Item.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
