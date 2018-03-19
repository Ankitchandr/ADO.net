using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApplicationAdo.net
{
    class throughUsingDbConnection
    {
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            throughUsingDbConnection.connectionThroughUsing();
        }
        /// <summary>
        /// connectionThroughUsing() is creating for connection through using
        /// </summary>
        public static void connectionThroughUsing()
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(throughUsingDbConnection));
            string SqlQry = "Select  * from Employee where age > 25";
            string constring = @"Data Source=.\AnkitSQL;Initial Catalog=Customer;Persist Security Info=True;User ID=sa;Password=125817865";
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(SqlQry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    log.Info("FirstName:=" + reader[0].ToString());
                    log.Info("LastName:=" + reader[1].ToString());
                    log.Info("Age:=" + reader[2].ToString());
                    log.Info("===========================");
                }
                Console.Read();
            } 
        }
    }
}
