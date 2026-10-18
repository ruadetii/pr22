using Shop_Radosteva.Data.Models;

namespace Shop_Radosteva.Data.Interfaces
{
    public interface IItems
    {
        public IEnumerable<Items> AllItems { get; }
        public int Add(Items Item);
    }
}
