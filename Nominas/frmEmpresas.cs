using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Nominas
{
    public partial class frmEmpresas : Form
    {
        public frmEmpresas()
        {
            InitializeComponent();
        }

        #region VARIABLES GLOBALES
        MySqlConnection cnx;
        MySqlCommand cmd;
        string cdn = ConfigurationManager.ConnectionStrings["cdnNomina"].ConnectionString;
        Empresas.Core.EmpresasHelper eh;
        #endregion
        
        #region DELEGADOS
        public delegate void delOnNuevaEmpresa();
        public event delOnNuevaEmpresa OnNuevaEmpresa;
        #endregion

        #region VARIABLES PUBLICAS
        public int _tipoOperacion;
        public int _idempresa;
        #endregion

        private void toolGuardarCerrar_Click(object sender, EventArgs e)
        {
            guardar(0);
        }

        private void toolGuardarNuevo_Click(object sender, EventArgs e)
        {
            guardar(1);   
        }

        private void guardar(int tipoGuardar)
        {
            //SE VALIDA SI TODOS LOS TEXTBOX HAN SIDO LLENADOS.
            string control = GLOBALES.VALIDAR(this,typeof(TextBox));
            if (!control.Equals(""))
            {
                MessageBox.Show("Falta el campo: " + control, "Información");
                return;
            }

            cnx = new MySqlConnection();
            cnx.ConnectionString = cdn;
            cmd = new MySqlCommand();
            cmd.Connection = cnx;
            eh = new Empresas.Core.EmpresasHelper();
            eh.Command = cmd;

            Empresas.Core.Empresas em = new Empresas.Core.Empresas();
            em.nombre = txtNombre.Text;
            em.rfc = txtRfc.Text;
            em.registro = txtRegistroPatronal.Text;
            em.digitoverificador = int.Parse(txtDigitoVerificador.Text);
            em.sindicato = Convert.ToInt32(chkEsSindicato.Checked);
            em.representante = txtRepresentante.Text;
            em.activo = 1;

            switch (_tipoOperacion)
            {
                case 0:
                    try
                    {
                        cnx.Open();
                        eh.insertaEmpresa(em);
                        cnx.Close();
                        cnx.Dispose();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al ingresar la empresa. \r\n \r\n Error: " + error.Message);
                    }
                    break;
                case 2:
                    try
                    {
                        em.idempresa = _idempresa;
                        cnx.Open();
                        eh.actualizaEmpresa(em);
                        cnx.Close();
                        cnx.Dispose();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al actualizar la empresa. \r\n \r\n Error: " + error.Message);
                    }
                    break;
            }

            switch (tipoGuardar)
            {
                case 0:
                    limpiar(this, typeof(TextBox));
                    break;
                case 1:
                    if (OnNuevaEmpresa != null)
                        OnNuevaEmpresa();
                    this.Dispose();
                    break;
            }
        }

        #region FUNCION LIMPIAR TEXTBOX E INHABILITAR CONTROLES
        private void limpiar(Control control, Type tipo)
        {
            var controls = control.Controls.Cast<Control>();
            foreach (Control c in controls.Where(c => c.GetType() == tipo))
            {
                (c as TextBox).Clear();
            }
            txtRegistroPatronal.Clear();
            chkEsSindicato.Checked = false;
        }

        private void inhabilitar(Control control, Type tipo)
        {
            var controls = control.Controls.Cast<Control>();
            foreach (Control c in controls.Where(c => c.GetType() == tipo))
            {
                (c as TextBox).Enabled = false;
            }
            chkEsSindicato.Enabled = false;
            txtRegistroPatronal.Enabled = false;
            toolGuardarCerrar.Enabled = false;
            toolGuardarNuevo.Enabled = false;
        }
        #endregion

        private void txtRfc_Leave(object sender, EventArgs e)
        {
            string lsPatron = @"^[A-ZÑ&]{3,4}[0-9]{2}[0-1][0-9][0-3][0-9][A-Z,0-9][A-Z,0-9][0-9A]$";
            Regex loRE = new Regex(lsPatron);
            if (!loRE.IsMatch(txtRfc.Text))
                MessageBox.Show("El RFC no es valido. Verifique","Error");
        }

        private void frmEmpresas_Load(object sender, EventArgs e)
        {
            if (_tipoOperacion == 1 || _tipoOperacion == 2)
            {
                cnx = new MySqlConnection();
                cnx.ConnectionString = cdn;
                cmd = new MySqlCommand();
                cmd.Connection = cnx;
                eh = new Empresas.Core.EmpresasHelper();
                eh.Command = cmd;

                List<Empresas.Core.Empresas> lstEmpresa = eh.obtenerEmpresa(_idempresa);

                for (int i = 0; i < lstEmpresa.Count; i++)
                {
                    txtNombre.Text = lstEmpresa[i].nombre;
                    txtRepresentante.Text = lstEmpresa[i].representante;
                    txtRfc.Text = lstEmpresa[i].rfc;
                    txtRegistroPatronal.Text = lstEmpresa[i].registro;
                    txtDigitoVerificador.Text = lstEmpresa[i].digitoverificador.ToString();
                    chkEsSindicato.Checked = Convert.ToBoolean(lstEmpresa[i].sindicato);
                }
                if (_tipoOperacion == 1)
                    inhabilitar(this,typeof(TextBox));
            }
        }

        private void toolCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
