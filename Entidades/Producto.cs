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
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public Producto()
        {
        }
        public Producto(string id, string descripcion, int stock,int stockMinimo,decimal precioCompra)
        {
            Id = id;
            Descripcion = descripcion;
            Stock = stock;
            StockMinimo = stockMinimo;
            PrecioCompra = precioCompra;
            PrecioVenta = precioCompra + (decimal)0.1;

        }
    }
}
