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
namespace TVStore
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-GCJF4AE;Initial Catalog=TiendaProgra;Integrated Security=true");


        private void Form2_Load(object sender, EventArgs e)
        {
            String Select = "Select * from Cliente";
            SqlDataAdapter adapter = new SqlDataAdapter(Select, conexion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Cliente (nombre, apellido, direccion, telefono, email) VALUES (@nombre, @apellido, @direccion, @telefono, @email)";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@nombre", textBoxnombre.Text);
            comando.Parameters.AddWithValue("@apellido", textBoxapellido.Text);
            comando.Parameters.AddWithValue("@direccion", textBoxdireccion.Text);
            comando.Parameters.AddWithValue("@telefono", textBoxtelefono.Text);
            comando.Parameters.AddWithValue("email", textBoxemail.Text);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro Exitoso");

            String Select = "Select * from Cliente";
            SqlDataAdapter adapter = new SqlDataAdapter(Select, conexion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string query = "Update Cliente set nombre='" + textBoxnombre.Text + "',apellido='" + textBoxapellido.Text + "',telefono=" + textBoxtelefono.Text +  "WHERE id=" + textBoxID.Text + " ";
            conexion.Open();
            SqlCommand comando = new SqlCommand(query, conexion);
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant > 0)
            {
                MessageBox.Show("Se Modifico correctamente");

            }

            String Select = "Select * from Cliente";
            SqlDataAdapter adapter = new SqlDataAdapter(Select, conexion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            conexion.Open();
            string query = "DELETE FROM Cliente WHERE id=" + textBoxID.Text + "";
            SqlCommand comando = new SqlCommand(query, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Se elimino correctamente");
    
            String Select = "Select * from Cliente";
            SqlDataAdapter adapter = new SqlDataAdapter(Select, conexion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
