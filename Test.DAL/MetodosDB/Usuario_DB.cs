using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BOL.Modelos;

namespace Test.DAL.MetodosDB
{
    public class Usuario_DB
    {

        private BaseDatosContext _context;
        public Usuario_DB()
        {
            _context = new BaseDatosContext();
        }

        public Usuario GetUsuarioId(int id)
        {
            return _context.Usuario.Where(a => a.IdUsuario == id).FirstOrDefault();
        }
        public List<Usuario> GetListUsuario()
        {
            return _context.Usuario.ToList();
        }
        public Usuario InicioSesion(string correo, string pass)
        {
            var salida = (from u in _context.Usuario
                          where u.Correo == correo && u.Password == pass
                          select new Usuario {
                              IdUsuario = u.IdUsuario,
                              Correo = u.Correo,
                              Nombre = u.Nombre,
                              Password = u.Password
                          }).FirstOrDefault();
            return salida;
        }

        public int Agrega(Usuario _Item)
        {
            _context.Usuario.Add(_Item);
            _context.SaveChanges();
            return _Item.IdUsuario;
        }
        public void Actualiza(Usuario _Item)
        {
            _context.Entry(_Item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Borrar(int id)
        {
            Usuario _Item = _context.Usuario.Find(id);
            _context.Usuario.Remove(_Item);
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
