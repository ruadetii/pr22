using Microsoft.AspNetCore.Mvc;
using Shop_Radosteva.Data.Interfaces;

namespace Shop_Radosteva.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategorys IAllCategories;

        public ItemsController(IItems IAllItems, ICategorys IAllCategories)
        {
            this.IAllItems = IAllItems;
            this.IAllCategories = IAllCategories;
        }

        public ViewResult List() 
        {
            ViewBag.Title = "Страница с предметами";

            var cars = IAllItems.AllItems;
            return View(cars);
        }
    }
}
