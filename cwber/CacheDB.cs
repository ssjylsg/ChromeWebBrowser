using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Sashulin
{
    class CacheDB
    {
        SQLiteConnection conn = null;
        public CacheDB()
        {
            conn = new SQLiteConnection();
        }

        public void Connect(string dbName)
        {
            Close();
            string datasource = System.IO.Directory.GetCurrentDirectory() + "\\" +dbName + ".db";
            if (!File.Exists(datasource))
                SQLiteConnection.CreateFile(datasource);
            SQLiteConnectionStringBuilder connStrBuilder = new SQLiteConnectionStringBuilder();
            connStrBuilder.DataSource = datasource;
            conn.ConnectionString = connStrBuilder.ToString();
            conn.Open();
        }

        public void Close()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        public int Execute(string commandText)
        {
            int res = 0;
            using (SQLiteCommand cmd = new SQLiteCommand(commandText, conn))
            {
                try
                {
                    res = cmd.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    System.Windows.Forms.MessageBox.Show(e.Message);
                }
            }
            return res;
        }

        public string Query(string commandText)
        {
            string res = string.Empty;
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(commandText, conn))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                string tableName = "rows";
                int columnCount = table.Columns.Count;
                int rowcount = table.Rows.Count;
                string record = "[";
                foreach(DataRow row in table.Rows)
                {
                    record += "{";
                    foreach (DataColumn col in table.Columns)
                    {
                        record += "\""+col.ColumnName+"\":\""+row[col].ToString()+"\"";
                        if (col != table.Columns[columnCount - 1])
                        {
                            record += ",";
                        }
                    }
                    record += "}";
                    if (row != table.Rows[rowcount - 1])
                    {
                        record += ",";
                    }
                }
                record += "]";
                res = "{\"" + tableName + "\":" + record + "}";
            }
            return res;
        }
    }
}
