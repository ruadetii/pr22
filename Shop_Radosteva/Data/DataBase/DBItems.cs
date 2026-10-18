using MySql.Data.MySqlClient;
using Shop_Radosteva.Data.Common;
using Shop_Radosteva.Data.Interfaces;
using Shop_Radosteva.Data.Models;

namespace Shop_Radosteva.Data.DataBase
{
    public class DBItems : IItems
    {
        public IEnumerable<Categories> AllCategories = new DBCategory().AllCategories;
        public IEnumerable<Items> AllItems 
        {
            get 
            {
                List<Items> items = new List<Items>();
                MySqlConnection connection = Connection.OpenConnection();
                MySqlDataReader data = Connection.Query("SELECT * FROM `Items` ORDER BY `Name`;", connection);
                while (data.Read())
                {
                    items.Add(new Items()
                    {
                        Id = data.IsDBNull(0) ? -1 : data.GetInt32(0),
                        Name = data.IsDBNull(1) ? "" : data.GetString(1),
                        Description = data.IsDBNull(2) ? "" : data.GetString(2),
                        Img = data.IsDBNull(3) ? "" : data.GetString(3),
                        Price = data.IsDBNull(4) ? -1 : data.GetInt32(4),
                        Category = data.IsDBNull(5) ? null : AllCategories.Where(x => x.Id == data.GetInt32(5)).First()
                    });
                }
                Connection.CloseConnection(connection);
                return items;
            }
        }

        public int Add(Items Item)
        {
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query($"INSERT INTO `Items` (`Name`, `Description`, `Img`, `Price`, `IdCategory`) VALUES ('{Item.Name}', '{Item.Description}', '{Item.Img}', {Item.Price}, {Item.Category.Id});", connection);
            Connection.CloseConnection(connection);

            int IdItem = -1;
            connection = Connection.OpenConnection();
            MySqlDataReader data = Connection.Query($"SELECT `Id` FROM `Items` WHERE `Name` = '{Item.Name}' AND `Description` = '{Item.Description}' AND `Price` = {Item.Price} AND `IdCategory` = {Item.Category.Id};", connection);
            if (data.HasRows) 
            {
                data.Read();
                IdItem = data.GetInt32(0);
            }
            Connection.CloseConnection(connection);
            return IdItem;
        }
    }
}
