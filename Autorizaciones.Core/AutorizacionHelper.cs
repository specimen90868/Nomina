using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Autorizaciones.Core
{
    public class AutorizacionHelper : Data.Obj.DataObj
    {
        public List<Autorizaciones> getAutorizacion(string idusuario)
        {
            List<Autorizaciones> auth = new List<Autorizaciones>();
            DataTable dtAuth = new DataTable();
            Command.CommandText = "call spAutorizacion (@idusuario)";
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("idusuario", idusuario);
            dtAuth = SelectData(Command);
            for (int i = 0; i < dtAuth.Rows.Count; i++)
            {
                Autorizaciones a = new Autorizaciones();
                a.idusuario = int.Parse(dtAuth.Rows[i]["idusuario"].ToString());
                a.usuario = dtAuth.Rows[i]["usuario"].ToString();
                a.idperfil = int.Parse(dtAuth.Rows[i]["idperfil"].ToString());
                a.nombre = dtAuth.Rows[i]["nombre"].ToString();
                a.modulo = dtAuth.Rows[i]["modulo"].ToString();
                a.acceso = int.Parse(dtAuth.Rows[i]["acceso"].ToString());
                auth.Add(a);
            }
            return auth;
        }


        public List<Menus> getMenus(string idperfil)
        {
            List<Menus> menu = new List<Menus>();
            DataTable dtMenu = new DataTable();
            Command.CommandText = "select m.nombre, ver from menus m left join ediciones e on m.idmenu = e.idmenu where e.idperfil = @idperfil and m.tipomenu = 0;";
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("idperfil", idperfil);
            dtMenu = SelectData(Command);
            for (int i = 0; i < dtMenu.Rows.Count; i++)
            {
                Menus m = new Menus();
                m.nombre = dtMenu.Rows[i]["nombre"].ToString();
                m.ver = int.Parse(dtMenu.Rows[i]["ver"].ToString());
                menu.Add(m);
            }
            return menu;
        }
    }
}

