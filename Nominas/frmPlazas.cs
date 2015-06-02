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
    public partial class frmPlazas : Form
    {
        public frmPlazas()
        {
            InitializeComponent();
        }

        #region VARIABLES PUBLICAS
        public int _tipoOperacion;
        public int _idplaza;
        #endregion

        #region VARIABLES GLOBALES
        string cdn = ConfigurationManager.ConnectionStrings["cdnNomina"].ConnectionString;
        MySqlConnection cnx;
        MySqlCommand cmd;
        Plaza.Core.PlazasHelper ph;
        #endregion

        #region DELEGADOS
        public delegate void delOnNuevaPlaza(int edicion);
        public event delOnNuevaPlaza OnNuevaPlaza;
        #endregion

        private void toolGuardarCerrar_Click(object sender, EventArgs e)
        {
            Guardar(1);
        }

        private void toolGuardarNuevo_Click(object sender, EventArgs e)
        {
            Guardar(0);
        }

        private void toolCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Guardar(int tipoGuardar)
        {

            //SE VALIDA SI TODOS LOS TEXTBOX HAN SIDO LLENADOS.
            string control = GLOBALES.VALIDAR(this, typeof(TextBox));
            if (!control.Equals(""))
            {
                MessageBox.Show("Falta el campo: " + control, "Información");
                return;
            }

            cnx = new MySqlConnection();
            cnx.ConnectionString = cdn;
            cmd = new MySqlCommand();
            cmd.Connection = cnx;

            ph = new Plaza.Core.PlazasHelper();
            ph.Command = cmd;

            Plaza.Core.Plazas p = new Plaza.Core.Plazas();
            p.nombre = txtNombre.Text;
            p.activo = 1;

            switch (_tipoOperacion)
            {
                case 0:
                    try
                    {
                        cnx.Open();
                        ph.insertaPlaza(p);
                        cnx.Close();
                        cnx.Dispose();

                        if (OnNuevaPlaza != null)
                            OnNuevaPlaza(0);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: \r\n \r\n " + error.Message, "Error");
                    }
                    break;
                case 2:
                    try
                    {
                        cnx.Open();
                        p.id = _idplaza;
                        ph.actualizaPlaza(p);
                        cnx.Close();
                        cnx.Dispose();

                        if (OnNuevaPlaza != null)
                            OnNuevaPlaza(2);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: \r\n \r\n " + error.Message, "Error");
                    }
                    break;
            }

            switch (tipoGuardar)
            {
                case 0:
                    limpiar(this, typeof(TextBox));
                    break;
                case 1:
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
        }

        private void inhabilitar(Control control, Type tipo)
        {
            var controls = control.Controls.Cast<Control>();
            foreach (Control c in controls.Where(c => c.GetType() == tipo))
            {
                (c as TextBox).Enabled = false;
            }
            toolGuardarCerrar.Enabled = false;
            toolGuardarNuevo.Enabled = false;
        }
        #endregion

        private void frmPlazas_Load(object sender, EventArgs e)
        {
            /// _tipoOperacion CONSULTA = 1, EDICION = 2
            if (_tipoOperacion == 1 || _tipoOperacion == 2)
            {
                cnx = new MySqlConnection();
                cnx.ConnectionString = cdn;
                cmd = new MySqlCommand();
                cmd.Connection = cnx;
                ph = new Plaza.Core.PlazasHelper();
                ph.Command = cmd;

                Plaza.Core.Plazas p = new Plaza.Core.Plazas();
                p.id = _idplaza;
                List<Plaza.Core.Plazas> lstPlaza;

                try
                {
                    cnx.Open();
                    lstPlaza = ph.obtenerPlaza(p);
                    cnx.Close();
                    cnx.Dispose();

                    for (int i = 0; i < lstPlaza.Count; i++)
                    {
                        txtNombre.Text = lstPlaza[i].nombre;
                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: \r\n \r\n " + error.Message, "Error");
                }

                if (_tipoOperacion == 1)
                {
                    toolTitulo.Text = "Consulta Plaza";
                    inhabilitar(this, typeof(TextBox));
                }
                else
                    toolTitulo.Text = "Edición Plaza";
            }
        }
    }
}
