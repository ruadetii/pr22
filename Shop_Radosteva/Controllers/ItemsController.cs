using Microsoft.AspNetCore.Mvc;
using Shop_Radosteva.Data.Interfaces;
using Shop_Radosteva.Data.Models;
using Shop_Radosteva.Data.ViewModell;

namespace Shop_Radosteva.Controllers
{
    public class ItemsController : Controller
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;
        private IItems IAllItems;
        private ICategorys IAllCategories;
        VMItems VMItems = new VMItems();

        public ItemsController(IItems IAllItems, ICategorys IAllCategories, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            this.IAllItems = IAllItems;
            this.IAllCategories = IAllCategories;
            this.hostingEnvironment = hostingEnvironment;
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

        [HttpPost]
        public RedirectResult Add(string name, string description, IFormFile files, float price, int idCategory) 
        {
            if (files != null) 
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, files.FileName);
                files.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            Items newItems = new Items();
            newItems.Name = name;
            newItems.Description = description;
            newItems.Img = files.FileName;
            newItems.Price = Convert.ToInt32(price);
            newItems.Category = new Categories() { Id = idCategory };

            int id = IAllItems.Add(newItems);

            return Redirect("/Items/Update?id=" + id);
        }
    }
}
