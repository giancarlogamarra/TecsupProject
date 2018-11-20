﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Connection
    {
        private string MysqlconnectionString = "server = 127.0.0.1; uid = root; pwd=desarroll0;database=tecsupdb";
        public MySqlConnection OpenConnection()
        {
            try
            {
                using (MySqlConnection mysqlConnection = new MySqlConnection(this.MysqlconnectionString))
                {
                    if (mysqlConnection.State == System.Data.ConnectionState.Open)
                        return mysqlConnection;
                    else
                    {
                        mysqlConnection.Open();
                        return mysqlConnection;
                    }
                }
            }
            catch {
                return null;
            }
        }
 
    }
}
