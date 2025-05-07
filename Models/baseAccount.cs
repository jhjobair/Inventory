using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Inventory.Models
{
    [Serializable]
    public class BaseAccount
    {

        public string Username { get; set; }
        public string Email { get; set; }
        public string Passward { get; set; }
        public string Role { get; set; }

        public bool VarifyLogin()
        {
            DataTable datatbl = new DataTable();

            string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(conString);
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "dbo.spOst_User";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@Username", this.Username));
            cmd.Parameters.Add(new SqlParameter("@Email", this.Email));
            cmd.Parameters.Add(new SqlParameter("@Passward", this.Passward));
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(datatbl);
            cmd.Dispose();
            sqlConnection.Close();

            if (datatbl.Rows.Count > 0)
            {
                var Pdata = (from p in datatbl.AsEnumerable()
                             where p.Field<string>("Name") == this.Username && p.Field<string>("Password") == this.Passward && p.Field<string>("Email") == this.Email
                             select new
                             {
                                 Username = p.Field<string>("Name"),
                                 Role = p.Field<string>("Role"),
                                 Email = p.Field<string>("Email")


                             }).ToList();
                foreach (var item in Pdata)
                {
                    this.Username = item.Username;
                    this.Role = item.Role;
                    return true;
                }
            }

                //    
                //}
                //if (datatbl.Rows.Count > 0)
                //{
                //    var userRow = datatbl.AsEnumerable()
                //        .FirstOrDefault(p =>
                //            p.Field<string>("Name") == this.Username
                //            && p.Field<string>("Password") == this.Passward);

                //    if (userRow != null)
                //    {
                //        this.Username = userRow.Field<string>("Name");
                //        this.Role = userRow.Field<string>("Role"); // Direct assignment
                //        return true;

                //    }

                //}

                //DataTable datatbl = new DataTable();
                //string conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

                //try
                //{
                //    using (SqlConnection sqlConnection = new SqlConnection(conString))
                //    {
                //        sqlConnection.Open();
                //        using (SqlCommand cmd = new SqlCommand("dbo.spOst_User", sqlConnection))
                //        {
                //            cmd.CommandType = CommandType.StoredProcedure;
                //            cmd.CommandTimeout = 30; // Set a reasonable timeout

                //            // Add parameters if needed (example):
                //            // cmd.Parameters.AddWithValue("@ParamName", value);

                //            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                //            {
                //                adapter.Fill(datatbl);
                //            }
                //        }
                //    }
                //}
                //catch (SqlException ex)
                //{
                //    // Log/handle database errors
                //    Console.WriteLine($"SQL Error: {ex.Message}");
                //}
                //catch (Exception ex)
                //{
                //    // General error handling
                //    Console.WriteLine($"Error: {ex.Message}");
                //}



                //if(Pdata != null)
                //{
                //    return true;
                //}

                //if (this.Username == "jobair" && this.Email == "jobair@gmail.com" && this.Passward == 123456)
                //{
                //  return true;
                //}
                return false;
            }
        }
    }
