using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Elf
{
    public class Iris
    {
        public Iris()
        {
            ConnStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
            if (string.IsNullOrEmpty(ConnStr))
                ConnStr = ConfigurationManager.AppSettings["connStr"];
        }

        public Iris(string connStr)
        {
            ConnStr = connStr;
        }

        private static string ConnStr
        {
            get
            {
                var connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
                if (string.IsNullOrEmpty(connStr))
                    connStr = ConfigurationManager.AppSettings["connStr"];
                return connStr;
            }
            set { if (value == null) throw new ArgumentNullException("value"); }
        }

        public static SqlDataReader GetDataReader(string sql, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            foreach (SqlParameter parameter in parameters)
            {
                cmd.Parameters.Add(parameter);
            }
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception e)
            {
                throw new Exception("执行任务失败:" + e.Message + "   " + sql);
            }

        }

        public static DBList<DataBase> GetDataBases(bool looktables, string name)
        {
            try
            {
                IList<DataBase> dbs = new List<DataBase>();
                SqlDataReader reader;
                switch (name)
                {
                    case null:
                    case "":
                        string sql = "SELECT dbid BaseId,name BaseName,FileName FROM Master..SysDatabases ORDER BY Name";
                        reader = GetDataReader(sql);
                        break;
                    default:
                        var parms = new[]
                        {
                            new SqlParameter("@name", name)
                        };
                        sql =
                            "SELECT dbid BaseId,name BaseName,FileName FROM Master..SysDatabases where name=@name ORDER BY Name";
                        reader = GetDataReader(sql, parms);
                        break;
                }
                if (!reader.IsClosed)
                    while (reader.Read())
                    {
                        DataBase _db = new DataBase
                        {
                            BaseId = reader["BaseId"].ToString(),
                            BaseName = reader["BaseName"].ToString(),
                            FileName = reader["FileName"].ToString(),
                            LookTables = looktables
                        };
                        dbs.Add(_db);
                    }
                var res = new DBList<DataBase>
                {
                    ListT = dbs,
                    Messages = "Success"
                };
                return res;
            }
            catch (Exception e)
            {
                return new DBList<DataBase>
                {

                    Messages = e.Message
                };
            }
        }
    }
}