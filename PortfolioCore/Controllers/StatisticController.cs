using Microsoft.AspNetCore.Mvc;
using PortfolioCore.Context;

namespace PortfolioCore.Controllers
{
    public class StatisticController : Controller
    {
        PortfolioContext context = new PortfolioContext();
        public IActionResult Index()
        {
            ViewBag.v1 = context.Skills.Count();
            ViewBag.v2 = context.Skills.Sum(x=>x.SkillValue);
            ViewBag.v3 = context.Skills.Where(x=>x.SkillValue>=70).Count();
            ViewBag.v4 = context.Skills.Average(x=>x.SkillValue);
            return View();
        }
    }
}
