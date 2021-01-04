using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empresa
    {
        public string Nif { get; set; }
        public string Nombre { get; set; }
        public string Logo { get; set; }
        public Empresa()
        {
        }
        public Empresa(string nif, string nombre, string logo)
        {
            Nif = nif;
            Nombre = nombre;
            Logo = logo;
        }
    }
}
