using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorizaciones.Core
{
    public class Autorizaciones
    {
        public int id { get; set; }
        public int idusuario { get; set; }
        public bool catalogos { get; set; }
        public bool usuarios { get; set; }
        public bool rh { get; set; }
        public bool ss { get; set; }
        public bool contrato { get; set }
    }
}
