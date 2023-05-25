using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.BOL.Modelos
{
    public class Ventas
    {
        [Key]
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
        public int IdEstatusVenta { get; set; }
    }
}
