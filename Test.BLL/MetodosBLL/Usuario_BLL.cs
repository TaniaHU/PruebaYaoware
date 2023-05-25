using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BOL.Modelos;
using Test.DAL.MetodosDB;

namespace Test.BLL.MetodosBLL
{
    public class Usuario_BLL
    {
        private Usuario_DB _objDB;
        public Usuario_BLL()
        {
            _objDB = new Usuario_DB();
        }
        public Usuario GetUsuarioId(int id)
        {
            return _objDB.GetUsuarioId(id);
        }
        public List<Usuario> GetListUsuario()
        {
            return _objDB.GetListUsuario();
        }
        public Usuario InicioSesion(string correo, string pass)
        {
            return _objDB.InicioSesion(correo, pass);
        }
            public int Agrega(Usuario _Item)
        {
            return _objDB.Agrega(_Item);
        }
        public void Actualiza(Usuario _Item)
        {
            _objDB.Actualiza(_Item);
        }
        public void Borrar(int id)
        {
            _objDB.Borrar(id);
        }
    }
}
