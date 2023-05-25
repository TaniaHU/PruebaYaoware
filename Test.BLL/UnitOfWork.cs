using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BLL.MetodosBLL;

namespace Test.BLL
{
    public class UnitOfWork
    {
        public Producto_BLL producto;
        public Usuario_BLL usuario;
        public Ventas_BLL ventas;
        public Estatus_BLL estatus;
        public UnitOfWork()
        {
            producto = new Producto_BLL();
            usuario = new Usuario_BLL();
            ventas = new Ventas_BLL();
            estatus = new Estatus_BLL();
        }
    }
}
