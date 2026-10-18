using Microsoft.AspNetCore.Mvc;
using Shop_Radosteva.Data.Interfaces;
using Shop_Radosteva.Data.Models;
using Shop_Radosteva.Data.ViewModell;

namespace Shop_Radosteva.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategorys IAllCategories;
        VMItems VMItems = new VMItems();

        public ItemsController(IItems IAllItems, ICategorys IAllCategories)
        {
            this.IAllItems = IAllItems;
            this.IAllCategories = IAllCategories;
        }

        public ViewResult List(int id = 0) 
        {
            ViewBag.Title = "Страница с предметами";

            VMItems.Items = IAllItems.AllItems;
            VMItems.Categories = IAllCategories.AllCategories;
            VMItems.SelectCategory = id;
            return View(VMItems);
        }

        [HttpGet]
        public ViewResult Add() 
        {
            IEnumerable<Categories> Categories = IAllCategories.AllCategories;

            return View(Categories);
        }
    }
}
