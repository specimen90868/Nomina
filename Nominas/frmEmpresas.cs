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
        Direccion.Core.DireccionesHelper dh;
        #endregion
        
        #region DELEGADOS
        public delegate void delOnNuevaEmpresa();
        public event delOnNuevaEmpresa OnNuevaEmpresa;
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

            int idempresa;

            cnx = new MySqlConnection();
            cnx.ConnectionString = cdn;
            cmd = new MySqlCommand();
            cmd.Connection = cnx;
            eh = new Empresas.Core.EmpresasHelper();
            eh.Command = cmd;

            dh = new Direccion.Core.DireccionesHelper();
            dh.Command = cmd;

            Empresas.Core.Empresas em = new Empresas.Core.Empresas();
            em.nombre = txtNombre.Text;
            em.rfc = txtRfc.Text;
            em.registro = txtRegistroPatronal.Text;
            em.digitoverificador = int.Parse(txtDigitoVerificador.Text);
            em.sindicato = Convert.ToInt32(chkEsSindicato.Checked);
            em.representante = txtRepresentante.Text;

            Direccion.Core.Direcciones d = new Direccion.Core.Direcciones();
            d.calle = txtCalle.Text;
            d.exterior = txtExterior.Text;
            d.interior = txtInterior.Text;
            d.colonia = txtColonia.Text;
            d.cp = txtCP.Text;
            d.ciudad = txtMunicipio.Text;
            d.estado = txtEstado.Text;
            d.pais = txtPais.Text;
            ///TIPO DIRECCION
            ///0 PARA FISCAL
            ///1 PARA SUCURSALES
            ///2 PARA PERSONALES
            d.tipodireccion = 0;
            ///TIPO PERSONA
            ///0 PARA EMPRESA
            ///1 PARA CLIENTE
            ///2 PARA EMPLEADO
            d.tipopersona = 0;

            switch (tipoGuardar)
            {
                case 0:
                    try
                    {
                        cnx.Open();
                        eh.insertaEmpresa(em);
                        /// SE OBTIENE EL ID DE LA EMPRESA INSERTADA MEDIANTE EL RFC Y REGISTRO PATRONAL
                        idempresa = (int)eh.obtenerIdEmpresa(em);
                        d.idpersona = idempresa;
                        dh.insertaDireccion(d);
                        cnx.Close();
                        cnx.Dispose();

                        if (OnNuevaEmpresa != null)
                            OnNuevaEmpresa();

                        this.Dispose();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al ingresar la empresa. \r\n \r\n Error: " + error.Message);
                    }
                    break;
                case 1:
                    try
                    {
                        
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error al actualizar la empresa. \r\n \r\n Error: " + error.Message);
                    }
                    break;
            }
        }

        #region FUNCION LIMPIAR TEXTBOX
        private void limpiar(Control control, Type tipo)
        {
            var controls = control.Controls.Cast<Control>();
            foreach (Control c in controls.Where(c => c.GetType() == tipo))
            {
                (c as TextBox).Clear();
            }
        }
        #endregion

        private void txtRfc_Leave(object sender, EventArgs e)
        {
            string lsPatron = @"^[A-ZÑ&]{3,4}[0-9]{2}[0-1][0-9][0-3][0-9][A-Z,0-9][A-Z,0-9][0-9A]$";
            Regex loRE = new Regex(lsPatron);
            if (!loRE.IsMatch(txtRfc.Text))
                MessageBox.Show("El RFC no es valido. Verifique","Error");
        }
    }
}
