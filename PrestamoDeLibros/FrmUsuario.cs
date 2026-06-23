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
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
            dgvUsuario.CellContentClick += dgvUsuario_CellContentClick;
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.Conectar())
            {
                string query = "SELECT * FROM Usuarios";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvUsuario.DataSource = dt;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Conexion con = new Conexion();

            using (SqlConnection cn = con.Conectar())
            {
                cn.Open();

                string query = @"INSERT INTO Usuarios (Nombre, Apellido, Telefono, Correo) VALUES (@Nombre, @Apellido, @Telefono, @Correo)";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Usuario guardado correctamente");
            CargarUsuarios();
            Limpiar();
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Seleccione un usuario primero");
                return;
            }

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.Conectar())
            {
                cn.Open();

                string query = @"UPDATE Usuarios SET Nombre = @Nombre,Apellido = @Apellido,Telefono = @Telefono,Correo = @CorreoWHERE IdUsuario = @IdUsuario";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@IdUsuario", Convert.ToInt32(txtId.Text));

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Usuario modificado correctamente");
            CargarUsuarios();
            Limpiar();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (txtId.Text == "")
            {
                MessageBox.Show("Seleccione un usuario primero");
                return;
            }

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.Conectar())
            {
                cn.Open();

                string query = "DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdUsuario", Convert.ToInt32(txtId.Text));

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Usuario eliminado correctamente");
            CargarUsuarios();
            Limpiar();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvUsuario.Rows[e.RowIndex].Cells["IdUsuario"].Value.ToString();
                txtNombre.Text = dgvUsuario.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvUsuario.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                txtTelefono.Text = dgvUsuario.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtCorreo.Text = dgvUsuario.Rows[e.RowIndex].Cells["Correo"].Value.ToString();
            }

        }
    }
}
