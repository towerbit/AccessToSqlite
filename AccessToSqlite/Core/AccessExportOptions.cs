using System.IO;

namespace AccessToSqlite.Core
{
    public class AccessExportOptions
    {
        private string _accessFileName;

        public string AccessFileName
        {
            get { return _accessFileName; }
            set
            {
                _accessFileName = value;
                SQLiteFileName = Path.Combine(SQLiteInitialDirectory, SQLiteDefaultFileName);
            }
        }

        public string AccessPassword { get; set; }

        public string SQlitePassword { get; set; }

        public string SQLiteFileName { get; set; }

        public bool Executing { get; set; }
        
        public bool CanExport => File.Exists(AccessFileName) && !Executing && !string.IsNullOrEmpty(SQLiteFileName);

        public bool SQLiteFileExists => File.Exists(SQLiteFileName);

        public string SQLiteInitialDirectory => File.Exists(AccessFileName)? Path.GetDirectoryName(AccessFileName):string.Empty;

        public string SQLiteDefaultFileName => Path.GetFileNameWithoutExtension(AccessFileName) + ".sqlite3";
    }
}
