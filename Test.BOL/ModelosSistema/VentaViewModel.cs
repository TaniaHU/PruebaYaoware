using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Test.BOL.ModelosSistema
{
    public class VentaViewModel
    {
        [Key]
        public int IdVenta { get; set; }
        public int IdUsuario { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int Total { get; set; }
        public int IdEstatusVenta { get; set; }
        public string Estatus { get; set; }
        public string Producto { get; set; }
        public string Usuario { get; set; }
    }
}
