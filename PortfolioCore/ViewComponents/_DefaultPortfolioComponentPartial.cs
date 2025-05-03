using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PortfolioCore.Context;

namespace PortfolioCore.ViewComponents
{
    public class _DefaultPortfolioComponentPartial:ViewComponent
    {
        PortfolioContext context = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = context.Categories.ToList();
            return View(values);
        }
    }
}
