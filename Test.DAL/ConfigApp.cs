using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DAL
{
    public class ConfigApp
    {
        public string NombreBD = "Test";
        public string CadenaServidor;


        public ConfigApp()
        {
            CadenaServidor = $"data source=localhost; initial catalog = {NombreBD}; persist security info = True; Integrated Security = SSPI; ";
        }
    }
}
