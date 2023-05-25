using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BOL.Modelos;
using Test.BOL.ModelosSistema;
using Test.DAL.MetodosDB;

namespace Test.BLL.MetodosBLL
{
    public class Ventas_BLL
    {
        private Ventas_DB _objDB;
        public Ventas_BLL()
        {
            _objDB = new Ventas_DB();
        }
        public Ventas GetVentasId(int id)
        {
            return _objDB.GetVentasId(id);
        }
        //public VentaViewModel GetVentasIdViewModel(int id)
        //{
        //    return _objDB.GetVentasIdViewModel(id);
        //}
        public List<Ventas> GetListVentas()
        {
            return _objDB.GetListVentas();
        }
        public List<Ventas> GetListVentasPagado()
        {
            return _objDB.GetListVentasPagado();
        }
        public List<VentaViewModel> GetListVentasVM()
        {
            return _objDB.GetListVentasVM();
        }
        public List<VentaViewModel> GetListVentasPagadoVM()
        {
            return _objDB.GetListVentasPagadoVM();
        }
        public int Agrega(Ventas _Item)
        {
            return _objDB.Agrega(_Item);
        }
        public void Actualiza(Ventas _Item)
        {
            _objDB.Actualiza(_Item);
        }
        public void Borrar(int id)
        {
            _objDB.Borrar(id);
        }
    }
}
