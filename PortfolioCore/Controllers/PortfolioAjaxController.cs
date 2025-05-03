using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioCore.Context;
using PortfolioCore.Entities;

namespace PortfolioCore.Controllers
{
    public class PortfolioAjaxController:Controller
    {
        PortfolioContext context = new PortfolioContext();

        [HttpGet]
        public IActionResult GetPortfolioByCategory(string category)
        {
            if (string.IsNullOrEmpty(category) || category.ToLower() == "all")
            {
                var allItems = context.Portfolios.Include(x => x.Category).ToList();
                return PartialView("~/Views/Shared/Components/_DefaultPortfolioItemComponentPartial/Default.cshtml", allItems);
            }

            var values = context.Portfolios
                                .Include(x => x.Category)
                                .Where(x => x.Category.CategoryName.ToLower() == category.ToLower())
                                .ToList();

            return PartialView("~/Views/Shared/Components/_DefaultPortfolioItemComponentPartial/Default.cshtml", values);
        }
    }
}
