using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SergeUtils;

namespace TestCombo
{
    public partial class Form1 : Form
    {
        private static readonly object[] s_NOBELS_LITTERATURE =
        {
            "Albert Camus",
            "Aleksandr Isayevich Solzhenitsyn",
            "Alice Munro",
            "Anatole France",
            "André Paul Guillaume Gide",
            "Bjørnstjerne Martinus Bjørnson",
            "Boris Leonidovich Pasternak",
            "Carl Friedrich Georg Spitteler",
            "Carl Gustaf Verner von Heidenstam",
            "Christian Matthias Theodor Mommsen",
            "Count Maurice (Mooris) Polidore Marie Bernhard Maeterlinck",
            "Czeslaw Milosz",
            "Dario Fo",
            "Derek Walcott",
            "Doris Lessing",
            "Earl (Bertrand Arthur William) Russell",
            "Elfriede Jelinek",
            "Elias Canetti",
            "Erik Axel Karlfeldt",
            "Ernest Miller Hemingway",
            "Eugene Gladstone O'Neill",
            "Eugenio Montale",
            "Eyvind Johnson",
            "François Mauriac",
            "Frans Eemil Sillanpää",
            "Frédéric Mistral",
            "Gabriel García Márquez",
            "Gabriela Mistral",
            "Gao Xingjian",
            "George Bernard Shaw",
            "George Elliot",
            "Gerhart Johann Robert Hauptmann",
            "Giorgos Seferis",
            "Giosuè Carducci",
            "Grazia Deledda",
            "Günter Grass",
            "Halldór Kiljan Laxness",
            "Harry Martinson",
            "Harold Pinter",
            "Heinrich Böll",
            "Henri Bergson",
            "Henrik Pontoppidan",
            "Henryk Sienkiewicz",
            "Hermann Hesse",
            "Herta Müller",
            "Iain Banks",
            "Imre Kertész",
            "Isaac Bashevis Singer",
            "Ivan Alekseyevich Bunin",
            "Ivo Andric",
            "Jacinto Benavente",
            "Jean-Marie Gustave Le Clézio",
            "Jean-Paul Sartre",
            "Johannes Vilhelm Jensen",
            "John Galsworthy",
            "John M. Coetzee",
            "John Steinbeck",
            "José Echegaray y Eizaguirre",
            "José Saramago",
            "Joseph Brodsky",
            "Juan Ramón Jiménez",
            "Karl Adolph Gjellerup",
            "Kenzaburo Oe",
            "Knut Pedersen Hamsun",
            "Luigi Pirandello",
            "Mario Vargas Llosa",
            "Miguel Angel Asturias",
            "Mikhail Aleksandrovich Sholokhov",
            "Mo Yan",
            "Nadine Gordimer",
            "Naguib Mahfouz",
            "Nelly Sachs",
            "Octavio Paz",
            "Odysseus Elytis",
            "Orhan Pamuk",
            "Pablo Neruda",
            "Pär Fabian Lagerkvist",
            "Patrick White",
            "Paul Johann Ludwig Heyse",
            "Pearl Buck",
            "Rabindranath Tagore",
            "Roger Martin du Gard",
            "Romain Rolland",
            "Rudolf Christoph Eucken",
            "Rudyard Kipling",
            "Saint-John Perse",
            "Salman Rushdie",
            "Salvatore Quasimodo",
            "Samuel Beckett",
            "Saul Bellow",
            "Seamus Heaney",
            "Selma Ottilia Lovisa Lagerlöf",
            "Shmuel Yosef Agnon",
            "Sinclair Lewis",
            "Sir Vidiadhar Surajprasad Naipaul",
            "Sir Winston Leonard Spencer Churchill",
            "Sully Prudhomme",
            "Thomas Stearns Eliot",
            "Tomas Tranströmer",
            "Toni Morrison",
            "Yasunari Kawabata",
            "Valerie Martin",
            "Vicente Aleixandre",
            "William Faulkner",
            "Wislawa Szymborska",
            "Wole Soyinka",
            "Thomas Mann",
            "Sigrid Undset",
            "Wladyslaw Stanislaw Reymont",
            "William Butler Yeats",
        };
        string query = "select * from [User]";
        string con = @"Data Source=DESKTOP-HHVD7K2\SQLEXPRESS;Initial Catalog=HFDB;Integrated Security=True";
        SqlConnection thisConn;
        SqlCommand cmd;
        SqlDataAdapter adp;
        DataTable ds;
        public class MethodItem
        {
            public string Name { get; set; }
            public StringMatchingMethod Value { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            thisConn = new SqlConnection(con);
            m_combo.Items.Add("EBSAntiJitterConfig");
            m_combo.Items.Add("BridgeFilterConfig2");
            m_combo.Items.Add("PCMActiveUserList");
            m_combo.Items.Add("SpotFXPriceConfigIDList");
            try
            {
                if (thisConn.State == System.Data.ConnectionState.Closed) { if (thisConn.State == System.Data.ConnectionState.Closed) { thisConn.Open(); } }

                cmd = new SqlCommand(query, thisConn);
                cmd.CommandTimeout = 0;
                adp = new SqlDataAdapter();
                adp.SelectCommand = cmd;
                ds = new System.Data.DataTable();
                adp.Fill(ds);
                //m_combo.DataSource = ds.Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray();
                //m_combo.DataSource = ds.Rows.OfType<DataRow>().Select(k => k[2].ToString()).ToArray();
                m_combo.Items.AddRange(ds.Rows.OfType<DataRow>().Select(k => k[1].ToString()).ToArray());
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
          
            m_methodCB.DisplayMember = "Name";
            m_methodCB.Items.Add(new MethodItem { Name = "No wildcards", Value = StringMatchingMethod.NoWildcards });
            m_methodCB.Items.Add(new MethodItem { Name = "Use wildcards", Value = StringMatchingMethod.UseWildcards });
            m_methodCB.Items.Add(new MethodItem { Name = "Use regexs", Value = StringMatchingMethod.UseRegexs });
            m_methodCB.SelectedIndex = 0;

            m_combo.MatchingMethod = StringMatchingMethod.NoWildcards;

            Font = new Font("Segoe UI", 9.0f);

        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("key down {0}", ActiveControl.GetType().Name);
        }

        private void onSelectionChanged(object sender, System.EventArgs e)
        {
            m_label.Text = string.Format("Selection: '{0}'", m_combo.SelectedItem);
        }

        private void onMethodChanged(object sender, System.EventArgs e)
        {
            MethodItem mi = (MethodItem) m_methodCB.SelectedItem;
            m_combo.MatchingMethod = mi.Value;
        }

        private void m_methodCB_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }

        private void m_label_Click(object sender, System.EventArgs e)
        {

        }
    }
}
