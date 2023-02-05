using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCoder.Helper
{
    internal class SqlHandler
    {
        static string connectionString = "Data Source=DESKTOP-QR97TGF;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private SqlConnection connection = new SqlConnection(connectionString);
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public void GetCommand(DataSet ds, SqlCommand command)
        {
            connection.Open();
            command.Connection = connection;
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(ds, "DAT");
            connection.Close();
        }
    }
}
