using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrestamoDeLibros
{
    public partial class FrmLibro : Form
    {
        public FrmLibro()
        {
            InitializeComponent();
            dgvLibro.CellContentClick += dgvLibro_CellContentClick;
        }
        private void CargarLibros()
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.Conectar())
            {
                string query = "SELECT * FROM Libros";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLibro.DataSource = dt;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.Conectar())
            {
                cn.Open();

                string query = @"INSERT INTO Libros (Titulo, Autor, Categoria, Stock) VALUES (@Titulo, @Autor, @Categoria, @Stock)";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Titulo", txtTitulo.Text);
                cmd.Parameters.AddWithValue("@Autor", txtAutor.Text);
                cmd.Parameters.AddWithValue("@Categoria", txtCategoria.Text);
                cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(txtStock.Text));

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Libro guardado correctamente");
            CargarLibros();
            Limpiar();

            
        }
        private void Modificar_Click(object sender, EventArgs e)
        {

            if (txtId.Text == "")
            {
                MessageBox.Show("Seleccione un libro primero");
                return;
            }

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.Conectar())
            {
                cn.Open();

                string query = @"UPDATE Libros SET Titulo = @Titulo,Autor = @Autor,Categoria = @Categoria,Stock = @StockWHERE IdLibro = @IdLibro";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Titulo", txtTitulo.Text);
                cmd.Parameters.AddWithValue("@Autor", txtAutor.Text);
                cmd.Parameters.AddWithValue("@Categoria", txtCategoria.Text);
                cmd.Parameters.AddWithValue("@Stock", Convert.ToInt32(txtStock.Text));
                cmd.Parameters.AddWithValue("@IdLibro", Convert.ToInt32(txtId.Text));

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Libro modificado correctamente");
            CargarLibros();
            Limpiar();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Seleccione un libro primero");
                return;
            }

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.Conectar())
            {
                cn.Open();

                string query = "DELETE FROM Libros WHERE IdLibro = @IdLibro";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdLibro", Convert.ToInt32(txtId.Text));

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Libro eliminado correctamente");
            CargarLibros();
            Limpiar();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtId.Clear();
            txtTitulo.Clear();
            txtAutor.Clear();
            txtCategoria.Clear();
            txtStock.Clear();
        }


        private void dgvLibro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvLibro.Rows[e.RowIndex].Cells["IdLibro"].Value.ToString();
                txtTitulo.Text = dgvLibro.Rows[e.RowIndex].Cells["Titulo"].Value.ToString();
                txtAutor.Text = dgvLibro.Rows[e.RowIndex].Cells["Autor"].Value.ToString();
                txtCategoria.Text = dgvLibro.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
                txtStock.Text = dgvLibro.Rows[e.RowIndex].Cells["Stock"].Value.ToString();
            }
        }

        private void FrmLibro_Load(object sender, EventArgs e)
        {
            CargarLibros();
        }
    }
}
