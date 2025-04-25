using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioCore.Context;
using PortfolioCore.Entities;

namespace PortfolioCore.ViewComponents
{
    public class _DefaultPortfolioComponentPartial : ViewComponent
    {
        PortfolioContext context = new PortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = context.Portfolios.ToList();
            return View(values);
        }

        public IViewComponentResult GetProjectWithCategory(int id)
        {
            var values=context.Portfolios.Include(p => p.Category).Where(p=>p.CategoryId==id).ToList();
            return View(values);
        }
    }
}
