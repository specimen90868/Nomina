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
            string control = validar(this,typeof(TextBox));
            if (!control.Equals(""))
            {
                MessageBox.Show("Falta el campo: " + control, "Información");
                return;
            }

            string cdn = ConfigurationManager.ConnectionStrings["cdnNomina"].ConnectionString;
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = cdn;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            Empresas.Core.EmpresasHelper eh = new Empresas.Core.EmpresasHelper();
            eh.Command = cmd;

            Empresas.Core.Empresas em = new Empresas.Core.Empresas();
            em.nombre = txtNombre.Text;
            em.rfc = txtRfc.Text;
            em.registro = txtRegistroPatronal.Text;
            em.digitoverificador = int.Parse(txtDigitoVerificador.Text);
            em.sindicato = Convert.ToInt32(chkEsSindicato.Checked);
            em.representante = txtRepresentante.Text.Equals(0) ? " " : txtRepresentante.Text;

            switch (tipoGuardar)
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
                        MessageBox.Show("Error al ingresar la empresa. \r\n Error: " + error.Message);
                    }
                    break;
                case 1:
                    break;
            }
        }

        private string validar(Control control, Type tipo)
        {
            string nombre = "";
            var controls = control.Controls.Cast<Control>();
            foreach (Control c in controls.Where(c=>c.GetType() == tipo))
            {
                if (string.IsNullOrEmpty(c.Text) || string.IsNullOrWhiteSpace(c.Text))
                {
                    nombre = c.Name.Substring(3);
                    break;
                }
            }
            return nombre;
        }

        private void txtRfc_Leave(object sender, EventArgs e)
        {
            string lsPatron = @"^[A-ZÑ&]{3,4}[0-9]{2}[0-1][0-9][0-3][0-9][A-Z,0-9][A-Z,0-9][0-9A]$";
            Regex loRE = new Regex(lsPatron);
            if (!loRE.IsMatch(txtRfc.Text))
                MessageBox.Show("El RFC no es valido. Verifique","Error");
        }
    }
}
