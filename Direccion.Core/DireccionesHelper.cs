using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Direccion.Core
{
    public class DireccionesHelper : Data.Obj.DataObj
    {
        public List<Direcciones> obtenerDireccion(Direcciones d)
        { 
        }

        public int insertaDireccion(Direcciones d)
        {
            Command.CommandText = "insert into direcciones (idpersona,calle,exterior,interior,colonia,cp,ciudad,estado,pais,tipodireccion,tipopersona) " +
                "values (@idpersona,@calle,@exterior,@interior,@colonia,@cp,@ciudad,@estado,@pais,@tipodireccion,@tipopersona)";
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@idpersona", d.idpersona);
            Command.Parameters.AddWithValue("@calle", d.calle);
            Command.Parameters.AddWithValue("@exterior", d.exterior);
            Command.Parameters.AddWithValue("@interior", d.interior);
            Command.Parameters.AddWithValue("@colonia", d.colonia);
            Command.Parameters.AddWithValue("@cp", d.cp);
            Command.Parameters.AddWithValue("@ciudad", d.ciudad);
            Command.Parameters.AddWithValue("@estado", d.estado);
            Command.Parameters.AddWithValue("@pais", d.pais);
            Command.Parameters.AddWithValue("@tipodireccion", d.tipodireccion);
            Command.Parameters.AddWithValue("@tipopersona", d.tipopersona);
            return Command.ExecuteNonQuery();
        }

        public int actualizaDireccion(Direcciones d)
        {
            Command.CommandText = "update direcciones calle = @calle, exterior = @exterior, interior = @interior, colonia = @colonia, cp = @cp, ciudad = @ciudad, estado = @estado, pais = @pais " + 
                "where iddireccion = @iddireccion and idpersona = @idpersona";
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@iddireccion", d.iddireccion);
            Command.Parameters.AddWithValue("@idpersona", d.idpersona);
            Command.Parameters.AddWithValue("@calle", d.calle);
            Command.Parameters.AddWithValue("@exterior", d.exterior);
            Command.Parameters.AddWithValue("@interior", d.interior);
            Command.Parameters.AddWithValue("@colonia", d.colonia);
            Command.Parameters.AddWithValue("@cp", d.cp);
            Command.Parameters.AddWithValue("@ciudad", d.ciudad);
            Command.Parameters.AddWithValue("@estado", d.estado);
            Command.Parameters.AddWithValue("@pais", d.pais);
            return Command.ExecuteNonQuery();
        }
    }
}
