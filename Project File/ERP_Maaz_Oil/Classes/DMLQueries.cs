using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ERP_Maaz_Oil.Classes
{
    class DMLQueries
    {
        string[] parameters;
        object[] values;

        static int parametersCount = 0;
        static int valueCount = 0;

        string query = "";
        SqlCommand cmd;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
   

        public void SetParameters(params string[] parameters)
        {
            parametersCount = parameters.Count();
            this.parameters = parameters;
        }

        public void SetValues(params object[] values)
        {
            valueCount = values.Count();
            this.values = values;
        }

        public int InsertData(string TableName)
        {
            try
            {
                if (parametersCount != valueCount)
                {
                    MessageBox.Show("Number of parameters and supplied values do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }
                query = "INSERT INTO " + TableName + " (";
                for (int i = 0; i < parametersCount; i++)
                {
                    if (i < parametersCount)
                        query += parameters[i] + ", ";
                    else
                        query += parameters[i] + ")";
                }
                query += " VALUES (";
                for (int i = 0; i < parametersCount; i++)
                {
                    if (i < parametersCount)
                        query += "@" + parameters[i] + ", ";
                    else
                        query += "@" + parameters[i] + ");";
                }

                using (cmd = new SqlCommand(query, con))
                {
                    for (int i = 0; i < parametersCount; i++)
                    {
                        cmd.Parameters.AddWithValue("@"+parameters[i], values[i]);
                    }
                }

                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        public int InsertData(string TableName,params object[] values)
        {
            try
            {
                query = @"INSERT INTO "+TableName+" VALUES (";
                for (int i = 0; i < parametersCount; i++)
                {
                    if (i < parametersCount)
                        query += "@" + parameters[i] + ", ";
                    else
                        query += "@" + parameters[i] + ");";
                }

                using (cmd = new SqlCommand(query, con))
                {
                    for (int i = 0; i < parametersCount; i++)
                    {
                        cmd.Parameters.AddWithValue("@"+parameters[i], values[i]);
                    }
                }
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            finally
            {
                con.Close();
            }
        }



    }
}
