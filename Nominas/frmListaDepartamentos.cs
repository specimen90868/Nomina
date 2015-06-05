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
    public partial class frmListaDepartamentos : Form
    {
        public frmListaDepartamentos()
        {
            InitializeComponent();
        }

        #region VARIABLES GLOBALES
        MySqlConnection cnx;
        MySqlCommand cmd;
        List<Departamento.Core.Depto> lstDepartamentos;
        #endregion

        private void ListaDepartamentos()
        {
            string cdn = ConfigurationManager.ConnectionStrings["cdnNomina"].ConnectionString;
            cnx = new MySqlConnection(cdn);
            cmd = new MySqlCommand();
            cmd.Connection = cnx;
            Departamento.Core.DeptoHelper dh = new Departamento.Core.DeptoHelper();
            dh.Command = cmd;

            try
            {
                cnx.Open();
                lstDepartamentos = dh.obtenerDepartamentos();
                cnx.Close();
                cnx.Dispose();

                var depto = from d in lstDepartamentos
                          select new
                          {
                              IdDepto = d.id,
                              Nombre = d.descripcion,
                          };
                dgvDepartamentos.DataSource = depto.ToList();

                for (int i = 0; i < dgvDepartamentos.Columns.Count; i++)
                {
                    dgvDepartamentos.AutoResizeColumn(i);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: \r\n \r\n " + error.Message, "Error");
            }
        }

        private void CargaPerfil()
        {
            List<Autorizaciones.Core.Ediciones> lstEdiciones = GLOBALES.PERFILEDICIONES("Departamentos");

            for (int i = 0; i < lstEdiciones.Count; i++)
            {
                switch (lstEdiciones[i].nombre.ToString())
                {
                    case "Departamentos":
                        toolNuevo.Enabled = Convert.ToBoolean(lstEdiciones[i].crear);
                        toolConsultar.Enabled = Convert.ToBoolean(lstEdiciones[i].consulta);
                        toolEditar.Enabled = Convert.ToBoolean(lstEdiciones[i].modificar);
                        toolBaja.Enabled = Convert.ToBoolean(lstEdiciones[i].baja);
                        break;
                }
            }
        }

        private void frmListaDepartamentos_Load(object sender, EventArgs e)
        {
            dgvDepartamentos.RowHeadersVisible = false;
            CargaPerfil();
            ListaDepartamentos();
        }

        private void Seleccion(int edicion)
        {
            frmDepartamentos d = new frmDepartamentos();
            d.OnNuevoDepto += d_OnNuevoDepto;
            int fila = 0;
            if (!edicion.Equals(0))
            {
                fila = dgvDepartamentos.CurrentCell.RowIndex;
                d._iddepartamento = int.Parse(dgvDepartamentos.Rows[fila].Cells[0].Value.ToString());
            }
            d._tipoOperacion = edicion;
            d.Show();
        }

        void d_OnNuevoDepto(int edicion)
        {
            if (edicion == 0 || edicion == 2)
                ListaDepartamentos();
        }

        private void toolNuevo_Click(object sender, EventArgs e)
        {
            Seleccion(0);
        }

        private void toolConsultar_Click(object sender, EventArgs e)
        {
            Seleccion(1);
        }

        private void toolEditar_Click(object sender, EventArgs e)
        {
            Seleccion(2);
        }

        private void toolBaja_Click(object sender, EventArgs e)
        {
            
        }



    }
}
