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

        #region VARIABLES PUBLICAS
        public int _tipoOperacion;
        public int _idempresa;
        public int _iddireccion;
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

            Empresas.Core.Empresas em = new Empresas.Core.Empresas();
            em.nombre = txtNombre.Text;
            em.rfc = txtRfc.Text;
            em.registro = txtRegistroPatronal.Text;
            em.digitoverificador = int.Parse(txtDigitoVerificador.Text);
            em.sindicato = Convert.ToInt32(chkEsSindicato.Checked);
            em.representante = txtRepresentante.Text;
            em.activo = 1;

            dh = new Direccion.Core.DireccionesHelper();
            dh.Command = cmd;

            Direccion.Core.Direcciones d = new Direccion.Core.Direcciones();
            d.calle = txtCalle.Text;
            d.exterior = txtExterior.Text;
            d.interior = txtInterior.Text;
            d.colonia = txtColonia.Text;
            d.ciudad = txtMunicipio.Text;
            d.estado = txtEstado.Text;
            d.pais = txtPais.Text;
            d.cp = txtCP.Text;
            ///TIPO DIRECCION
            ///0 - Dirección fiscal
            ///1 - Dirección sucursal
            ///2 - Dirección personal
            d.tipodireccion = 0;
            ///TIPO PERSONA
            ///0 - Empresa
            ///1 - Cliente
            ///2 - Empleado
            d.tipopersona = 0;

            switch (_tipoOperacion)
            {
                case 0:
                    try
                    {
                        cnx.Open();
                        eh.insertaEmpresa(em);
                        idempresa = (int)eh.obtenerIdEmpresa(em);
                        d.idpersona = idempresa;
                        dh.insertaDireccion(d);
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
                        d.iddireccion = _iddireccion;
                        d.idpersona = _idempresa;
                        cnx.Open();
                        eh.actualizaEmpresa(em);
                        dh.actualizaDireccion(d);
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
            txtCP.Clear();  
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
            txtCP.Enabled = false;
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
            /// _tipoOperacion CONSULTA = 1, EDICION = 2
            if (_tipoOperacion == 1 || _tipoOperacion == 2)
            {
                cnx = new MySqlConnection();
                cnx.ConnectionString = cdn;
                cmd = new MySqlCommand();
                cmd.Connection = cnx;
                eh = new Empresas.Core.EmpresasHelper();
                eh.Command = cmd;

                dh = new Direccion.Core.DireccionesHelper();
                dh.Command = cmd;

                Direccion.Core.Direcciones d = new Direccion.Core.Direcciones();
                d.idpersona = _idempresa;
                d.tipopersona = 0; ///TIPO PERSONA 0 - Empresas
                List<Empresas.Core.Empresas> lstEmpresa;
                List<Direccion.Core.Direcciones> lstDireccion;

                try
                {
                    cnx.Open();
                    lstEmpresa = eh.obtenerEmpresa(_idempresa);
                    lstDireccion = dh.obtenerDireccion(d);
                    cnx.Close();
                    cnx.Dispose();

                    for (int i = 0; i < lstEmpresa.Count; i++)
                    {
                        txtNombre.Text = lstEmpresa[i].nombre;
                        txtRepresentante.Text = lstEmpresa[i].representante;
                        txtRfc.Text = lstEmpresa[i].rfc;
                        txtRegistroPatronal.Text = lstEmpresa[i].registro;
                        txtDigitoVerificador.Text = lstEmpresa[i].digitoverificador.ToString();
                        chkEsSindicato.Checked = Convert.ToBoolean(lstEmpresa[i].sindicato);
                    }

                    for (int i = 0; i < lstDireccion.Count; i++)
                    {
                        _iddireccion = lstDireccion[i].iddireccion;
                        txtCalle.Text = lstDireccion[i].calle;
                        txtExterior.Text = lstDireccion[i].exterior;
                        txtInterior.Text = lstDireccion[i].interior;
                        txtColonia.Text = lstDireccion[i].colonia;
                        txtCP.Text = lstDireccion[i].cp;
                        txtMunicipio.Text = lstDireccion[i].ciudad;
                        txtEstado.Text = lstDireccion[i].estado;
                        txtPais.Text = lstDireccion[i].pais;
                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: \r\n \r\n " + error.Message, "Error");
                }
                
                if (_tipoOperacion == 1)
                {
                    toolTitulo.Text = "Consulta Empresa";
                    inhabilitar(this, typeof(TextBox));
                }
                else
                    toolTitulo.Text = "Edición Empresa";
            }
        }

        private void toolCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
