using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace APIAutomation_SpecFlow.Drivers
{
    public class DBDriver
    {
        public static int SqlTestData()
        {
            var config_json = new ConfigurationBuilder().AddJsonFile("Resources/queryconfig.json").Build();
            var sql = config_json.GetSection("Sales_config")["Count_Sales"];
            string constr = @" Server = localhost; Database = AdventureWorks2019; Trusted_Connection = True";
            int count = 0;
            using (SqlConnection connection = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand(sql, connection);
                connection.Open();
                count = (Int32)cmd.ExecuteScalar();
                connection.Close();
            }
            return count;
        }
        
    }
}
