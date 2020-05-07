using System;
using System.Collections.Generic;
using System.Text;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;


namespace GenerowanieRekordówDoBazy
{
    class DbConnection
    {
        public static OracleConnection connection;
        public DbConnection()
        {
            connection = new OracleConnection();
            connection.ConnectionString = "User Id=s95479;Password=s95479;Data Source = (DESCRIPTION = " +
                                        " (ADDRESS = (PROTOCOL = TCP)(HOST = 217.173.198.135)(PORT = 1522    ))" +
                                        " (CONNECT_DATA =" +
                                        " (SERVER = DEDICATED)" +
                                         " (SERVICE_NAME = orcltp.iaii.local)" +
                                        ")" +
                                        ");";

            connection.Open();
        }

        public void DeleteDataFromTable(string table)
        {

            OracleCommand del = new OracleCommand();
            String select = "DELETE FROM "+ table;
            del.CommandText = select;
            del.Connection = connection;
            del.ExecuteNonQuery();          
        }
        public void Insertquery(string query)
        {
            OracleCommand ins = new OracleCommand();
            ins.CommandText = query;
            ins.Connection = connection;
            ins.ExecuteNonQuery();
            
        }
        public void InsertObjectToDatabaseTodatbase(string table,string columns,HashSet<string> values)
        {
            OracleCommand ins = new OracleCommand();
            string insert = "INSERT ALL ";
            if (values.Count > 0)
            {
                foreach (string val in values)
                {
                    insert += "into " + table + "(" + columns + ") values (" + val + ")";
                }
                insert += "SELECT * FROM dual";
                ins.CommandText = insert;
                ins.Connection = connection;
                ins.ExecuteNonQuery();
            }
        }

        public List<int> GetIntList(string table,string column)
        {
         
                OracleCommand sel = new OracleCommand();
                List<int> indeks = new List<int>();
                String select = "select " + column + " as ForeignKey from " + table + " order by ForeignKey";
                sel.Connection = connection;
                sel.CommandText = select;
                using (OracleDataReader reader = sel.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int index = reader.GetOrdinal("ForeignKey");

                            if (!reader.IsDBNull(index))
                            {
                                indeks.Add(Convert.ToInt32(reader.GetValue(index)));
                            }
                        }
                    }
                }
                return indeks;
        }
        public int GetLastId(string table, string column)
        {

            OracleCommand sel = new OracleCommand();
            int lastId=0;
            String select = "select " + column + " as ForeignKey from " + table+ " order by ForeignKey desc FETCH NEXT 1 ROWS ONLY";
            sel.Connection = connection;
            sel.CommandText = select;
            using (OracleDataReader reader = sel.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int index = reader.GetOrdinal("ForeignKey");

                        if (!reader.IsDBNull(index))
                        {
                           lastId=(Convert.ToInt32(reader.GetValue(index)));
                        }
                    }
                }
            }
            return lastId;
        }
        public int GetCount(string table)
        {

            OracleCommand sel = new OracleCommand();
            int lastId = 0;
            String select = "select count(*) as ForeignKey from " + table;
            sel.Connection = connection;
            sel.CommandText = select;
            using (OracleDataReader reader = sel.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int index = reader.GetOrdinal("ForeignKey");

                        if (!reader.IsDBNull(index))
                        {
                            lastId = (Convert.ToInt32(reader.GetValue(index)));
                        }
                    }
                }
            }
            return lastId;
        }
        public List<string> GetStringList(string table, string column)
        {

            OracleCommand sel = new OracleCommand();
            List<string> indeks = new List<string>();
            String select = "select " + column + " as ForeignKey from " + table + " order by ForeignKey";
            sel.Connection = connection;
            sel.CommandText = select;
            using (OracleDataReader reader = sel.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int index = reader.GetOrdinal("ForeignKey");

                        if (!reader.IsDBNull(index))
                        {
                            indeks.Add(Convert.ToString(reader.GetValue(index)));
                        }
                    }
                }
            }
            return indeks;
        }
        public HashSet<int> GetIntHashSet(string table, string column)
        {

            OracleCommand sel = new OracleCommand();
           HashSet<int> indeks = new HashSet<int>();
            String select = "select " + column + " as ForeignKey from " + table + " order by ForeignKey";
            sel.Connection = connection;
            sel.CommandText = select;
            using (OracleDataReader reader = sel.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int index = reader.GetOrdinal("ForeignKey");

                        if (!reader.IsDBNull(index))
                        {
                            indeks.Add(Convert.ToInt32(reader.GetValue(index)));
                        }
                    }
                }
            }
            return indeks;
        }
        public HashSet<string> GetStringHashSet(string table, string column)
        {

            OracleCommand sel = new OracleCommand();
            HashSet<string> indeks = new HashSet<string>();
            String select = "select " + column + " as ForeignKey from " + table + " order by ForeignKey";
            sel.Connection = connection;
            sel.CommandText = select;
            using (OracleDataReader reader = sel.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int index = reader.GetOrdinal("ForeignKey");

                        if (!reader.IsDBNull(index))
                        {
                            indeks.Add(Convert.ToString(reader.GetValue(index)));
                        }
                    }
                }
            }
            return indeks;
        }
        public HashSet<KeyValuePair<int,int>> GetIntPairHashSet(string table, string column1,string column2)
        {
            HashSet<KeyValuePair<int, int>> IntPair= new HashSet<KeyValuePair<int, int>>();
            OracleCommand sel = new OracleCommand();
            String select = "select " + column1 + " as ForeignKey1, "+column2+ " as ForeignKey2 from " + table;
            sel.Connection = connection;
            sel.CommandText = select;
            int value1 = 0;
            int value2 = 0;
            using (OracleDataReader reader = sel.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int index = reader.GetOrdinal("ForeignKey1");
                        int index1 = reader.GetOrdinal("ForeignKey2");

                        if (!reader.IsDBNull(index))
                        {
                            value1 = Convert.ToInt32(reader.GetValue(index));
                            value2 = Convert.ToInt32(reader.GetValue(index1));

                            IntPair.Add(new KeyValuePair<int, int>(value1,value2));
                        }
                    }
                }
            }
            return IntPair;
        }
    }
}
