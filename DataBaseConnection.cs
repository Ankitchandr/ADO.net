using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationAdo.net
{
    class DataBaseConnection
    {
        /// <summary>
        /// This is starting point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            DataBaseConnection.dbConnection();
        }

        /// <summary>
        /// dbConnection() is creating for database connection using try/catch
        /// </summary>
        public static void dbConnection()
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(DataBaseConnection));
            string SqlQry = "Select  * from Employee where age = 32";
            string constring = @"Data Source=.\AnkitSQL;Initial Catalog=Customer;Persist Security Info=True;User ID=sa;Password=125817865";
            SqlConnection con = new SqlConnection(constring);
            try
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
            catch (SqlException e)
            {
                log.Error(e.Message);
            }

            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            finally
            {
                con.Close();
            }
          

        }
    }
}
