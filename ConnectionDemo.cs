using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace ConsoleApplicationAdo.net
{
    class ConnectionDemo
    {
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            ConnectionDemo.dataBaseConnection();
        }
        /// <summary>
        /// dataBaseConnection method is creating for DataBase connection and retrive data form DataBase 
        /// </summary>
        public static void  dataBaseConnection()
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(ConnectionDemo));
            log.Info("Retrive Data from DataBase Employee");
            log.Info("===========================");
            string SqlQry = "Select  * from Employee";
            string constring = @"Data Source=.\AnkitSQL;Initial Catalog=Customer;Persist Security Info=True;User ID=sa;Password=125817865";
            SqlConnection con = new SqlConnection(constring);
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
            con.Close();

        }



      }
        

}
    

