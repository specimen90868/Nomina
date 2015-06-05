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
    public partial class frmDepartamentos : Form
    {
        public frmDepartamentos()
        {
            InitializeComponent();
        }

        #region VARIABLES GLOBALES
        MySqlConnection cnx;
        MySqlCommand cmd;
        string cdn = ConfigurationManager.ConnectionStrings["cdnNomina"].ConnectionString;
        Departamento.Core.DeptoHelper dh;
        #endregion

        #region VARIABLES PUBLICAS
        public int _tipoOperacion;
        public int _iddepartamento;
        #endregion

        #region DELEGADOS
        public delegate void delOnNuevoDepto(int edicion);
        public event delOnNuevoDepto OnNuevoDepto;
        #endregion
    }
}
