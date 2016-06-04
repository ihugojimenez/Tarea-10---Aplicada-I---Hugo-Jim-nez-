using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ResgitroPeliculas
{
    public partial class ResgitroPeliculas : Form
    {
        public ResgitroPeliculas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int aux = Convert.ToInt32(IdTextBox.Text);
            SqlConnection con = new SqlConnection(@"Data source = .\Sqlexpress;Initial catalog=Peliculas; Integrated Security=True");
            SqlCommand comando = new SqlCommand("select * from Movies Where categoriaId = " + Convert.ToString(aux), con);
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataTable table = new DataTable();
            TextBox tb = new TextBox();
           
            try
            {
                con.Open();
               //adapter.Fill(tb);
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }

            catch(Exception ex)
            {
                MessageBox.Show("Error al conectar" + ex.Message);
            }

           finally
            {
                con.Close();
                adapter.Dispose();
                comando.Dispose();
            }
        }
    }
}
