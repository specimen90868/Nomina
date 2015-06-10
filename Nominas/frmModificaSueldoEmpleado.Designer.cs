namespace Nominas
{
    partial class frmModificaSueldoEmpleado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificaSueldoEmpleado));
            this.toolAcciones = new System.Windows.Forms.ToolStrip();
            this.toolTitulo = new System.Windows.Forms.ToolStripLabel();
            this.toolEmpleado = new System.Windows.Forms.ToolStrip();
            this.toolGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolBuscar = new System.Windows.Forms.ToolStripButton();
            this.toolCerrar = new System.Windows.Forms.ToolStripButton();
            this.toolAcciones.SuspendLayout();
            this.toolEmpleado.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolAcciones
            // 
            this.toolAcciones.BackColor = System.Drawing.Color.DarkGray;
            this.toolAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTitulo});
            this.toolAcciones.Location = new System.Drawing.Point(0, 0);
            this.toolAcciones.Name = "toolAcciones";
            this.toolAcciones.Size = new System.Drawing.Size(567, 27);
            this.toolAcciones.TabIndex = 3;
            this.toolAcciones.Text = "toolAcciones";
            // 
            // toolTitulo
            // 
            this.toolTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolTitulo.Name = "toolTitulo";
            this.toolTitulo.Size = new System.Drawing.Size(164, 24);
            this.toolTitulo.Text = "Modificar sueldo";
            // 
            // toolEmpleado
            // 
            this.toolEmpleado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolGuardar,
            this.toolBuscar,
            this.toolCerrar});
            this.toolEmpleado.Location = new System.Drawing.Point(0, 27);
            this.toolEmpleado.Name = "toolEmpleado";
            this.toolEmpleado.Size = new System.Drawing.Size(567, 25);
            this.toolEmpleado.TabIndex = 4;
            this.toolEmpleado.Text = "toolEmpresa";
            // 
            // toolGuardar
            // 
            this.toolGuardar.Image = ((System.Drawing.Image)(resources.GetObject("toolGuardar.Image")));
            this.toolGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolGuardar.Name = "toolGuardar";
            this.toolGuardar.Size = new System.Drawing.Size(69, 22);
            this.toolGuardar.Text = "Guardar";
            this.toolGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolBuscar
            // 
            this.toolBuscar.Image = ((System.Drawing.Image)(resources.GetObject("toolBuscar.Image")));
            this.toolBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBuscar.Name = "toolBuscar";
            this.toolBuscar.Size = new System.Drawing.Size(62, 22);
            this.toolBuscar.Text = "Buscar";
            // 
            // toolCerrar
            // 
            this.toolCerrar.Image = ((System.Drawing.Image)(resources.GetObject("toolCerrar.Image")));
            this.toolCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCerrar.Name = "toolCerrar";
            this.toolCerrar.Size = new System.Drawing.Size(59, 22);
            this.toolCerrar.Text = "Cerrar";
            // 
            // frmModificaSueldoEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 448);
            this.Controls.Add(this.toolEmpleado);
            this.Controls.Add(this.toolAcciones);
            this.Name = "frmModificaSueldoEmpleado";
            this.Text = "Modificar sueldo";
            this.toolAcciones.ResumeLayout(false);
            this.toolAcciones.PerformLayout();
            this.toolEmpleado.ResumeLayout(false);
            this.toolEmpleado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStrip toolAcciones;
        internal System.Windows.Forms.ToolStripLabel toolTitulo;
        internal System.Windows.Forms.ToolStrip toolEmpleado;
        internal System.Windows.Forms.ToolStripButton toolGuardar;
        private System.Windows.Forms.ToolStripButton toolBuscar;
        private System.Windows.Forms.ToolStripButton toolCerrar;
    }
}