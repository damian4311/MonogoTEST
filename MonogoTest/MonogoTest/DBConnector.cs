using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogoTest
{
    enum ConnectionResult
    {
        Error = 0,
        DbCreated = 1,
        Ok = 2,
        SetConnString = 3

    }
    class DBConnector
    {
        public static string ConnectionString;
        public ConnectionResult InitConnection(out string message)
        {
            ConnectionResult result = ConnectionResult.Ok;
            message = "";
            
            if (string.IsNullOrEmpty(DBConnector.ConnectionString))
            {
                result = ConnectionResult.Error;
                message = "Set ConnectionString";
                return result;
            }

            SqlConnectionStringBuilder connStrBuilder = new SqlConnectionStringBuilder(DBConnector.ConnectionString);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connStrBuilder.ConnectionString;//  "Server=\"localhost\\SQL2012\";Integrated Security = true;Database=\"DADADA\"";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                if ((ex as SqlException).Number == 4060)
                {
                    try
                    {
                        CreateDB( new SqlConnectionStringBuilder(connStrBuilder.ConnectionString));
                        result = ConnectionResult.DbCreated;
                        message = "Database "+ connStrBuilder.InitialCatalog + " Created";
                    }
                    catch (Exception ex2)
                    {
                        result = ConnectionResult.Error;
                        message = "Connection error " + ex2.Message;       
                    }
                    
                }
            }
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.CommandText = "CREATE DATABASE TESTM";
            //sqlCommand.Connection = conn;
            //sqlCommand.ExecuteNonQuery();

            return result;
            //conn.Close();

        }

        private void CreateDB(SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            string dbName = sqlConnectionStringBuilder.InitialCatalog;
            sqlConnectionStringBuilder.InitialCatalog = "";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = sqlConnectionStringBuilder.ConnectionString;
            conn.Open();
            SqlCommand createCommand = new SqlCommand();
            createCommand.CommandText = "CREATE DATABASE " + dbName;
            
            createCommand.Connection = conn;
            createCommand.ExecuteNonQuery();
            SqlCommand createTableCommand = new SqlCommand();
            createTableCommand.CommandText += @" SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    CREATE TABLE[dbo].[Price](

                        [Id][int] IDENTITY(1, 1) NOT NULL,

                        [Net] [decimal](5, 2) NULL,
	                    [Tax] [int] NULL,
                     CONSTRAINT[PK_Price] PRIMARY KEY CLUSTERED
                    (
                       [Id] ASC
                    )WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
                    ) ON[PRIMARY]

                    /****** Object:  Table [dbo].[Product]    Script Date: 13.08.2019 18:24:37 ******/
                    SET ANSI_NULLS ON
                    SET QUOTED_IDENTIFIER ON
                    CREATE TABLE[dbo].[Product]
                            (

                       [Id][int] IDENTITY(1,1) NOT NULL,

                      [name] [varchar] (20) NOT NULL,

                       [ean] [numeric] (18, 2) NOT NULL,
                     CONSTRAINT[PK_Product] PRIMARY KEY CLUSTERED
                    (
                       [Id] ASC
                    )WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
                    ) ON[PRIMARY]

                    ALTER TABLE[dbo].[Price] ADD CONSTRAINT[DF_Price_Net]  DEFAULT((0.00)) FOR[Net]
                    ALTER TABLE[dbo].[Price] ADD CONSTRAINT[DF_Price_Tax]  DEFAULT((23)) FOR[Tax]
                    ALTER TABLE[dbo].[Price] WITH CHECK ADD CONSTRAINT[FK_Price_Product] FOREIGN KEY([Id])
                    REFERENCES[dbo].[Product]
                            ([Id])
                    ALTER TABLE[dbo].[Price]
                            CHECK CONSTRAINT[FK_Price_Product]
                    ";
            createTableCommand.Connection = new SqlConnection(DBConnector.ConnectionString);
            createTableCommand.Connection.Open();
            createTableCommand.ExecuteNonQuery();
            conn.Close();
        }
        public bool TestConnection(string server, string dbName, string user, string pass, bool integrategSec)
        {
            SqlConnection conn = new SqlConnection(this.buildConnString(server, dbName, user, pass, integrategSec));
            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public void SetConnection(string server, string dbName, string user, string pass, bool integrategSec)
        {
            DBConnector.ConnectionString = this.buildConnString(server, dbName, user, pass, integrategSec);
        }
        private string buildConnString(string server, string dbName, string user, string pass, bool integrategSec)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = server;
            builder.InitialCatalog = dbName;
            if (integrategSec)
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.UserID = user;
                builder.Password = pass;
            }
            return builder.ConnectionString;
        }
    }
}
