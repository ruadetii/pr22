using Shop_Radosteva.Data.Interfaces;
using Shop_Radosteva.Data.Models;

namespace Shop_Radosteva.Data.Mocks
{
    public class MockItems : IItems
    {
        public ICategorys _category = new MockCategories();

        public IEnumerable<Items> AllItems 
        {
            get 
            {
                return new List<Items>()
                {
                    new Items() {
                        Id = 0,
                        Name = "Электрочайник Aceline SS1800 серебристый",
                        Description = "Электрочайник Aceline SS1800 с серебристым корпусом из нержавеющей стали вмещает до 1.8 л воды и быстро доводит ее до кипения благодаря закрытому нагревательному элементу из нержавеющей стали с потребляемой мощностью 1500 Вт.",
                        Img = "https://c.dns-shop.ru/thumb/st1/fit/500/500/b925c165931a83a4b89b446f6548ecb7/6859add5fe77ce5f55d53b735d4463a1cdf03d8a23082ab5b07eeb5a46dd1835.jpg.webp",
                        Price = 650,
                        Category = _category.AllCategories.Where(x => x.Id == 0).First()
                    },
                    new Items() {
                        Id = 1,
                        Name = "Электрочайник Xiaomi Electric Glass Kettle черный",
                        Description = "Электрочайник Xiaomi Electric Glass Kettle объемом 1.7 л обладает фильтрующий элементом, который поглощает посторонние примеси и препятствует попаданию в чашку с напитком. ",
                        Img = "https://c.dns-shop.ru/thumb/st4/fit/500/500/7f1200c25499d26c4b611a66c3d7c265/78247b1c5ef37719965292540388de21655d2c1475faa636d0f8029b89f9a3d0.jpg.webp",
                        Price = 1999,
                        Category = _category.AllCategories.Where(x => x.Id == 0).First()
                    },
                    new Items() {
                        Id = 2,
                        Name = "Утюг DEXP HH2200BS фиолетовый",
                        Description = "Утюг DEXP HH2200BS представляет собой мощное устройство, с которым процесс глажения станет легким и быстрым. Обладая мощностью 2200 Вт, прибор поддерживает паровой удар, позволяющий избавиться от любых складок, даже очень глубоких, за считанные секунды.",
                        Img = "https://c.dns-shop.ru/thumb/st1/fit/500/500/2608ed6dffe11f958fa8f8198ac021fa/c28def1a5d97f1339acd656effdc9df4e5ebaf9cf9e75be14638d32ba999cf64.jpg.webp",
                        Price = 1199,
                        Category = _category.AllCategories.Where(x => x.Id == 1).First()
                    },
                    new Items() {
                        Id = 3,
                        Name = "Утюг Braun SI9682DB синий",
                        Description = "Синий утюг Braun SI9682DB оснащен алюминиевой подошвой EloxalPlus 3D FreeGlide, которая отличается быстрым нагревом и остыванием, а также легким скольжением по разным типам тканей. Паровой удар со скоростью 260 г/мин позволяет разглаживать сильные складки и работать с плотными материалами. ",
                        Img = "https://c.dns-shop.ru/thumb/st1/fit/500/500/8ca90124acfdf28925eddff1ea9b7c3b/e6f34cdbebf87346e49a614ac250633ca20ded753d8dfb4c87a858c0fd4d2862.jpg.webp",
                        Price = 8999,
                        Category = _category.AllCategories.Where(x => x.Id == 1).First()
                    }
                };
            }    
        }
    }
}
