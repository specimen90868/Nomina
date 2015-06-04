using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nominas
{
    public static class GLOBALES
    {
        public static int IDUSUARIO { get; set; }
        public static int IDPLAZA { get; set; }
        public static int IDPERFIL { get; set; }
        public static int IDEMPRESA { get; set; }
        public static string NOMBREEMPRESA { get; set; }
        public static int SESION { get; set; }

        public static string VALIDAR(Control control, Type tipo)
        {
            string nombre = "";
            var controls = control.Controls.Cast<Control>();
            foreach (Control c in controls.Where(c => c.GetType() == tipo))
            {
                if (string.IsNullOrEmpty(c.Text))
                {
                    nombre = c.Name.Substring(3);
                    break;
                }
            }
            return nombre;
        }

        public static List<Autorizaciones.Core.Ediciones> PERFILEDICIONES(string menu)
        {
            string cdn = ConfigurationManager.ConnectionStrings["cdnNomina"].ConnectionString;
            MySqlConnection cnx = new MySqlConnection(cdn);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            Autorizaciones.Core.AutorizacionHelper ah = new Autorizaciones.Core.AutorizacionHelper();
            ah.Command = cmd;
            List<Autorizaciones.Core.Ediciones> lstEdiciones = null;
            try 
            {
                cnx.Open();
                lstEdiciones = ah.getEdiciones(IDPERFIL.ToString(), menu);
                cnx.Close();
                cnx.Dispose();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: \r\n \r\n " + error.Message,"Error");
            }
            return lstEdiciones;
        }
    }   
}
