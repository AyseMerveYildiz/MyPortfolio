using Microsoft.AspNetCore.Mvc;
using MyPortfolio.DAL.Context;

namespace MyPortfolio.Controllers
{
    public class DashboardController : Controller
    {
        MyPortfolioContext context=new MyPortfolioContext();
        public IActionResult Index()
        {
			ViewBag.toDoListCount = context.ToDoLists.Count();
			ViewBag.doneToDoList = context.ToDoLists.Where(x => x.Status == true).Count();
			ViewBag.unDoneToDoList = context.ToDoLists.Where(x => x.Status == false).Count();
			ViewBag.skillCount = context.Skills.Count();
			ViewBag.messageCount = context.Messages.Count();
			ViewBag.readMessage = context.Messages.Where(x => x.IsRead == true).Count();
			ViewBag.unReadMessage = context.Messages.Where(x => x.IsRead == false).Count();

			ViewBag.portfolioCount = context.Portfolios.Count();
			ViewBag.testimonialCount = context.Testimonials.Count();

			var values = context.Skills.ToList();
			return View(values);
		}
    }
}
