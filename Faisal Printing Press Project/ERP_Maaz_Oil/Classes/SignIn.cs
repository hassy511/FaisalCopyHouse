using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Classes
{
    class SignIn
    {
        SqlCommand cmd;
        SqlDataReader dr;
        string query = "";

        Helper valid = new Helper();
        
        public string login(TextBox id, TextBox pass)
        {
            string x = "";
            if (id.Text.Trim().Equals("") || pass.Text.Trim().Equals(""))
            {
                MessageBox.Show("Fill all fields", "error");
            }
            else
            {
                try
                {
                    if (Classes.Helper.conn.State == System.Data.ConnectionState.Closed) { Classes.Helper.conn.Open(); }
                    query = "select USERS_ID,USERS_NAME,PASS from [USERS] U WHERE U.USERS_NAME = '" + valid.AvoidInjection(id.Text) + "' and U.PASS = '" + valid.AvoidInjection(pass.Text) + "'";
                    cmd = new SqlCommand(query, Classes.Helper.conn);
                    cmd.CommandTimeout = 0;
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        if (dr.Read())
                        {
                            Classes.Helper.userId = Convert.ToInt32(dr["USERS_ID"].ToString());
                            x = "success";
                        }
                    }
                    else
                    {
                        x = "User Name or Password is Invalid.!";
                    }
                }
                catch (SqlException ex)
                {
                    x = ex.Message;
                }
                finally
                {
                    Classes.Helper.conn.Close();
                }
            }
            return x;
        }
    }
}
