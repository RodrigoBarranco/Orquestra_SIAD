using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Configuration;

namespace Orquestra3_SIAD.Database
{
    public class Base
    {
        private DbProviderFactory factory;

        private string DatabaseProviderName
        {
            get
            {
                return "System.Data.SqlClient";
            }
        }

        private string ConnectionString
        {
            get
            {

                return "Data Source=.\\SQLEXPRESS;Initial Catalog=Orquestra3;Persist Security Info=True;User ID=orquestra_user;Password=adc4m1l0";
            }
        }

        public DbConnection CreateConnection()
        {
            DbConnection connection = null;

            try
            {
                factory = DbProviderFactories.GetFactory(this.DatabaseProviderName);

                connection = factory.CreateConnection();

                connection.ConnectionString = this.ConnectionString;
            }
            catch (Exception ex)
            {
                // Set the connection to null if it was created.
                if (connection != null)
                {
                    connection = null;
                }
                throw;
            }

            // Return the connection.
            return connection;
        }

        public DbCommand CreateCommand(DbConnection cn)
        {
            return cn.CreateCommand();
        }

        public int ExecuteNonQuery(DbCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        public DbDataReader ExecuteReader(DbCommand cmd)
        {
            return ExecuteReader(cmd, CommandBehavior.Default);
        }

        public DbDataReader ExecuteReader(DbCommand cmd, CommandBehavior behavior)
        {
            return cmd.ExecuteReader(behavior);
        }

        public object ExecuteScalar(DbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }

        
        public DbParameter CreateParameter(string parameterName, DbType dbType, object value)
        {
            DbParameter oDbParameter = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateParameter();
            oDbParameter.ParameterName = parameterName;
            oDbParameter.DbType = dbType;
            oDbParameter.Value = value;

            return oDbParameter;
        }

        public bool ColumnExists(IDataReader reader, string columnName)
        {

            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }

    }
}

