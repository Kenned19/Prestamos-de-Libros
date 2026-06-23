using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrestamoDeLibros
{
    public partial class FrmPrestamo : Form
    {
        public FrmPrestamo()
        {
            InitializeComponent();
        }

        private void FrmPrestamo_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
            CargarLibros();
            CargarPrestamos();
        }

        private void CargarUsuarios()
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.Conectar())
            {
                string query = "SELECT IdUsuario, Nombre + ' ' + Apellido AS Usuario FROM Usuarios";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbUsuario.DataSource = dt;
                cmbUsuario.DisplayMember = "Usuario";
                cmbUsuario.ValueMember = "IdUsuario";
            }
        }

        private void CargarLibros()
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.Conectar())
            {
                string query = "SELECT IdLibro, Titulo FROM Libros";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbLibro.DataSource = dt;
                cmbLibro.DisplayMember = "Titulo";
                cmbLibro.ValueMember = "IdLibro";
            }
        }

        private void CargarPrestamos()
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.Conectar())
            {
                string query = @"SELECT 
                                P.IdPrestamo,
                                P.IdUsuario,
                                U.Nombre + ' ' + U.Apellido AS Usuario,
                                P.IdLibro,
                                L.Titulo AS Libro,
                                P.FechaPrestamo,
                                P.FechaDevolucion
                                FROM Prestamos P
                                INNER JOIN Usuarios U ON P.IdUsuario = U.IdUsuario
                                INNER JOIN Libros L ON P.IdLibro = L.IdLibro";

                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPrestamo.DataSource = dt;

                dgvPrestamo.Columns["IdUsuario"].Visible = false;
                dgvPrestamo.Columns["IdLibro"].Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.Conectar())
            {
                cn.Open();

                string query = @"INSERT INTO Prestamos(IdUsuario, IdLibro, FechaPrestamo, FechaDevolucion)VALUES(@IdUsuario, @IdLibro, @FechaPrestamo, @FechaDevolucion)";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdUsuario", cmbUsuario.SelectedValue);
                cmd.Parameters.AddWithValue("@IdLibro", cmbLibro.SelectedValue);
                cmd.Parameters.AddWithValue("@FechaPrestamo", dtpFechaPrestamo.Value.Date);
                cmd.Parameters.AddWithValue("@FechaDevolucion", dtpFechaDevolucion.Value.Date);

                cmd.ExecuteNonQuery();
            }
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Seleccione un préstamo primero");
                return;
            }

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.Conectar())
            {
                cn.Open();

                string query = @"UPDATE Prestamos SET IdUsuario = @IdUsuario, IdLibro = @IdLibro, FechaPrestamo = @FechaPrestamo, FechaDevolucion = @FechaDevolucion WHERE IdPrestamo = @IdPrestamo";

                SqlCommand cmd = new SqlCommand(query, cn);

                cmd.Parameters.AddWithValue("@IdUsuario", cmbUsuario.SelectedValue);
                cmd.Parameters.AddWithValue("@IdLibro", cmbLibro.SelectedValue);
                cmd.Parameters.AddWithValue("@FechaPrestamo", dtpFechaPrestamo.Value.Date);
                cmd.Parameters.AddWithValue("@FechaDevolucion", dtpFechaDevolucion.Value.Date);
                cmd.Parameters.AddWithValue("@IdPrestamo", Convert.ToInt32(txtId.Text));

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Préstamo modificado correctamente");
            CargarPrestamos();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (txtId.Text == "")
            {
                MessageBox.Show("Seleccione un préstamo primero");
                return;
            }

            Conexion conexion = new Conexion();

            using (SqlConnection cn = conexion.Conectar())
            {
                cn.Open();

                string query = "DELETE FROM Prestamos WHERE IdPrestamo = @IdPrestamo";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@IdPrestamo", Convert.ToInt32(txtId.Text));

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Préstamo eliminado correctamente");
            CargarPrestamos();
            Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtId.Clear();

            if (cmbUsuario.Items.Count > 0)
                cmbUsuario.SelectedIndex = 0;

            if (cmbLibro.Items.Count > 0)
                cmbLibro.SelectedIndex = 0;

            dtpFechaPrestamo.Value = DateTime.Today;
            dtpFechaDevolucion.Value = DateTime.Today;
        }

        private void dgvPrestamo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvPrestamo.Rows[e.RowIndex].Cells["IdPrestamo"].Value.ToString();

                cmbUsuario.SelectedValue = Convert.ToInt32(
                    dgvPrestamo.Rows[e.RowIndex].Cells["IdUsuario"].Value
                );

                cmbLibro.SelectedValue = Convert.ToInt32(
                    dgvPrestamo.Rows[e.RowIndex].Cells["IdLibro"].Value
                );

                dtpFechaPrestamo.Value = Convert.ToDateTime(
                    dgvPrestamo.Rows[e.RowIndex].Cells["FechaPrestamo"].Value
                );

                dtpFechaDevolucion.Value = Convert.ToDateTime(
                    dgvPrestamo.Rows[e.RowIndex].Cells["FechaDevolucion"].Value
                );
            }

        }
    }
}
