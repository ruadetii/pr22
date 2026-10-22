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
            newItems.Img = "/img/" + Path.GetFileName(files.FileName);
            newItems.Price = Convert.ToInt32(price);
            newItems.Category = new Categories() { Id = idCategory };

            int id = IAllItems.Add(newItems);

            return Redirect("/Items/Update?id=" + id);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = IAllItems.AllItems.FirstOrDefault(x => x.Id == id);
            ViewBag.Categories = IAllCategories.AllCategories;
            return View(item);
        }

        [HttpPost]
        public IActionResult Update(int id, string name, string description, IFormFile file, float price, int idCategory)
        {
            var existingItem = IAllItems.AllItems.FirstOrDefault(x => x.Id == id);
            if (existingItem == null) return NotFound();

            if (file != null && file.Length > 0)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                Directory.CreateDirectory(uploads);
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(uploads, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                existingItem.Img = "/img/" + fileName;
            }

            existingItem.Name = name;
            existingItem.Description = description;
            existingItem.Price = Convert.ToInt32(price);
            existingItem.Category = new Categories() { Id = idCategory };

            IAllItems.Update(existingItem);

            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            IAllItems.Delete(id);
            return RedirectToAction("List");
        }

        public ActionResult Basket(int idItem = -1) 
        {
            if (idItem != -1) 
            {
                Program.BasketItem.Add(new ItemsBasket(1, IAllItems.AllItems.Where(x => x.Id == idItem).First()));
            }
            return Json(Program.BasketItem);
        }
    }
}
