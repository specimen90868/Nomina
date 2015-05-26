using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Nominas
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        #region VARIABLES GLOBALES
        string cdn = ConfigurationManager.ConnectionStrings["cdnNomina"].ConnectionString;
        MySqlConnection cnx;
        MySqlCommand cmd;
        #endregion

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            workPerfil.RunWorkerAsync();
        }

        private void workPerfil_DoWork(object sender, DoWorkEventArgs e)
        {
            cnx = new MySqlConnection();
            cmd = new MySqlCommand();

            cnx.ConnectionString = cdn;
            cmd.Connection = cnx;

            Autorizaciones.Core.AutorizacionHelper ah = new Autorizaciones.Core.AutorizacionHelper();
            ah.Command = cmd;

            cnx.Open();
             
            List<Autorizaciones.Core.Autorizaciones> lstAuth = ah.getAutorizacion(GLOBALES.IDUSUARIO.ToString());
            List<Autorizaciones.Core.Menus> lstMenu = ah.getMenus(GLOBALES.IDPERFIL.ToString());

            cnx.Close();
            cnx.Dispose();

            for (int i = 0; i < lstAuth.Count; i++)
            {
                switch (lstAuth[i].modulo.ToString())
                {
                    case "Recursos Humanos":
                        mnuRecursosHumanos.Enabled = Convert.ToBoolean(lstAuth[i].acceso);
                        break;
                    case "Catálogos":
                        mnuCatalogos.Enabled = Convert.ToBoolean(lstAuth[i].acceso);
                        break;
                    case "Configuración":
                        mnuConfiguracion.Enabled = Convert.ToBoolean(lstAuth[i].acceso);
                        break;
                }
            }

            for (int i = 0; i < lstMenu.Count; i++)
            {
                switch (lstMenu[i].nombre.ToString())
                {
                    case "Empleados":
                        mnuEmpleados.Enabled = Convert.ToBoolean(lstMenu[i].ver);
                        break;
                    case "Fotografías":
                        mnuFotografias.Enabled = Convert.ToBoolean(lstMenu[i].ver);
                        break;
                    case "Expedientes":
                        mnuExpedientes.Enabled = Convert.ToBoolean(lstMenu[i].ver);
                        break;
                    case "Bajas":
                        mnuBajas.Enabled = Convert.ToBoolean(lstMenu[i].ver);
                        break;
                    case "Empresas":
                        mnuEmpresas.Enabled = Convert.ToBoolean(lstMenu[i].ver);
                        break;
                    case "Clientes":
                        mnuClientes.Enabled = Convert.ToBoolean(lstMenu[i].ver);
                        break;
                    case "Departamentos":
                        mnuDepartamentos.Enabled = Convert.ToBoolean(lstMenu[i].ver);
                        break;
                    case "Puestos":
                        mnuPuestos.Enabled = Convert.ToBoolean(lstMenu[i].ver);
                        break;
                    case "Periodos":
                        mnuPeriodos.Enabled = Convert.ToBoolean(lstMenu[i].ver);
                        break;
                    case "Factores":
                        mnuFactores.Enabled = Convert.ToBoolean(lstMenu[i].ver);
                        break;
                    case "Salario minimo":
                        mnuSalarioMinimo.Enabled = Convert.ToBoolean(lstMenu[i].ver);
                        break;
                    case "Plazas":
                        mnuPlazas.Enabled = Convert.ToBoolean(lstMenu[i].ver);
                        break;
                    case "Usuarios":
                        mnuUsuarios.Enabled = Convert.ToBoolean(lstMenu[i].ver);
                        break;
                    case "Perfiles":
                        mnuPerfiles.Enabled = Convert.ToBoolean(lstMenu[i].ver);
                        break;
                    case "Preferencias":
                        mnuPreferencias.Enabled = Convert.ToBoolean(lstMenu[i].ver);
                        break;
                }
            }

            workPerfil.ReportProgress(100);
        }

        private void workPerfil_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //cargaPerfil.Value = e.ProgressPercentage;
        }

        private void mniIniciarSesion_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuAbrirEmpresa_Click(object sender, EventArgs e)
        {
            frmSeleccionarEmpresa frmEmpresa = new frmSeleccionarEmpresa();
            frmEmpresa.OnAbrirEmpresa += frmEmpresa_OnAbrirEmpresa;
            frmEmpresa.MdiParent = this;
            frmEmpresa.Show();
        }

        void frmEmpresa_OnAbrirEmpresa()
        {
            this.Text = "Sistema de Nomina - [" + GLOBALES.NOMBREEMPRESA + "]"; 
        }

        private void mnuEmpresas_Click(object sender, EventArgs e)
        {
            frmListaEmpresas le = new frmListaEmpresas();
            le.MdiParent = this;
            le.WindowState = FormWindowState.Maximized;
            le.Show();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
