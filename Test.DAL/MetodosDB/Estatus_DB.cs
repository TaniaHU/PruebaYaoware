using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BOL.Modelos;

namespace Test.DAL.MetodosDB
{
    public class Estatus_DB
    {

        private BaseDatosContext _context;
        public Estatus_DB()
        {
            _context = new BaseDatosContext();
        }

        public Estatus GetEstatusId(int id)
        {
            return _context.Estatus.Where(a => a.IdEstatusVenta == id).FirstOrDefault();
        }
        public List<Estatus> GetListEstatus()
        {
            return _context.Estatus.ToList();
        }

        public int Agrega(Estatus _Item)
        {
            _context.Estatus.Add(_Item);
            _context.SaveChanges();
            return _Item.IdEstatusVenta;
        }
        public void Actualiza(Estatus _Item)
        {
            _context.Entry(_Item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Borrar(int id)
        {
            Estatus _Item = _context.Estatus.Find(id);
            _context.Estatus.Remove(_Item);
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
