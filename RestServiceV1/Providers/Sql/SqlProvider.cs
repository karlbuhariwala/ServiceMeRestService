// Copyright = Karl Buhariwala
// ServiceMe App
// FileName = SqlProvider.cs

namespace RestServiceV1.Providers
{
    using System;
    using System.Data;

    /// <summary>
    /// SqlProvider
    /// </summary>
    public class SqlProvider : ISqlProvider
    {
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
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>
        /// DataSet of the query
        /// </returns>
        /// <exception cref="NotImplementedException"></exception>
        DataSet ISqlProvider.ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }

        //private static string dataFolder = @"C:\Users\karlbuha\Documents\Visual Studio 2012\Projects\ServiceMe\RestServiceV1\Data";

        //static SqlProvider()
        //{
        //    // Get from the config
        //    SqlProvider.connectionString = "";
        //}

        ////private static SqlProvider instance;

        ////public static SqlProvider Instance
        ////{
        ////    get
        ////    {
        ////        if (SqlProvider.instance == null)
        ////        {
        ////            SqlProvider.instance = new SqlProvider();
        ////        }

        ////        return SqlProvider.instance;
        ////    }
        ////}

        //public DataSet ExecuteQuery1(string query)
        //{
        //    SqlConnection myConnection = new SqlConnection(connectionString);

        //    try
        //    {
        //        myConnection.Open();
        //        SqlCommand myCommand = new SqlCommand(query, myConnection);
        //        myCommand.CommandTimeout = 300;
        //        SqlDataAdapter sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
        //        sqlDataAdapter.SelectCommand = myCommand;

        //        DataSet dataSet = new DataSet();
        //        dataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;

        //        sqlDataAdapter.Fill(dataSet);

        //        return dataSet;
        //    }
        //    finally
        //    {
        //        myConnection.Close();
        //    }
        //}

        //public void ExecuteQuery<T>(string query, T data)
        //{
        //    string fileName = query;
        //    string dataToInsert = this.Serialize<T>(data);
        //    File.AppendAllText(Path.Combine(dataFolder, fileName), dataToInsert);
        //}

        //public T GetData<T>(string query)
        //{
        //    string fileName = query;
        //    string filePath = Path.Combine(dataFolder, fileName);
        //    if (!File.Exists(filePath))
        //    {
        //        File.AppendAllText(filePath, string.Empty);
        //    }

        //    try
        //    {
        //        string xml = string.Format("<{0}>{1}</{0}>", "ArrayOf" + typeof(T).GenericTypeArguments[0].Name, File.ReadAllText(Path.Combine(dataFolder, fileName)));

        //        return this.Deserialize<T>(xml);
        //    }
        //    catch (Exception)
        //    {
        //        // log
        //    }

        //    return default(T);
        //}

        //private T Deserialize<T>(string xml)
        //{
        //    XmlSerializer deserializer = new XmlSerializer(typeof(T));
        //    using (TextReader textReader = new StringReader(xml))
        //    {
        //        return (T)deserializer.Deserialize(textReader);
        //    }
        //}

        //private string Serialize<T>(T objectToSerialize)
        //{
        //    XmlSerializer serializer = new XmlSerializer(typeof(T));
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        serializer.Serialize(stream, objectToSerialize);
        //        stream.Position = 0;
        //        using (StreamReader sr = new StreamReader(stream))
        //        {
        //            sr.ReadLine();
        //            return sr.ReadToEnd();
        //        }
        //    }
        //}
    }
}