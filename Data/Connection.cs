using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Connection
    {
        string Cadena = string.Empty;
        SqlConnection oConnection = null;
        public Connection()
        {
            Cadena = ConfigurationManager.ConnectionStrings["KeyConnection"].ConnectionString;
        }
        public void OpenConnection()
        {
            try
            {
                oConnection = new SqlConnection(Cadena);
                oConnection.ConnectionString = Cadena;
                oConnection.Open();
            }
            catch (Exception e)
            {
            }
        }
        public void CloseConnection()
        {
            try
            {
                oConnection.Close();
            }
            catch (Exception e)
            {
            }
        }
        public bool EjecuteQuery(string StoredProcedure, SqlParameter[] oParameter)
        {
            try
            {
                OpenConnection();
                SqlCommand oCommand = new SqlCommand(StoredProcedure, oConnection);
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.AddRange(oParameter);
                int respuesta = oCommand.ExecuteNonQuery();
                CloseConnection();
                return Convert.ToBoolean(respuesta);
            }
            catch (Exception e)
            {
                CloseConnection();
                return false;
            }
        }
        public DataSet EjecuteQueryDs(string StoredProcedure, SqlParameter[] oParameter)
        {
            try
            {
                OpenConnection();

                DataSet oDataSet = new DataSet();

                SqlCommand oCommand = new SqlCommand(StoredProcedure, oConnection);
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.AddRange(oParameter);
                SqlDataAdapter oDataAdapter = new SqlDataAdapter(oCommand);
                oDataAdapter.Fill(oDataSet);
                CloseConnection();
                return oDataSet;
            }
            catch (Exception e)
            {
                CloseConnection();
                return null;
            }
        }
    }
}