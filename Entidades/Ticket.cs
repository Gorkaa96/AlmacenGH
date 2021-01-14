using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ticket
    {
        public int NumTicket { get; set; }
        public string IdProducto { get; set; }
        public string PrecioVenta { get; set; }
        public string Cantidad { get; set; }
        public Ticket()
        {
        }
        public Ticket(int numTicket, string idProducto, string precioVenta, string cantidad)
        {
            NumTicket = numTicket;
            IdProducto = idProducto;
            PrecioVenta = precioVenta;
            Cantidad = cantidad;
        }
    }
}
