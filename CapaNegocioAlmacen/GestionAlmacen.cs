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
        DatosAlmacen datosAlmacen = new DatosAlmacen();

        public Empresa BuscarEmpresa(out String mensaje)
        {
            return datosAlmacen.BuscarEmpresa(out mensaje);
        }

        public string AgregarModificarEmpresa(string nif,string nombre,string logo)
        {
            return datosAlmacen.AgregarModificarEmpresa(nif,nombre,logo);
        }
        public List<Producto> ProductosBajoStock(out String mensaje)
        {
            return datosAlmacen.ProductosBajoStock(out mensaje);
        }

        public string LeerFichero(string fileName)
        {
            return datosAlmacen.LeerFichero(fileName);
        }

        public Producto BuscarProducto(string id,out String mensaje)
        {
            return datosAlmacen.BuscarProducto(id,out mensaje);
        }

        public void RecivirLista(List<Ticket> tick)
        {
            datosAlmacen.RecivirLista(tick);
        }

        public string AñadirTicketEnTickets()
        {
            return datosAlmacen.AñadirTicketEnTickets();
        }
        public string AñadirTicketEnTicketsProductos(string idProducto, decimal precio,string cantidad)
        {
            return datosAlmacen.AñadirTicketEnTicketsProductos(idProducto,precio,cantidad);
        }
        public string ActualizarStockProducto(string id, string cantidad)
        {
            return datosAlmacen.ActualizarStockProducto(id,cantidad);
        }

        public string NumeroDeTicket()
        {
            return datosAlmacen.IdUltimoTicketDeTicketsProductos();
        }
    }
}
