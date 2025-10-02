using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComboboxWithSearch
{
	public partial class Form1 : Form
	{
		public string[] collections;
		
		string query = "SELECT [CITY_ID],[CITY_NAME]FROM [AOI_20_21].[dbo].[CITY]";
		string con = @"Data Source=.;Initial Catalog=AOI_20_21;Integrated Security=True";
		SqlConnection thisConn;
		SqlCommand cmd;
		SqlDataAdapter adp;
		DataTable ds;
        ListBox lst = new ListBox();

	public Form1()
	{
		InitializeComponent();
			//collections = new string[] { "Muhammad Zain Baig", "Muhamaad Noman saleem", "Shehroze Ali", "Abid Rafique",
			//                 "Abdul Haseeb qasim muhammad ashraf", "Shoaib", "sameer ali", "waris ali shah", "Qaim  ali shah", "syed hamza"};
			thisConn = new SqlConnection(con);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			//comboBox1.Items.AddRange(collections);
		
			try
			{
				if (thisConn.State == System.Data.ConnectionState.Closed) { if (thisConn.State == System.Data.ConnectionState.Closed) { thisConn.Open(); } }

				cmd = new SqlCommand(query, thisConn);
				cmd.CommandTimeout = 0;
				adp = new SqlDataAdapter();
				adp.SelectCommand = cmd;
				ds = new System.Data.DataTable();
				adp.Fill(ds);
				collections = ds.Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray();
				comboBox1.DataSource = collections;
				//collections = ds.Tables["data"].ToString();
		





			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Exception");
			}
			finally
			{
				thisConn.Close();

			}
		}

		private void lst_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboBox1.SelectedItem = lst.SelectedItem;
		}

		private void comboBox1_TextChanged(object sender, EventArgs e)
		{
			
			// get the keyword to search
			string textToSearch = comboBox1.Text.ToLower();
			//lst.Visible = false; // hide the listbox, see below for why doing that
			if (String.IsNullOrEmpty(textToSearch))
				return; // return with listbox's Visible set to false if the keyword is empty
			//search
			string[] result = (from i in collections
								   where i.ToLower().Contains(textToSearch)
								   select i).ToArray();
			if (result.Length == 0)
				return; // return with listbox's Visible set to false if nothing found

			lst.Items.Clear(); // remember to Clear before Add
			lst.Items.AddRange(result);
			//lst.Visible = true; // show the listbox again
		}

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
			//lst.Visible = false;
		}
    }
}
