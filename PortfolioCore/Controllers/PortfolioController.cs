using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioCore.Context;
using PortfolioCore.Entities;

namespace PortfolioCore.Controllers
{
    [Route("/[controller]/[action]")]
    public class PortfolioController : Controller
    {
        PortfolioContext context = new PortfolioContext();
        public IActionResult PortfolioList()
        {
            var values = context.Portfolios.Include(x=>x.Category).ToList().Take(6);
            return View(values.ToList());
        }

        [HttpGet]
        public IActionResult CreatePortfolio()
        {
            
            var values = new SelectList(context.Categories.ToList(),"CategoryId", "CategoryName");
            ViewBag.v = values; 
            return View();
        }

        [HttpPost]
        public IActionResult CreatePortfolio(Portfolio p)
        {
            context.Portfolios.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
