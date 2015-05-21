using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Usuarios.Core
{
    public class UsuariosHelper : Data.Obj.DataObj
    {
        public List<Usuarios> getUsuarios()
        {
            List<Usuarios> lstUsuarios = new List<Usuarios>();
            DataTable dtUsuarios = new DataTable();
            Command.CommandText = "select idusuario, usuario, nombre, activo, plaza from usuarios";
            dtUsuarios = SelectData(Command);
            for (int i = 0; i < dtUsuarios.Rows.Count; i++)
            {
                Usuarios usuario = new Usuarios();
                usuario.idusuario = int.Parse(dtUsuarios.Rows[i]["idusuario"].ToString());
                usuario.usuario = dtUsuarios.Rows[i]["usuario"].ToString();
                usuario.nombre = dtUsuarios.Rows[i]["nombre"].ToString();
                usuario.activo = int.Parse(dtUsuarios.Rows[i]["activo"].ToString());
                usuario.plaza = int.Parse(dtUsuarios.Rows[i]["plaza"].ToString());
                lstUsuarios.Add(usuario);
            }
            return lstUsuarios;
        }


        public DataTable getUsuario(string idusuario)
        {
            DataTable dtUsuario = new DataTable();
            Command.CommandText = "select idusuario, usuario, nombre, activo, plaza from usuarios where idusuario = @id";
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("id", idusuario);
            return dtUsuario = SelectData(Command);
        }


        public int insertUsuario(Usuarios usr)
        {
            Command.CommandText = "insert into usuario values (@idusuario)";
        }
    }
}
