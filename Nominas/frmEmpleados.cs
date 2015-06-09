using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nominas
{
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }

        #region VARIABLES GLOBALES
        MySqlConnection cnx;
        MySqlCommand cmd;
        string cdn = ConfigurationManager.ConnectionStrings["cdnNomina"].ConnectionString;
        Empleados.Core.EmpleadosHelper eh;
        #endregion

        #region DELEGADOS
        public delegate void delOnNuevoEmpleado(int edicion);
        public event delOnNuevoEmpleado OnNuevoEmpleado;
        #endregion

        #region VARIABLES PUBLICAS
        public int _tipoOperacion;
        public int _idempleado;
        #endregion

        private void CargaComboBox()
        {
            cnx = new MySqlConnection();
            cnx.ConnectionString = cdn;
            cmd = new MySqlCommand();
            cmd.Connection = cnx;

            Clientes.Core.ClientesHelper ch = new Clientes.Core.ClientesHelper();
            Catalogos.Core.CatalogosHelper cath = new Catalogos.Core.CatalogosHelper();
            ch.Command = cmd;
            cath.Command = cmd;

            Clientes.Core.Clientes cli = new Clientes.Core.Clientes();
            cli.plaza = GLOBALES.IDPLAZA;
            Catalogos.Core.Catalogo lf = new Catalogos.Core.Catalogo();
            lf.grupodescripcion = "LOCALFORANEO";
            Catalogos.Core.Catalogo sua = new Catalogos.Core.Catalogo();
            sua.grupodescripcion = "SUA";
            Catalogos.Core.Catalogo ts = new Catalogos.Core.Catalogo();
            ts.grupodescripcion = "SALARIO";

            List<Clientes.Core.Clientes> lstClientes = new List<Clientes.Core.Clientes>();
            List<Catalogos.Core.Catalogo> lstLocalForaneo = new List<Catalogos.Core.Catalogo>();
            List<Catalogos.Core.Catalogo> lstSua = new List<Catalogos.Core.Catalogo>();
            List<Catalogos.Core.Catalogo> lstTipoSalario = new List<Catalogos.Core.Catalogo>();

            try
            {
                cnx.Open();
                lstClientes = ch.obtenerClientes(cli);
                lstLocalForaneo = cath.obtenerGrupo(lf);
                lstSua = cath.obtenerGrupo(sua);
                lstTipoSalario = cath.obtenerGrupo(ts);
                cnx.Close();
                cnx.Dispose();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: \r\n \r\n " + error.Message,"Error");
                this.Dispose();
            }
            cmbCliente.DataSource = lstClientes.ToList();
            cmbCliente.DisplayMember = "nombre";
            cmbCliente.ValueMember = "idcliente";

            cmbLocalForaneo.DataSource = lstLocalForaneo.ToList();
            cmbLocalForaneo.DisplayMember = "descripcion";
            cmbLocalForaneo.ValueMember = "valor";

            cmbSua.DataSource = lstSua.ToList();
            cmbSua.DisplayMember = "descripcion";
            cmbSua.ValueMember = "valor";

            cmbTipoSalario.DataSource = lstTipoSalario.ToList();
            cmbTipoSalario.DisplayMember = "descripcion";
            cmbTipoSalario.ValueMember = "valor";
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            CargaComboBox();
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnx = new MySqlConnection();
            cnx.ConnectionString = cdn;
            cmd = new MySqlCommand();
            cmd.Connection = cnx;

            Periodos.Core.PeriodosHelper ph = new Periodos.Core.PeriodosHelper();
            ph.Command = cmd;

            Periodos.Core.Periodos p = new Periodos.Core.Periodos();
            p.idcliente = int.Parse(cmbCliente.SelectedValue.ToString());

            List<Periodos.Core.Periodos> lstPeriodo = new List<Periodos.Core.Periodos>();

            try
            {
                cnx.Open();
                lstPeriodo = ph.obtenerPeriodoCliente(p);
                cnx.Close();
                cnx.Dispose();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: \r\n \r\n " + error.Message,"Error");
                this.Dispose();
            }

            cmbPeriodo.DataSource = lstPeriodo.ToList();
            cmbPeriodo.DisplayMember = "pago";
            cmbPeriodo.ValueMember = "idperiodo";
        }
    }
}
