using Dapper;
using Microsoft.Data.Sqlite;
using System.IO;

namespace AccessToSqlite.Core
{
    public class SqliteProvider
    {
        private readonly string _fileName;
        private readonly string _pwd;

        public SqliteProvider(string fileName, string pwd)
        {
            _fileName = fileName;
            _pwd = pwd;
        }

        private string ConnectionString => $"Data Source={_fileName};Mode=ReadWriteCreate;";

        public SqliteConnection GetConnection()
        {
            //var sConn = ConnectionString;
            //if (!string.IsNullOrEmpty(_pwd))
            //    sConn += $"Password={_pwd}";
            //var conn = new SqliteConnection(ConnectionString);
            //if (!string.IsNullOrEmpty(_pwd))
            //    conn.SetPassword(_pwd);
            //return conn.OpenAndReturn();

            var builder = new SqliteConnectionStringBuilder(ConnectionString);
            if (!string.IsNullOrEmpty(_pwd))
                builder.Password = _pwd;
            var sConn = builder.ToString();

            var conn = new SqliteConnection(sConn);
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            
            return conn;
        }

        public void CreateDatabase()
        {
            if (File.Exists(_fileName))
                File.Delete(_fileName);

            //SqliteConnection.CreateFile(_fileName);

            if (!string.IsNullOrEmpty(_pwd))
                using (var conn = GetConnection())
                {
                    conn.Execute("CREATE TABLE IF NOT EXISTS `createTableForSavePassword`(`id`);");
                    conn.Execute("DROP TABLE IF EXISTS `createTableForSavePassword`;");
                }
        }
    }
}
