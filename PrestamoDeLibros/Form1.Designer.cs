namespace PrestamoDeLibros
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnLibro = new System.Windows.Forms.ToolStripMenuItem();
            this.mnPresrtamo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnUsuario,
            this.mnLibro,
            this.mnPresrtamo,
            this.mnSalir});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnUsuario
            // 
            this.mnUsuario.Name = "mnUsuario";
            this.mnUsuario.Size = new System.Drawing.Size(59, 20);
            this.mnUsuario.Text = "Usuario";
            this.mnUsuario.Click += new System.EventHandler(this.mnUsuario_Click);
            // 
            // mnLibro
            // 
            this.mnLibro.Name = "mnLibro";
            this.mnLibro.Size = new System.Drawing.Size(46, 20);
            this.mnLibro.Text = "Libro";
            this.mnLibro.Click += new System.EventHandler(this.mnLibro_Click);
            // 
            // mnPresrtamo
            // 
            this.mnPresrtamo.Name = "mnPresrtamo";
            this.mnPresrtamo.Size = new System.Drawing.Size(69, 20);
            this.mnPresrtamo.Text = "Prestamo";
            this.mnPresrtamo.Click += new System.EventHandler(this.mnPresrtamo_Click);
            // 
            // mnSalir
            // 
            this.mnSalir.Name = "mnSalir";
            this.mnSalir.Size = new System.Drawing.Size(41, 20);
            this.mnSalir.Text = "Salir";
            this.mnSalir.Click += new System.EventHandler(this.mnSalir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnUsuario;
        private System.Windows.Forms.ToolStripMenuItem mnLibro;
        private System.Windows.Forms.ToolStripMenuItem mnPresrtamo;
        private System.Windows.Forms.ToolStripMenuItem mnSalir;
    }
}

