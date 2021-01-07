using CapaDatosAlmacen;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocioAlmacen
{
    public class GestionAlmacen
    {
        DatosAlmacen datosBancarios = new DatosAlmacen(); // TODO datosBancarios Nombre ilógico 

        public Empresa BuscarEmpresa(out String mensaje)
        {
            return datosBancarios.BuscarEmpresa(out mensaje);
        }

        public string AgregarModificarEmpresa(string nif,string nombre,string logo)
        {
            return datosBancarios.AgregarModificarEmpresa(nif,nombre,logo);
        }
        public List<Producto> ProductosBajoStock(out String mensaje)
        {
            return datosBancarios.ProductosBajoStock(out mensaje);
        }

        public string ReponerProductos(string id, string stock, decimal precioCompra)
        {
            return datosBancarios.ReponerProductos(id, stock, precioCompra);
        }

        public string LeerFichero(string fileName)
        {
            return datosBancarios.LeerFichero(fileName);
        }
    }
}
