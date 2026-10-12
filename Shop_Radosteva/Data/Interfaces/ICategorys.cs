using Shop_Radosteva.Data.Models;

namespace Shop_Radosteva.Data.Interfaces
{
    public interface ICategorys
    {
        public IEnumerable<Categories> AllCategories { get; }
    }
}
