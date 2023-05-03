using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class dbConnect
    {
        private SqlConnection _connection;

            public dbConnect()
        {
            _connection = new SqlConnection("Data Source=TRANHUY\\SQLSEVER;Initial Catalog=QLSV_TC;Integrated Security=True");
        }

        public DataTable GetData(string strSQL)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(strSQL, _connection);
            _connection.Open();
            adapter.Fill(dt);
            _connection.Close();
            return dt;  
        }

        public DataTable GetData(string procName, SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = procName;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Connection = _connection;
            if (param != null)
            {
                sqlCommand.Parameters.AddRange(param);
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = sqlCommand;
            _connection.Open();
            dataAdapter.Fill(dt);
            _connection.Close();
            return dt;
        }

        public int ExecuteSQL(string strSQL)
        {
            SqlCommand sqlCommand = new SqlCommand(strSQL, _connection);
            _connection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            _connection.Close();
            return row;
        }

        public int ExecuteSQL(string procName, SqlParameter[] param)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = procName;
            if (param != null)
            {
                sqlCommand.Parameters.AddRange(param);
            }
            sqlCommand.CommandType= CommandType.StoredProcedure;
            sqlCommand.Connection = _connection;
            _connection.Open();
            int row = sqlCommand.ExecuteNonQuery();
            _connection.Close();
            return row;
        }
    }
}
