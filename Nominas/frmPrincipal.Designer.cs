namespace Nominas
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbrirEmpresa = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCerrarEmpresa = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mniIniciarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.nuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRecursosHumanos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmpleados = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFotografias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExpedientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBajas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCatalogos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDepartamentos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPuestos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPeriodos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFactores = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalarioMinimo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPlazas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConfiguracion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPerfiles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCambiarContrasenia = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPreferencias = new System.Windows.Forms.ToolStripMenuItem();
            this.workPerfil = new System.ComponentModel.BackgroundWorker();
            this.stsPrincipal = new System.Windows.Forms.StatusStrip();
            this.cargaPerfil = new System.Windows.Forms.ToolStripProgressBar();
            this.mnuEmpresas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrincipal.SuspendLayout();
            this.stsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArchivo,
            this.mnuRecursosHumanos,
            this.mnuCatalogos,
            this.mnuConfiguracion});
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Size = new System.Drawing.Size(1045, 24);
            this.mnuPrincipal.TabIndex = 1;
            this.mnuPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            this.mnuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbrirEmpresa,
            this.mnuCerrarEmpresa,
            this.toolStripSeparator1,
            this.mniIniciarSesion,
            this.nuCerrarSesion,
            this.toolStripSeparator4,
            this.mnuSalir});
            this.mnuArchivo.Name = "mnuArchivo";
            this.mnuArchivo.Size = new System.Drawing.Size(60, 20);
            this.mnuArchivo.Text = "Archivo";
            // 
            // mnuAbrirEmpresa
            // 
            this.mnuAbrirEmpresa.Name = "mnuAbrirEmpresa";
            this.mnuAbrirEmpresa.Size = new System.Drawing.Size(154, 22);
            this.mnuAbrirEmpresa.Text = "Abrir Empresa";
            this.mnuAbrirEmpresa.Click += new System.EventHandler(this.mnuAbrirEmpresa_Click);
            // 
            // mnuCerrarEmpresa
            // 
            this.mnuCerrarEmpresa.Name = "mnuCerrarEmpresa";
            this.mnuCerrarEmpresa.Size = new System.Drawing.Size(154, 22);
            this.mnuCerrarEmpresa.Text = "Cerrar Empresa";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
            // 
            // mniIniciarSesion
            // 
            this.mniIniciarSesion.Name = "mniIniciarSesion";
            this.mniIniciarSesion.Size = new System.Drawing.Size(154, 22);
            this.mniIniciarSesion.Text = "Iniciar sesión";
            this.mniIniciarSesion.Click += new System.EventHandler(this.mniIniciarSesion_Click);
            // 
            // nuCerrarSesion
            // 
            this.nuCerrarSesion.Name = "nuCerrarSesion";
            this.nuCerrarSesion.Size = new System.Drawing.Size(154, 22);
            this.nuCerrarSesion.Text = "Cerrar sesión";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(151, 6);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(154, 22);
            this.mnuSalir.Text = "Salir";
            // 
            // mnuRecursosHumanos
            // 
            this.mnuRecursosHumanos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEmpleados,
            this.mnuFotografias,
            this.mnuExpedientes,
            this.mnuBajas});
            this.mnuRecursosHumanos.Name = "mnuRecursosHumanos";
            this.mnuRecursosHumanos.Size = new System.Drawing.Size(121, 20);
            this.mnuRecursosHumanos.Text = "Recursos Humanos";
            // 
            // mnuEmpleados
            // 
            this.mnuEmpleados.Name = "mnuEmpleados";
            this.mnuEmpleados.Size = new System.Drawing.Size(136, 22);
            this.mnuEmpleados.Text = "Empleados";
            // 
            // mnuFotografias
            // 
            this.mnuFotografias.Name = "mnuFotografias";
            this.mnuFotografias.Size = new System.Drawing.Size(136, 22);
            this.mnuFotografias.Text = "Fotografias";
            // 
            // mnuExpedientes
            // 
            this.mnuExpedientes.Name = "mnuExpedientes";
            this.mnuExpedientes.Size = new System.Drawing.Size(136, 22);
            this.mnuExpedientes.Text = "Expedientes";
            // 
            // mnuBajas
            // 
            this.mnuBajas.Name = "mnuBajas";
            this.mnuBajas.Size = new System.Drawing.Size(136, 22);
            this.mnuBajas.Text = "Bajas";
            // 
            // mnuCatalogos
            // 
            this.mnuCatalogos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClientes,
            this.mnuDepartamentos,
            this.mnuPuestos,
            this.mnuPeriodos,
            this.mnuFactores,
            this.mnuSalarioMinimo,
            this.mnuPlazas});
            this.mnuCatalogos.Name = "mnuCatalogos";
            this.mnuCatalogos.Size = new System.Drawing.Size(72, 20);
            this.mnuCatalogos.Text = "Catálogos";
            // 
            // mnuClientes
            // 
            this.mnuClientes.Name = "mnuClientes";
            this.mnuClientes.Size = new System.Drawing.Size(155, 22);
            this.mnuClientes.Text = "Clientes";
            // 
            // mnuDepartamentos
            // 
            this.mnuDepartamentos.Name = "mnuDepartamentos";
            this.mnuDepartamentos.Size = new System.Drawing.Size(155, 22);
            this.mnuDepartamentos.Text = "Departamentos";
            // 
            // mnuPuestos
            // 
            this.mnuPuestos.Name = "mnuPuestos";
            this.mnuPuestos.Size = new System.Drawing.Size(155, 22);
            this.mnuPuestos.Text = "Puestos";
            // 
            // mnuPeriodos
            // 
            this.mnuPeriodos.Name = "mnuPeriodos";
            this.mnuPeriodos.Size = new System.Drawing.Size(155, 22);
            this.mnuPeriodos.Text = "Periodos";
            // 
            // mnuFactores
            // 
            this.mnuFactores.Name = "mnuFactores";
            this.mnuFactores.Size = new System.Drawing.Size(155, 22);
            this.mnuFactores.Text = "Factores";
            // 
            // mnuSalarioMinimo
            // 
            this.mnuSalarioMinimo.Name = "mnuSalarioMinimo";
            this.mnuSalarioMinimo.Size = new System.Drawing.Size(155, 22);
            this.mnuSalarioMinimo.Text = "Salario minimo";
            // 
            // mnuPlazas
            // 
            this.mnuPlazas.Name = "mnuPlazas";
            this.mnuPlazas.Size = new System.Drawing.Size(155, 22);
            this.mnuPlazas.Text = "Plazas";
            // 
            // mnuConfiguracion
            // 
            this.mnuConfiguracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEmpresas,
            this.mnuUsuarios,
            this.mnuPerfiles,
            this.mnuCambiarContrasenia,
            this.toolStripSeparator2,
            this.mnuPreferencias});
            this.mnuConfiguracion.Name = "mnuConfiguracion";
            this.mnuConfiguracion.Size = new System.Drawing.Size(95, 20);
            this.mnuConfiguracion.Text = "Configuración";
            // 
            // mnuUsuarios
            // 
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(180, 22);
            this.mnuUsuarios.Text = "Usuarios";
            // 
            // mnuPerfiles
            // 
            this.mnuPerfiles.Name = "mnuPerfiles";
            this.mnuPerfiles.Size = new System.Drawing.Size(180, 22);
            this.mnuPerfiles.Text = "Perfiles";
            // 
            // mnuCambiarContrasenia
            // 
            this.mnuCambiarContrasenia.Name = "mnuCambiarContrasenia";
            this.mnuCambiarContrasenia.Size = new System.Drawing.Size(180, 22);
            this.mnuCambiarContrasenia.Text = "Cambiar contraseña";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuPreferencias
            // 
            this.mnuPreferencias.Name = "mnuPreferencias";
            this.mnuPreferencias.Size = new System.Drawing.Size(180, 22);
            this.mnuPreferencias.Text = "Preferencias";
            // 
            // workPerfil
            // 
            this.workPerfil.WorkerReportsProgress = true;
            this.workPerfil.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workPerfil_DoWork);
            this.workPerfil.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.workPerfil_ProgressChanged);
            // 
            // stsPrincipal
            // 
            this.stsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargaPerfil});
            this.stsPrincipal.Location = new System.Drawing.Point(0, 720);
            this.stsPrincipal.Name = "stsPrincipal";
            this.stsPrincipal.Size = new System.Drawing.Size(1045, 22);
            this.stsPrincipal.TabIndex = 3;
            this.stsPrincipal.Text = "statusStrip1";
            // 
            // cargaPerfil
            // 
            this.cargaPerfil.Name = "cargaPerfil";
            this.cargaPerfil.Size = new System.Drawing.Size(100, 16);
            // 
            // mnuEmpresas
            // 
            this.mnuEmpresas.Name = "mnuEmpresas";
            this.mnuEmpresas.Size = new System.Drawing.Size(180, 22);
            this.mnuEmpresas.Text = "Empresas";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 742);
            this.Controls.Add(this.stsPrincipal);
            this.Controls.Add(this.mnuPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuPrincipal;
            this.Name = "frmPrincipal";
            this.Text = "Sistema de Nomina";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.mnuPrincipal.ResumeLayout(false);
            this.mnuPrincipal.PerformLayout();
            this.stsPrincipal.ResumeLayout(false);
            this.stsPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivo;
        private System.Windows.Forms.ToolStripMenuItem mnuAbrirEmpresa;
        private System.Windows.Forms.ToolStripMenuItem mnuCerrarEmpresa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.ToolStripMenuItem mnuConfiguracion;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuPreferencias;
        private System.Windows.Forms.ToolStripMenuItem mnuCatalogos;
        private System.Windows.Forms.ToolStripMenuItem mnuClientes;
        private System.Windows.Forms.ToolStripMenuItem mnuDepartamentos;
        private System.Windows.Forms.ToolStripMenuItem mnuPuestos;
        private System.Windows.Forms.ToolStripMenuItem mnuPeriodos;
        private System.Windows.Forms.ToolStripMenuItem mnuFactores;
        private System.Windows.Forms.ToolStripMenuItem mnuSalarioMinimo;
        private System.Windows.Forms.ToolStripMenuItem mnuPlazas;
        private System.Windows.Forms.ToolStripMenuItem mnuRecursosHumanos;
        private System.Windows.Forms.ToolStripMenuItem mnuEmpleados;
        private System.Windows.Forms.ToolStripMenuItem mnuFotografias;
        private System.Windows.Forms.ToolStripMenuItem mnuExpedientes;
        private System.Windows.Forms.ToolStripMenuItem mnuBajas;
        private System.Windows.Forms.ToolStripMenuItem mniIniciarSesion;
        private System.Windows.Forms.ToolStripMenuItem nuCerrarSesion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuCambiarContrasenia;
        private System.Windows.Forms.ToolStripMenuItem mnuPerfiles;
        private System.ComponentModel.BackgroundWorker workPerfil;
        private System.Windows.Forms.StatusStrip stsPrincipal;
        private System.Windows.Forms.ToolStripProgressBar cargaPerfil;
        private System.Windows.Forms.ToolStripMenuItem mnuEmpresas;
    }
}

