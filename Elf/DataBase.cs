using System.Collections.Generic;

namespace Elf
{
    public class DataBase
    {
        public string BaseId { get; set; }
        public string BaseName { get; set; }
        public string FileName { get; set; }
        public IList<Table> Tables
        {
            get
            {
                IList<Table> _tables = new List<Table>();
                if (LookTables)
                {
                    if (!string.IsNullOrEmpty(BaseName))
                    {
                        var sql = "select ID TableId,name TableName from [" + BaseName + "]..sysobjects";
                        var reader = Iris.GetDataReader(sql);
                        while (reader.Read())
                        {
                            var _table = new Table
                            {
                                TableId = reader["TableId"].ToString(),
                                TableName = reader["TableName"].ToString()
                            };
                            _tables.Add(_table);
                        }
                        reader.Dispose();
                        reader.Close();
                    }
                }
                return _tables;
            }
        }

        public bool LookTables { get; set; }
    }
}