using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BOL.Modelos;
using Test.BOL.ModelosSistema;

namespace Test.DAL.MetodosDB
{
    public class Ventas_DB
    {

        private BaseDatosContext _context;
        public Ventas_DB()
        {
            _context = new BaseDatosContext();
        }

        public Ventas GetVentasId(int id)
        {
            return _context.Ventas.Where(a => a.IdVenta == id).FirstOrDefault();
        }
        public List<Ventas> GetListVentas() 
        {
            return _context.Ventas.ToList();
        }
        public List<VentaViewModel> GetListVentasVM()
        {
            var salida = (from v in _context.Ventas
                          join e in _context.Estatus on v.IdEstatusVenta equals e.IdEstatusVenta
                          join p in _context.Producto on v.IdProducto equals p.IdProducto
                          join u in _context.Usuario on v.IdUsuario equals u.IdUsuario
                          select new VentaViewModel
                          {
                              IdEstatusVenta = v.IdEstatusVenta,
                              Estatus = e.Descripcion,
                              Cantidad = v.Cantidad,
                              IdProducto = v.IdProducto,
                              IdUsuario = v.IdUsuario,
                              IdVenta = v.IdVenta,
                              Total = v.Total,
                              Producto = p.Nombre,
                              Usuario = u.Nombre,
                          }).ToList();
            return salida;
        }
       
        public List<VentaViewModel> GetListVentasPagadoVM()
        {
            var salida = (from v in _context.Ventas
                          join e in _context.Estatus on v.IdEstatusVenta equals e.IdEstatusVenta
                          join p in _context.Producto on v.IdProducto equals p.IdProducto
                          join u in _context.Usuario on v.IdUsuario equals u.IdUsuario
                          where e.Descripcion == "Pagados" || e.Descripcion == "Pendiente de pago"
                          select new VentaViewModel
                          {
                              IdEstatusVenta = v.IdEstatusVenta,
                              Estatus = e.Descripcion,
                              Cantidad = v.Cantidad,
                              IdProducto = v.IdProducto,
                              IdUsuario = v.IdUsuario,
                              IdVenta = v.IdVenta,
                              Total = v.Total,
                              Producto = p.Nombre,
                              Usuario = u.Nombre,
                          }).ToList();
            return salida;
        }
        public List<Ventas> GetListVentasPagado()
        {
            var salida = (from v in _context.Ventas
                          join e in _context.Estatus on v.IdEstatusVenta equals e.IdEstatusVenta
                          where e.Descripcion == "Pagados" || e.Descripcion == "Pendientes de pago"
                          select new Ventas
                          {
                              IdEstatusVenta = v.IdEstatusVenta,
                              Cantidad = v.Cantidad,
                              IdProducto = v.IdProducto,
                              IdUsuario = v.IdUsuario,
                              IdVenta = v.IdVenta,
                              Total = v.Total,
                          }).ToList();
            return salida;
        }

        public int Agrega(Ventas _Item)
        {
            _context.Ventas.Add(_Item);
            _context.SaveChanges();
            return _Item.IdVenta;
        }
        public void Actualiza(Ventas _Item)
        {
            _context.Entry(_Item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Borrar(int id)
        {
            Ventas _Item = _context.Ventas.Find(id);
            _context.Ventas.Remove(_Item);
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
