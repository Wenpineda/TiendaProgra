using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace TiendaProgra
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-GCJF4AE;Initial Catalog=TiendaProgra;Integrated Security=true");

        private void Form1_Load(object sender, EventArgs e)
        {
            String Select = "Select * from Cliente";
            SqlDataAdapter adapter = new SqlDataAdapter(Select, conexion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Cliente (id,nombre, apellido, direccion, telefono, email) VALUES (@id,@nombre, @apellido, @direccion, @telefono, @email)";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id", textBoxID);
            comando.Parameters.AddWithValue("@nombre", textBoxnombre.Text);
            comando.Parameters.AddWithValue("@apellido", textBoxapellido.Text);
            comando.Parameters.AddWithValue("@direccion", textBoxdireccion.Text);
            comando.Parameters.AddWithValue("@telefono", textBoxtelefono.Text);
            comando.Parameters.AddWithValue("email", textBoxemail.Text);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro Exitoso");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Cliente WHERE idCliente=" + textBoxID + "";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id", textBoxID);
            comando.ExecuteNonQuery();
            MessageBox.Show("Se elimino correctamente");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}