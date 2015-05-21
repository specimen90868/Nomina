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
        public int modificaAutorizacion(Autorizaciones auth)
        {
            Command.CommandText = "update autorizaciones set idusuario = @idusuario, catalogos = @catalogos, usuarios = @usuarios," +
                            "rh = @rh, ss= @ss, contrato = @contrato  where id = @id";
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("id", auth.id);
            Command.Parameters.AddWithValue("idusuario", auth.idusuario);
            Command.Parameters.AddWithValue("catalogos", auth.catalogos);
            Command.Parameters.AddWithValue("usuarios", auth.usuarios);
            Command.Parameters.AddWithValue("rh", auth.rh);
            Command.Parameters.AddWithValue("ss", auth.ss);
            Command.Parameters.AddWithValue("contrato", auth.contrato);
            return Command.ExecuteNonQuery();
        }
    }
}

