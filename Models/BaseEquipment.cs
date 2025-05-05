
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace Inventory.Models
{
    public class BaseEquipment
    {
        public int EquipmentID { get; set; }
        public string Name { get; set; }
        public int EcCount { get; set; }
        public int Stock { get; set; }
        public DateTime DateEntry { get; set; }

        public List<BaseEquipment> ListEquipment { get; set; }

        public BaseEquipment()
        {
            ListEquipment = new List<BaseEquipment>();
        }

        public static List<BaseEquipment> ListEquipmentData()
        {
            List<BaseEquipment> list = new List<BaseEquipment>();
            //DataTable datatbl = new DataTable();

            string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(conString);
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "spOst_LstEquipment";
            cmd.Parameters.Clear();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

           SqlDataReader mrd = cmd.ExecuteReader();
            if(mrd.HasRows)
            {
                while (mrd.Read()) 
                {
                    BaseEquipment obj = new BaseEquipment();
                    obj.EquipmentID = Convert.ToInt16(mrd["EquipmentID"].ToString());
                    obj.Name = mrd["EquipmentName"].ToString();
                    obj.EcCount = Convert.ToInt16(mrd["Quantity"].ToString());
                    obj.Stock = Convert.ToInt16(mrd["stock"].ToString());
                    obj.DateEntry = Convert.ToDateTime(mrd["EntryDate"].ToString());
                    list.Add(obj);
                }

            }
            cmd.Dispose();
            sqlConnection.Close();
            return list;
        }

        public int SaveEquipment()
        {

            string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(conString);
            sqlConnection.Open();
            SqlCommand cmd =new SqlCommand();
            cmd.CommandText = "dbo.spOst_InsetEqup";
            cmd.Connection = sqlConnection;
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@Name", this.Name)); 
            cmd.Parameters.Add(new SqlParameter("@EcCount", this.EcCount));
            cmd.Parameters.Add(new SqlParameter("@DateEntry", this.DateEntry));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

          int result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            sqlConnection.Close();
            return result;
        }

    }
}
