using System.Data.SqlClient;
using System.Linq;
using Dapper;
using static IFlow.Testing.Utils.DataFactory.DataBase;

namespace IFlow.Testing.Utils.DataBase
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Key { get; set; }
        public string Header { get; set; }

        public User(string key = "", string header = "")
        {
            Key = key;
            Header = header;
        }

        public static void UpdateEmailConformationForAccepted(string userId)
        {
            var sql = "Input your SQL query";
            using var connection = new SqlConnection(DataBaseConnectionString);
            connection.Open();
            var firstOrDefault = connection.Query<string>(sql).FirstOrDefault();
        }
    }
}
