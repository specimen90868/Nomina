using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Empresas.Core
{
    public class EmpresasHelper : Data.Obj.DataObj
    {
        public List<Empresas> InicioEmpresa()
        {
            List<Empresas> lstEmpresa = new List<Empresas>();
            Command.CommandText = "select idempresa, nombre, registro, digitoverificador from empresas";
            Command.Parameters.Clear();
            DataTable dtEmpresa = new DataTable();
            dtEmpresa = SelectData(Command);
            for(int i = 0; i < dtEmpresa.Rows.Count; i++)
            {
                Empresas e = new Empresas();
                e.idempresa = int.Parse(dtEmpresa.Rows[i]["idempresa"].ToString());
                e.nombre = dtEmpresa.Rows[i]["nombre"].ToString();
                e.registro = dtEmpresa.Rows[i]["registro"].ToString();
                e.digitoverificador = int.Parse(dtEmpresa.Rows[i]["digitoverificador"].ToString());
                lstEmpresa.Add(e);
            }
            return lstEmpresa;
        }

        public object IdEmpresa(Empresas e)
        {
            Command.CommandText = "select idempresa from empresas where rfc = @rfc";
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("rfc", e.rfc);
            object id = Select(Command);
            return id;
        }

        public int insertaEmpresa(Empresas e)
        {
            Command.CommandText = "insert into empresas (nombre, rfc, registro, digitoverificador, sindicato, representante) " + 
                "values (@nombre, @rfc, @registro, @digitoverificador, @sindicato, @representante)";
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("@nombre",e.nombre);
            Command.Parameters.AddWithValue("@rfc", e.rfc);
            Command.Parameters.AddWithValue("@registro", e.registro);
            Command.Parameters.AddWithValue("@digitoverificador", e.digitoverificador);
            Command.Parameters.AddWithValue("@sindicato", e.sindicato);
            Command.Parameters.AddWithValue("@representante", e.representante);
            return Command.ExecuteNonQuery();
        }
    }
}
