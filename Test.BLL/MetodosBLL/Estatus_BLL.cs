using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.BOL.Modelos;
using Test.DAL.MetodosDB;

namespace Test.BLL.MetodosBLL
{
    public class Estatus_BLL
    {
        private Estatus_DB _objDB;
        public Estatus_BLL()
        {
            _objDB = new Estatus_DB();
        }
        public Estatus GetPEstatusId(int id)
        {
            return _objDB.GetEstatusId(id);
        }
        public List<Estatus> GetListEstatus()
        {
            return _objDB.GetListEstatus();
        }
       
        public int Agrega(Estatus _Item)
        {
            return _objDB.Agrega(_Item);
        }
        public void Actualiza(Estatus _Item)
        {
            _objDB.Actualiza(_Item);
        }
        public void Borrar(int id)
        {
            _objDB.Borrar(id);
        }
    }
}

