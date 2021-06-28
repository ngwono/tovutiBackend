using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using TovutiBackend.Files;
using Microsoft.Win32;

namespace TovutiBackend.Databases
{
    public class DatabaseConnection
    {

        //Azure Hosted Server
        private string serverName = @"cafomadsqlserver.database.windows.net,1433";
        private string databaseName = "TOVUTIDB";
        private string password = "camilla@2021";
        private string userName = "mark";

        public DatabaseConnection()//
        {
            queryCounter = 0;
            now = DateTime.Now.ToLocalTime().ToString();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Constants.Constant.APP_NAME);
            // if it does exist, retrieve stored values
            if (key != null)
            {
                this.serverName = "" + key.GetValue("server_name");
                this.databaseName = "" + key.GetValue("database");
                this.userName = "" + key.GetValue("username");
                this.password = "" + key.GetValue("password");
                key.Close();
            }
            if (sqlConnection != null)
            {
                close();
            }
            else
            {

            }
            this.serverName = @"cafomadsqlserver.database.windows.net,1433";//serverName;
            this.databaseName = "TOVUTIDB";// databaseName;
            this.userName = "mark";
            this.password = "camilla@2021";
            connect();

        }

        private string now = DateTime.Now.ToLongTimeString().ToString();
        private SqlConnection sqlConnection = null;
        public string connectionString = "";
        private SqlCommand sqlCommand = null;
        private SqlTransaction sqlTransaction = null;
        int queryCounter = 0;
        private SqlDataReader sqlDataReader = null;

        public void connect()
        {
            if (sqlConnection != null)
            {
                close();
            }
            else
            {

            }
            connectionString = "Data Source=" + this.serverName + ";" + "Initial Catalog=" + this.databaseName + ";; user id=" + this.userName + "; password=" + this.password + ""; sqlConnection = new SqlConnection(connectionString);
            Open();

        }
        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
        public SqlTransaction GetTransaction()
        {
            return sqlTransaction;
        }
        public void beginTransaction()
        {
            sqlTransaction = sqlConnection.BeginTransaction();
        }
        public void queryCommand(string sql)
        {
            queryCounter++;
            sqlCommand = new SqlCommand(sql);
            sqlCommand.Connection = sqlConnection;
            if (sqlTransaction != null)
                sqlCommand.Transaction = sqlTransaction;
        }
        public SqlCommand createQueryCommand(string sql)
        {
            queryCounter++;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            if (sqlTransaction != null)
                sqlCommand.Transaction = sqlTransaction;
            return sqlCommand;
        }
        public void commandTransaction()
        {
            if (sqlTransaction != null)
                sqlCommand.Transaction = sqlTransaction;
        }
        public SqlDataReader query()
        {
            sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                return sqlDataReader;
            }
            return null;
        }
        public SqlDataReader query(SqlCommand sqlCommand)
        {
            sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                return sqlDataReader;
            }
            return null;
        }
        public SqlCommand createUpdateCommand(string sql)
        {
            queryCounter++;
            SqlCommand sqlCommand = new SqlCommand(sql);
            sqlCommand.Connection = sqlConnection;
            if (sqlTransaction != null)
                sqlCommand.Transaction = sqlTransaction;

            return sqlCommand;
        }
        public void updateCommand(string sql)
        {
            queryCounter++;
            sqlCommand = new SqlCommand(sql);
            sqlCommand.Connection = sqlConnection;
            if (sqlTransaction != null)
                sqlCommand.Transaction = sqlTransaction;
        }

        public int insertId()
        {

            try
            {
                var es = sqlCommand.ExecuteScalar();
                new LogFileEngine(Constants.Constant.DIR_LOGS).writeToFile("Insert Id : " + es);
                return es == null ? 0 : (int)(es);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public int getInsertId(SqlCommand sqlCommand)
        {
            var es = sqlCommand.ExecuteScalar();
            return es == null ? 0 : (int)(es);
        }

        public void commit()
        {
            if (sqlTransaction != null)
                sqlTransaction.Commit();
        }
        public void rollback()
        {
            if (sqlTransaction != null) sqlTransaction.Rollback();
        }
        public void addValue(string parameter, bool value)
        {

            sqlCommand.Parameters.AddWithValue(parameter, value);
        }
        public void addValue(string parameter, DBNull value)
        {

            sqlCommand.Parameters.AddWithValue(parameter, value);
        }
        public void addValue(SqlCommand sqlCommand, string parameter, bool value)
        {

            sqlCommand.Parameters.AddWithValue(parameter, value);
        }

        public void addValue(string parameter, string value)
        {

            sqlCommand.Parameters.AddWithValue(parameter, value);
        }
        public void addValue(SqlCommand sqlCommand, string parameter, string value)
        {

            sqlCommand.Parameters.AddWithValue(parameter, value);
        }

        public void addValue(string parameter, decimal value)
        {

            sqlCommand.Parameters.AddWithValue(parameter, value);
        }
        public void addValue(SqlCommand sqlCommand, string parameter, decimal value)
        {

            sqlCommand.Parameters.AddWithValue(parameter, value);
        }
        public void Open()
        {
            sqlConnection.Open();
        }

        public bool update()
        {
            int k = 0;
            try
            {
                k = sqlCommand.ExecuteNonQuery();


            }
            catch (Exception e)
            {
                close();
                e.ToString();

                rollback();
                return false;

            }
            return k > 0;
        }
        public void close()
        {
            sqlConnection.Close();
        }
    }
}