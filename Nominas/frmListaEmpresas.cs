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

namespace Nominas
{
    public partial class frmListaEmpresas : Form
    {
        public frmListaEmpresas()
        {
            InitializeComponent();
        }

        #region VARIABLES GLOBALES
        MySqlConnection cnx;
        MySqlCommand cmd;
        List<Empresas.Core.Empresas> lstEmpresas;
        #endregion

        private void frmListaEmpresas_Load(object sender, EventArgs e)
        {
            dgvEmpresas.RowHeadersVisible = false;
            CargaPerfil();
            ListaEmpresas();
        }

        private void ListaEmpresas()
        {
            string cdn = ConfigurationManager.ConnectionStrings["cdnNomina"].ConnectionString;
            cnx = new MySqlConnection(cdn);
            cmd = new MySqlCommand();
            cmd.Connection = cnx;
            Empresas.Core.EmpresasHelper eh = new Empresas.Core.EmpresasHelper();
            eh.Command = cmd;
            try
            {
                cnx.Open();
                lstEmpresas = eh.obtenerEmpresas();
                cnx.Close();
                cnx.Dispose();

                var em = from e in lstEmpresas 
                         select new 
                         { IdEmpresa = e.idempresa, Nombre = e.nombre, RFC = e.rfc, Registro = e.registro + e.digitoverificador,
                         Representante = e.representante };
                dgvEmpresas.DataSource = em.ToList();

                for (int i = 0; i < dgvEmpresas.Columns.Count; i++)
                {
                    dgvEmpresas.AutoResizeColumn(i);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: \r\n \r\n " + error.Message, "Error");
            }
        }

        private void CargaPerfil()
        {
            List<Autorizaciones.Core.Ediciones> lstEdiciones = GLOBALES.PERFILEDICIONES("Empresas");
            
            for (int i = 0; i < lstEdiciones.Count; i++)
            {
                switch (lstEdiciones[i].nombre.ToString())
                {
                    case "Empresas":
                        toolNuevo.Enabled = Convert.ToBoolean(lstEdiciones[i].crear);
                        toolConsultar.Enabled = Convert.ToBoolean(lstEdiciones[i].consulta);
                        toolEditar.Enabled = Convert.ToBoolean(lstEdiciones[i].modificar);
                        toolBaja.Enabled = Convert.ToBoolean(lstEdiciones[i].baja);
                        break;
                }
            }
        }

        #region TEXBOX BUSCAR
        private void txtBuscar_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            txtBuscar.Font = new Font("Arial", 9);
            txtBuscar.ForeColor = System.Drawing.Color.Black;
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtBuscar.Text) || string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    var em = from b in lstEmpresas
                             select new
                             {
                                 IdEmpresa = b.idempresa,
                                 Nombre = b.nombre,
                                 RFC = b.rfc,
                                 Registro = b.registro + b.digitoverificador,
                                 Representante = b.representante
                             };
                    dgvEmpresas.DataSource = em.ToList();
                }
                else 
                {
                    var busqueda = from b in lstEmpresas
                                   where b.nombre.Contains(txtBuscar.Text.ToUpper())
                                   select new
                                   {
                                       IdEmpresa = b.idempresa,
                                       Nombre = b.nombre,
                                       RFC = b.rfc,
                                       Registro = b.registro + b.digitoverificador,
                                       Representante = b.representante
                                   };
                    dgvEmpresas.DataSource = busqueda.ToList();
                }
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            txtBuscar.Text = "Buscar empresa...";
            txtBuscar.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            txtBuscar.ForeColor = System.Drawing.Color.Gray;
        }
        #endregion

        private void dgvEmpresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolNuevo_Click(object sender, EventArgs e)
        {
            SeleccionaEmpresa(0);
        }

        private void toolConsultar_Click(object sender, EventArgs e)
        {
            SeleccionaEmpresa(1);
        }

        private void toolEditar_Click(object sender, EventArgs e)
        {
            SeleccionaEmpresa(2);
        }

        private void SeleccionaEmpresa(int edicion)
        {
            int fila = dgvEmpresas.CurrentCell.RowIndex;
            frmEmpresas e = new frmEmpresas();
            e._tipoOperacion = edicion;
            e._idempresa = int.Parse(dgvEmpresas.Rows[fila].Cells[0].Value.ToString());
            e.Show();
        }
    }
}
