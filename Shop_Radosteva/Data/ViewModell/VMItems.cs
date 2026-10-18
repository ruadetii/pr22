using Shop_Radosteva.Data.Models;

namespace Shop_Radosteva.Data.ViewModell
{
    public class VMItems
    {
        public IEnumerable<Items> Items { get; set; }
        public IEnumerable<Categories> Categories { get; set; }
        public int SelectCategory = 0;

    }
}
