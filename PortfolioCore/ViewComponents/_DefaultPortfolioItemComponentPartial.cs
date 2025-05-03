using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioCore.Context;
using PortfolioCore.Entities;

namespace PortfolioCore.ViewComponents
{
    public class _DefaultPortfolioItemComponentPartial:ViewComponent
    {
        PortfolioContext context = new PortfolioContext();
        //public IViewComponentResult Invoke()
        //{
        // var values = context.Portfolios.Include(x=>x.Category).ToList();
        //    return View(values);
        //}

        public async Task<IViewComponentResult> InvokeAsync(string category = null)
        {
            List<Portfolio> items;

            if (string.IsNullOrEmpty(category) || category == "all")
                items = context.Portfolios.Include(x=>x.Category).ToList();
            else
                items = context.Portfolios.Include(x=>x.Category).Where(x=>x.Category.CategoryName.ToLower()==category.ToLower()).ToList();

            return View("Default", items); // Views/Shared/Components/DefaultPortfolioItem/Default.cshtml
        }
    }
}
