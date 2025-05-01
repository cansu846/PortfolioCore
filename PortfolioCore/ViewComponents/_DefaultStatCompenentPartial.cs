using Microsoft.AspNetCore.Mvc;

namespace PortfolioCore.ViewComponents
{
    public class _DefaultStatCompenentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            Random rnd = new Random();

            ViewBag.v1 = rnd.Next(10, 20);
            ViewBag.v2 = rnd.Next(10, 20);
            ViewBag.v3 = rnd.Next(10, 20);
            ViewBag.v4 = rnd.Next(10, 20);

            return View();
        }
    }
}
