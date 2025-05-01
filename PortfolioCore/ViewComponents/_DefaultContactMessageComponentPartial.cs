using Microsoft.AspNetCore.Mvc;
using PortfolioCore.Context;

namespace PortfolioCore.ViewComponents
{
    public class _DefaultContactMessageComponentPartial:ViewComponent
    {
        PortfolioContext context = new PortfolioContext();  
        public IViewComponentResult Invoke()
        {
            //var value = context.Contacts.FirstOrDefault();
            return View();  
        }
    }
}
