using Microsoft.AspNetCore.Mvc;
using PortfolioCore.Context;

namespace PortfolioCore.ViewComponents
{
    public class _DefaultProjectComponentPartial:ViewComponent
    {
        PortfolioContext context=new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values=context.Portfolios.ToList();
            return View(values);
        }
    }
}
