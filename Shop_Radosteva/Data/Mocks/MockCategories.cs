using Shop_Radosteva.Data.Interfaces;
using Shop_Radosteva.Data.Models;

namespace Shop_Radosteva.Data.Mocks
{
    public class MockCategories : ICategorys
    {
        public IEnumerable<Categories> AllCategories 
        {
            get 
            {
                return new List<Categories>
                {
                    new Categories() 
                    {
                        Id = 0,
                        Name = "Электрочайники",
                        Description = "Бытовые приборы для быстрого нагрева и кипячения воды с помощью встроенного нагревательного элемента."
                    },
                    new Categories() 
                    {
                        Id = 1,
                        Name = "Утюги",
                        Description = "Бытовые электроприборы, предназначенные для разглаживания складок и заломов на ткани с помощью нагрева и пара."
                    }
                };
            }
        }
    }
}
