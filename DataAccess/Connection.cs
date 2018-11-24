using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Connection
    {
        private string MysqlconnectionString = "server = 127.0.0.1; uid = root; pwd=desarroll0;database=tecsupdb";
        public async Task<MySqlConnection> OpenConnection()
        {
            try
            {
                MySqlConnection mysqlConnection = new MySqlConnection(this.MysqlconnectionString);
                
                    if (mysqlConnection.State == System.Data.ConnectionState.Open)
                        return mysqlConnection;
                    else
                    {
                        await mysqlConnection.OpenAsync();
                        return mysqlConnection;
                    }
                
            }
            catch {
                return null;
            }
        }
 
    }
}
