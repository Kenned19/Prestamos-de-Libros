using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrestamoDeLibros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnUsuario_Click(object sender, EventArgs e)
        {
            FrmUsuario frm = new FrmUsuario();
            frm.MdiParent = this;
            frm.Show();

        }

        private void mnLibro_Click(object sender, EventArgs e)
        {
            FrmLibro frm = new FrmLibro();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnPresrtamo_Click(object sender, EventArgs e)
        {
            FrmPrestamo frm = new FrmPrestamo();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
