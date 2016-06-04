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
            string ElComando = "";
            ElComando = string.Format("select * from Movies Where categoriaId = {0}", aux);
            SqlConnection con = new SqlConnection(@"Data source = .\Sqlexpress;Initial catalog=Peliculas; Integrated Security=True");
            SqlCommand comando = new SqlCommand(ElComando, con);
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataTable table = new DataTable();
            //TextBox tb = new TextBox();

            try
            {
                con.Open();
                //adapter.Fill(tb);
                adapter.Fill(table);
                IdTextBox.Text = "";
                dataGridView1.DataSource = table;
            }

            catch (Exception ex)
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

        private void button2_Click(object sender, EventArgs e)
        {

            string ElComando = "";
            ElComando = string.Format("Insert into Movies(Descripcion) values('{0}')", DescTextBox.Text);
            SqlConnection con = new SqlConnection(@"Data source = .\Sqlexpress;Initial catalog=Peliculas; Integrated Security=True");
            SqlCommand comando = new SqlCommand(ElComando, con);

            try
            {
                con.Open();
                comando.ExecuteNonQuery();
                IdTextBox.Text = "";
                DescTextBox.Text = "";

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar" + ex.Message);
            }

            finally
            {
                con.Close();
                comando.Dispose();
            }
            
        }
    }
}
