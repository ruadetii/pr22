using MySql.Data.MySqlClient;
using Shop_Radosteva.Data.Common;
using Shop_Radosteva.Data.Interfaces;
using Shop_Radosteva.Data.Models;

namespace Shop_Radosteva.Data.DataBase
{
    public class DBCategory : ICategorys
    {
        public IEnumerable<Categories> AllCategories 
        {
            get 
            {
                List<Categories> categories = new List<Categories>();
                MySqlConnection connection = Connection.OpenConnection();
                MySqlDataReader data = Connection.Query("SELECT * FROM `Categories` ORDER BY `Name`;", connection);
                while (data.Read()) 
                {
                    categories.Add(new Categories() 
                    {
                        Id = data.IsDBNull(0) ? -1 : data.GetInt32(0),
                        Name = data.IsDBNull(1) ? null : data.GetString(1),
                        Description = data.IsDBNull(2) ? null : data.GetString(2)
                    });
                }

                return categories;
            }
        }
    }
}
