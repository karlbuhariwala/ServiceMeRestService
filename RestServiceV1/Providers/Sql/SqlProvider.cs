// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = SqlProvider.cs

namespace RestServiceV1.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// SqlProvider
    /// </summary>
    public class SqlProvider : ISqlProvider
    {
        /// <summary>
        /// The size map
        /// </summary>
        private static Dictionary<string, int> sizeMap;

        /// <summary>
        /// The connection string
        /// </summary>
        private string connectionString;

        /// <summary>
        /// The command timeout
        /// </summary>
        private int commandTimeout;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlProvider"/> class.
        /// </summary>
        public SqlProvider()
        {
            this.connectionString = ConfigurationManager.AppSettings["SqlAzureDBConnectionString"];
            SqlProvider.SetSizeMap(this);
        }

        /// <summary>
        /// Sets the SQL provider properties.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="commandTimeout">The command timeout.</param>
        public void SetSqlProviderProperties(string connectionString, int commandTimeout)
        {
            this.connectionString = connectionString;
            this.commandTimeout = commandTimeout;
            SqlProvider.SetSizeMap(this);
        }

        /// <summary>
        /// Sets the size map.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <exception cref="System.ApplicationException">No table or rows in the GetColumnSizeInfo query.</exception>
        private static void SetSizeMap(ISqlProvider provider)
        {
            // Todo: Protect with Monitor
            if (SqlProvider.sizeMap == null)
            {
                SqlProvider.sizeMap = new Dictionary<string, int>();
                DataSet result = provider.ExecuteQuery(SqlQueries.GetColumnSizeInfo, new Dictionary<string, object>() { { "@fieldType", "nvarchar" } });
                if (result.Tables.Count == 1 && result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in result.Tables[0].Rows)
                    {
                        int tempLenght;
                        if (int.TryParse(row["Length"].ToString(), out tempLenght))
                        {
                            SqlProvider.sizeMap.Add(row["Field"].ToString(), tempLenght);
                        }
                    }
                }
                else
                {
                    throw new ApplicationException("No table or rows in the GetColumnSizeInfo query.");
                }
            }
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// DataSet of the query
        /// </returns>
        DataSet ISqlProvider.ExecuteQuery(string query, Dictionary<string, object> parameters)
        {
            SqlConnection myConnection = new SqlConnection(connectionString);

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                myCommand.CommandTimeout = this.commandTimeout;
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> item in parameters)
                    {
                        myCommand.Parameters.AddWithValue(item.Key, item.Value ?? DBNull.Value);
                        if (SqlProvider.sizeMap.ContainsKey(item.Key))
                        {
                            myCommand.Parameters[item.Key].Size = SqlProvider.sizeMap[item.Key];
                        }
                    }
                }

                SqlDataAdapter sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
                sqlDataAdapter.SelectCommand = myCommand;

                DataSet dataSet = new DataSet();
                dataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;

                sqlDataAdapter.Fill(dataSet);

                return dataSet;
            }
            finally
            {
                myConnection.Close();
            }
        }
    }
}