namespace Nominas
{
    partial class frmEmpresas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpresas));
            this.txtRepresentante = new System.Windows.Forms.TextBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.toolEmpresa = new System.Windows.Forms.ToolStrip();
            this.toolGuardarCerrar = new System.Windows.Forms.ToolStripButton();
            this.toolGuardarNuevo = new System.Windows.Forms.ToolStripButton();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.toolAcciones = new System.Windows.Forms.ToolStrip();
            this.tituloRegistro = new System.Windows.Forms.ToolStripLabel();
            this.chkEsSindicato = new System.Windows.Forms.CheckBox();
            this.txtRfc = new System.Windows.Forms.TextBox();
            this.txtRegistroPatronal = new System.Windows.Forms.MaskedTextBox();
            this.txtDigitoVerificador = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label11 = new System.Windows.Forms.Label();
            this.Panel2.SuspendLayout();
            this.toolEmpresa.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.toolAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRepresentante
            // 
            this.txtRepresentante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRepresentante.Location = new System.Drawing.Point(135, 144);
            this.txtRepresentante.Name = "txtRepresentante";
            this.txtRepresentante.Size = new System.Drawing.Size(425, 20);
            this.txtRepresentante.TabIndex = 2;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(52, 147);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(80, 13);
            this.Label16.TabIndex = 146;
            this.Label16.Text = "Representante:";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.Location = new System.Drawing.Point(14, 187);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(81, 18);
            this.Label15.TabIndex = 145;
            this.Label15.Text = "Registros";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(14, 72);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(138, 18);
            this.Label12.TabIndex = 143;
            this.Label12.Text = "Nombre empresa";
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.toolEmpresa);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel2.Location = new System.Drawing.Point(0, 28);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(723, 28);
            this.Panel2.TabIndex = 142;
            // 
            // toolEmpresa
            // 
            this.toolEmpresa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolGuardarCerrar,
            this.toolGuardarNuevo});
            this.toolEmpresa.Location = new System.Drawing.Point(0, 0);
            this.toolEmpresa.Name = "toolEmpresa";
            this.toolEmpresa.Size = new System.Drawing.Size(723, 25);
            this.toolEmpresa.TabIndex = 0;
            this.toolEmpresa.Text = "toolEmpresa";
            // 
            // toolGuardarCerrar
            // 
            this.toolGuardarCerrar.Image = ((System.Drawing.Image)(resources.GetObject("toolGuardarCerrar.Image")));
            this.toolGuardarCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolGuardarCerrar.Name = "toolGuardarCerrar";
            this.toolGuardarCerrar.Size = new System.Drawing.Size(113, 22);
            this.toolGuardarCerrar.Text = "Guardar y Cerrar";
            this.toolGuardarCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolGuardarCerrar.Click += new System.EventHandler(this.toolGuardarCerrar_Click);
            // 
            // toolGuardarNuevo
            // 
            this.toolGuardarNuevo.Image = ((System.Drawing.Image)(resources.GetObject("toolGuardarNuevo.Image")));
            this.toolGuardarNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolGuardarNuevo.Name = "toolGuardarNuevo";
            this.toolGuardarNuevo.Size = new System.Drawing.Size(116, 22);
            this.toolGuardarNuevo.Text = "Guardar y Nuevo";
            this.toolGuardarNuevo.Click += new System.EventHandler(this.toolGuardarNuevo_Click);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.toolAcciones);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(723, 28);
            this.Panel1.TabIndex = 141;
            // 
            // toolAcciones
            // 
            this.toolAcciones.BackColor = System.Drawing.Color.DarkGray;
            this.toolAcciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tituloRegistro});
            this.toolAcciones.Location = new System.Drawing.Point(0, 0);
            this.toolAcciones.Name = "toolAcciones";
            this.toolAcciones.Size = new System.Drawing.Size(723, 27);
            this.toolAcciones.TabIndex = 0;
            this.toolAcciones.Text = "toolAcciones";
            // 
            // tituloRegistro
            // 
            this.tituloRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloRegistro.Name = "tituloRegistro";
            this.tituloRegistro.Size = new System.Drawing.Size(157, 24);
            this.tituloRegistro.Text = "Nueva empresa";
            // 
            // chkEsSindicato
            // 
            this.chkEsSindicato.AutoSize = true;
            this.chkEsSindicato.Location = new System.Drawing.Point(575, 120);
            this.chkEsSindicato.Name = "chkEsSindicato";
            this.chkEsSindicato.Size = new System.Drawing.Size(85, 17);
            this.chkEsSindicato.TabIndex = 6;
            this.chkEsSindicato.Text = "Es Sindicato";
            this.chkEsSindicato.UseVisualStyleBackColor = true;
            // 
            // txtRfc
            // 
            this.txtRfc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRfc.Location = new System.Drawing.Point(138, 220);
            this.txtRfc.Name = "txtRfc";
            this.txtRfc.Size = new System.Drawing.Size(76, 20);
            this.txtRfc.TabIndex = 3;
            this.txtRfc.Leave += new System.EventHandler(this.txtRfc_Leave);
            // 
            // txtRegistroPatronal
            // 
            this.txtRegistroPatronal.Location = new System.Drawing.Point(139, 246);
            this.txtRegistroPatronal.Mask = "AAAAAAAAAA";
            this.txtRegistroPatronal.Name = "txtRegistroPatronal";
            this.txtRegistroPatronal.Size = new System.Drawing.Size(75, 20);
            this.txtRegistroPatronal.TabIndex = 4;
            // 
            // txtDigitoVerificador
            // 
            this.txtDigitoVerificador.Location = new System.Drawing.Point(377, 220);
            this.txtDigitoVerificador.Name = "txtDigitoVerificador";
            this.txtDigitoVerificador.Size = new System.Drawing.Size(21, 20);
            this.txtDigitoVerificador.TabIndex = 5;
            this.txtDigitoVerificador.Text = "0";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(41, 249);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(91, 13);
            this.Label9.TabIndex = 120;
            this.Label9.Text = "Registro Patronal:";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(134, 118);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(426, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(39, 121);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(93, 13);
            this.Label1.TabIndex = 119;
            this.Label1.Text = "Nombre completo:";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(92, 223);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(40, 13);
            this.Label8.TabIndex = 115;
            this.Label8.Text = "R.F.C.:";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(284, 223);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(90, 13);
            this.Label11.TabIndex = 124;
            this.Label11.Text = "Digito Verificador:";
            // 
            // frmEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 519);
            this.Controls.Add(this.txtRepresentante);
            this.Controls.Add(this.Label16);
            this.Controls.Add(this.Label15);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.chkEsSindicato);
            this.Controls.Add(this.txtRfc);
            this.Controls.Add(this.txtRegistroPatronal);
            this.Controls.Add(this.txtDigitoVerificador);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Label8);
            this.Name = "frmEmpresas";
            this.Text = "Empresa";
            this.Load += new System.EventHandler(this.frmEmpresas_Load);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.toolEmpresa.ResumeLayout(false);
            this.toolEmpresa.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.toolAcciones.ResumeLayout(false);
            this.toolAcciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtRepresentante;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.ToolStrip toolEmpresa;
        internal System.Windows.Forms.ToolStripButton toolGuardarCerrar;
        internal System.Windows.Forms.ToolStripButton toolGuardarNuevo;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.ToolStrip toolAcciones;
        internal System.Windows.Forms.ToolStripLabel tituloRegistro;
        internal System.Windows.Forms.CheckBox chkEsSindicato;
        internal System.Windows.Forms.TextBox txtRfc;
        internal System.Windows.Forms.MaskedTextBox txtRegistroPatronal;
        internal System.Windows.Forms.TextBox txtDigitoVerificador;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox txtNombre;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label11;
    }
}