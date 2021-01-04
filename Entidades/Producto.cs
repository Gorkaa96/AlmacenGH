using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        public string Id { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public Producto()
        {
        }
        public Producto(string id, string descripcion, int stock,int stockMinimo,double precioCompra)
        {
            Id = id;
            Descripcion = descripcion;
            Stock = stock;
            StockMinimo = stockMinimo;
            PrecioCompra = precioCompra;
            PrecioVenta = precioCompra + 0.1;

        }
    }
}
