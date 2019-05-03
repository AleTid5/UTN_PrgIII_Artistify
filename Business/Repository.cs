using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataAccess;

namespace Business
{
    public class Repository
    {
        public SqlConnection SqlConnection { set; get; }
        public SqlCommand SqlCommand { set; get; }
        public SqlDataReader SqlDataReader { set; get; }

        public Repository()
        {
            this.SqlConnection = new SqlConnection();
            this.SqlCommand = new SqlCommand();
        }

        public void ExecSelect(String Query)
        {
            this.SqlConnection.ConnectionString = DataAccessManager.cadenaConexion;
            this.SqlCommand.CommandType = System.Data.CommandType.Text;
            this.SqlCommand.CommandText = Query;
            this.SqlCommand.Connection = this.SqlConnection;
            this.SqlConnection.Open();
            this.SqlDataReader = this.SqlCommand.ExecuteReader();
        }
    }
}