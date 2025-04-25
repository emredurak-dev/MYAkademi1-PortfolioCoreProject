using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortfolioCore.Context;
using PortfolioCore.Entities;

namespace PortfolioCore.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioContext context = new PortfolioContext();
        public IActionResult PortfolioList()
        {
            var values = context.Portfolios.Include(x => x.Category).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreatePortfolio()
        {
            var values = new SelectList(context.Categories.ToList(), "CategoryId", "CategoryName");
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult CreatePortfolio(Portfolio portfolio)
        {
            context.Portfolios.Add(portfolio);
            context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

        public IActionResult DeletePortfolio(int id)
        {
            var values = context.Portfolios.Find(id);
            context.Remove(values);
            context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }

        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            var values = context.Portfolios.Include(x => x.Category).FirstOrDefault(p => p.PortfolioId == id);
            var values2 = new SelectList(context.Categories.ToList(), "CategoryId", "CategoryName");
            ViewBag.v = values2;
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
            context.Portfolios.Update(portfolio);
            context.SaveChanges();
            return RedirectToAction("PortfolioList");
        }
    }
}
