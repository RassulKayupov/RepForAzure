using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RK_WebApplicationForAzure.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }
        public List<string> Row { get; set; } = new List<string>();

        public void OnGet()
        {
            const string connectionString =
                "Server=tcp:rkazuredb.database.windows.net,1433;Initial Catalog=northwind;Persist Security Info=False;User ID=rassul_kayupov;Password=Hfcek0612+;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            using (var connection = new SqlConnection(connectionString))
            {
                var query = "select * from orders";
                var command = connection.CreateCommand();
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var row = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row += reader[i] + "; ";
                        }
                        Row.Add(row);
                    }
                }
            }

            Message = "Your application description page.";
        }


    }
}
