using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace MyStore.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();


        public void OnGet()
        {
            try
            {
                //Console.WriteLine("Im here");
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=MySariSariStore;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        
                        Debug.WriteLine("Connection successful");
                    }
                    String sql = "SELECT * FROM Clients";
                    //Console.WriteLine(sql);
                    using SqlCommand command = new(sql, connection);
                    using SqlDataReader reader = command.ExecuteReader();

                    

                    while (reader.Read())
                    {

                        ClientInfo clientInfo = new ClientInfo();
                        clientInfo.id = "" + reader.GetInt32(0);
                        clientInfo.name = reader.GetString(1);
                        clientInfo.email = reader.GetString(2);
                        clientInfo.phone = reader.GetString(3);
                        clientInfo.address = reader.GetString(4);
                        clientInfo.created_at = reader.GetDateTime(5).ToString();
                        listClients.Add(clientInfo);
                        Console.WriteLine(clientInfo.id);
                        Console.WriteLine(clientInfo.name);
                        Console.WriteLine(clientInfo.name);
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception " + ex.ToString());
                // throw;
            }

        }
    }

    public class ClientInfo
    {
        public String id;
        public String name;
        public String email;
        public String phone;
        public String address;
        public String created_at;
        public bool connectedSuccess { get; set; }
    }

}
