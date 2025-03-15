using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class BaseAccount
    {

        public string Username { get; set; }
        public string Email { get; set; }
        public int Passward { get; set; }

        public bool VarifyLogin()
        {
            DataTable datatbl = new DataTable();

            string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.Open();

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "dbo.spOst_User";
            cmd.CommandType= System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 0; 

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(datatbl);
            cmd.Dispose();
            sqlConnection.Close();
           



            //if (this.Username == "jobair" && this.Email == "jobair@gmail.com" && this.Passward == 123456)
            //{
            //  return true;
            //}
            return false;
        }
    }
}