using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class BaseCustomer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }

        public static List<BaseCustomer> ListCustomer()
        {
            List<BaseCustomer> list = new List<BaseCustomer>();
            //DataTable datatbl = new DataTable();

            string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(conString);
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "spOst_LstCustomer";
            cmd.Parameters.Clear();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

            SqlDataReader mrd = cmd.ExecuteReader();
            if (mrd.HasRows)
            {
                while (mrd.Read())
                {
                    BaseCustomer obj = new BaseCustomer();
                    obj.CustomerID = Convert.ToInt16(mrd["CustomerID"].ToString());
                    obj.CustomerName = mrd["CustomerName"].ToString();
                    obj.CustomerNumber = mrd["CustomerMobile"].ToString();
                    list.Add(obj);
                } 

            }
            cmd.Dispose();
            sqlConnection.Close();
            return list;
        }
        public static DataTable ListCustomerEquipment()
        {
            //List<BaseCustomer> list = new List<BaseCustomer>();
            DataTable datatbl = new DataTable();

            string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(conString);
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "spOstCustomerEquipAssign";
            cmd.Parameters.Clear();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

            //SqlDataReader mrd = cmd.ExecuteReader();
            //if (mrd.HasRows)
            //{
            //    while (mrd.Read())
            //    {
            //        BaseCustomer obj = new BaseCustomer();
            //        obj.CustomerID = Convert.ToInt16(mrd["CustomerID"].ToString());
            //        obj.CustomerName = mrd["CustomerName"].ToString();
            //        obj.CustomerNumber = mrd["CustomerMobile"].ToString();
            //        list.Add(obj);
            //    } 

            //}
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(datatbl);
            cmd.Dispose();
            sqlConnection.Close();
            return datatbl;
        }

        public static int EquipmentAssign(int customerID, int EquipmentID, int EquipmentQuantity)
        {

            string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(conString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "spOst_InsEquipAssignment";
            cmd.Connection = sqlConnection;
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@CustomerID",customerID));
            cmd.Parameters.Add(new SqlParameter("@EquipmentID", EquipmentID ));
            cmd.Parameters.Add(new SqlParameter("@EquipCount", EquipmentQuantity));

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

            int result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            sqlConnection.Close();
            return result;
        }



    }
}