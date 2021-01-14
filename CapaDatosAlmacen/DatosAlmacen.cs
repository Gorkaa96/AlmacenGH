using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatosAlmacen
{
    public class DatosAlmacen
    {
        List<Ticket> listaRecivida = new List<Ticket>();

        String cadena = "Data Source = PORTATIL-GORKA\\GORKASQLSERVER; Initial Catalog = AlmacenGH; Integrated Security = True";

        //String cadena = "Data Source = .; Initial Catalog = AlmacenGH; Integrated Security = True";

        public Empresa BuscarEmpresa(out String mensaje)
        {
            SqlConnection conexion = new SqlConnection(cadena);
            try
            {
                conexion.Open();
                String sql = "SELECT * FROM Empresa";
                SqlCommand cmdEmpresa = new SqlCommand(sql, conexion);
                SqlDataReader drdEmpresa = cmdEmpresa.ExecuteReader();

                if (!drdEmpresa.Read())
                {
                    mensaje = "No hay ninguna empresa";
                    return null;
                }
                Empresa emp = new Empresa(drdEmpresa["Nif"].ToString(), drdEmpresa["Nombre"].ToString(), drdEmpresa["Logo"].ToString());
                mensaje = "";
                return emp;

            }
            catch (Exception exc)
            {
                mensaje = exc.Message;
                return null;
            }
        }

        public string AgregarModificarEmpresa(string nif, string nombre, string logo)
        {
            Empresa emp = BuscarEmpresa(out string mensaje);
            SqlConnection conexion = new SqlConnection(cadena);
            if (mensaje != "")
            {
                try
                {
                    conexion.Open();
                    String sql = "INSERT INTO Empresa (Nif,Nombre,Logo) VALUES(@nif,@nombre,@logo)";
                    SqlCommand cmdAñadir = new SqlCommand(sql, conexion);
                    cmdAñadir.Parameters.AddWithValue("@nif", nif);
                    cmdAñadir.Parameters.AddWithValue("@nombre", nombre);
                    cmdAñadir.Parameters.AddWithValue("@logo", logo);
                    int numFiles = cmdAñadir.ExecuteNonQuery();
                    if (numFiles != 1)
                    {
                        conexion.Close();
                        return "No se ha podido añadir la empresa";
                    }
                    else
                    {
                        emp = new Empresa(nif, nombre, logo);
                        conexion.Close();
                        return "Empresa añadida";
                    }
                }
                catch (Exception exc)
                {
                    conexion.Close();
                    return exc.Message;
                }

            }
            else
            {
                conexion.Open();
                if (emp.Nif != nif || emp.Nombre != nombre || emp.Logo != logo)
                {
                    try
                    {
                        String sql = "UPDATE Empresa SET [Nif] = @Nif, [Nombre] = @Nombre, [Logo] = @Logo";
                        SqlCommand cmdAñadir = new SqlCommand(sql, conexion);
                        cmdAñadir.Parameters.AddWithValue("Nif", nif);
                        cmdAñadir.Parameters.AddWithValue("Nombre", nombre);
                        cmdAñadir.Parameters.AddWithValue("Logo", logo);
                        int numFiles = cmdAñadir.ExecuteNonQuery();
                        if (numFiles != 1)
                        {
                            conexion.Close();
                            return "No se ha podido modificar la empresa";
                        }
                        else
                        {
                            emp.Nif = nif;
                            emp.Nombre = nombre;
                            emp.Logo = logo;
                            return "Empresa modificada";
                        }
                    }
                    catch (Exception exc)
                    {
                        conexion.Close();
                        return exc.Message;
                    }
                }
            }
            conexion.Close();
            // QUE EL NIF EL NOMBRE Y EL LOGO SON IGUALES
            return "";
        }

        public List<Producto> ProductosBajoStock(out String mensaje)
        {
            List<Producto> listaProductos = new List<Producto>();
            SqlConnection conexion = new SqlConnection(cadena);
            try
            {
                conexion.Open();
                String sql = "SELECT * FROM Productos WHERE Stock<StockMinimo ORDER BY Descripcion";
                SqlCommand cmdProducto = new SqlCommand(sql, conexion);
                SqlDataReader drdProducto = cmdProducto.ExecuteReader();

                if (!drdProducto.HasRows)
                {
                    mensaje = "No hay ningun productos en bajo stock";
                    return null;
                }
                while (drdProducto.Read())
                {
                    Producto prod = new Producto(drdProducto["IdProducto"].ToString(), drdProducto["Descripcion"].ToString(), int.Parse(drdProducto["Stock"].ToString()), int.Parse(drdProducto["StockMinimo"].ToString()), decimal.Parse(drdProducto["Precio"].ToString()));
                    listaProductos.Add(prod);
                }
                mensaje = "";
                return listaProductos;

            }
            catch (Exception exc)
            {
                mensaje = exc.Message;
                return null;
            }

        }

        public string ReponerProducto(string id, string stock, decimal precioCompra)
        {
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            String sql = "UPDATE Productos SET [Stock] = @Stock, [Precio] = @PrecioCompra WHERE IdProducto=@Id";
            SqlCommand cmdAñadir = new SqlCommand(sql, conexion);
            cmdAñadir.Parameters.AddWithValue("Id", id);
            cmdAñadir.Parameters.AddWithValue("Stock", stock);
            cmdAñadir.Parameters.AddWithValue("PrecioCompra", precioCompra);
            int numFiles = cmdAñadir.ExecuteNonQuery();
            if (numFiles != 1)
            {
                conexion.Close();
                return "No se ha encontrado ningun producto con identificaor " + id;
            }
            else
            {
                return "";
            }
        }

        public string LeerFichero(string fileName)
        {
            try
            {
                string[] lineas = File.ReadAllLines(fileName);
                string id;
                string stock;
                string precioCompra;
                string productosActualizados = "";
                string msj = "";
                string msjLineaMalescrita = "";
                string mensajeFinal = "";
                if (lineas.Length == 0)
                {
                    return "El archivo esta vacio";
                }
                foreach (var linea in lineas)
                {
                    string[] dividir = linea.Split('*');
                    if (dividir.Length < 3)
                    {
                        msjLineaMalescrita += "La línea " + linea + " es errónea\n";
                    }
                    else
                    {
                        id = dividir[0];
                        stock = dividir[1];
                        precioCompra = dividir[2];
                        decimal precio = decimal.Parse(precioCompra);

                        if (ReponerProducto(id, stock, precio) == "")
                        {
                            if (productosActualizados == "")
                            {
                                productosActualizados = id;
                            }
                            else
                            {
                                productosActualizados = productosActualizados + " " + id;
                            }
                        }
                        else
                        {
                            msj = ReponerProducto(id, stock, precio) + "\n";
                        }
                    }
                }
                if (productosActualizados != "")
                {
                    if (productosActualizados.Length > 1)
                    {
                        mensajeFinal = "Se han actualizado los productos " + productosActualizados + "\n";
                    }
                    else
                    {
                        mensajeFinal = "Se ha actualizado el producto " + productosActualizados + "\n";
                    }
                }
                if (msj != "" || msjLineaMalescrita != "")
                {
                    mensajeFinal += "Se han obtenido los siguientes errores:\n";
                    if (msj != "")
                    {
                        mensajeFinal += msj;
                    }
                    if (msjLineaMalescrita != "")
                    {
                        mensajeFinal += msjLineaMalescrita;
                    }
                }
                return mensajeFinal;
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public Producto BuscarProducto(string id, out String mensaje)
        {
            if (int.TryParse(id, out int number) == false)
            {
                mensaje = "El identificador debe de ser numérico";
                return null;
            }
            else
            {


                SqlConnection conexion = new SqlConnection(cadena);
                try
                {
                    conexion.Open();
                    String sql = "SELECT * FROM Productos WHERE IdProducto=@Id";
                    SqlCommand cmdProducto = new SqlCommand(sql, conexion);
                    cmdProducto.Parameters.AddWithValue("Id", id);
                    SqlDataReader drProducto = cmdProducto.ExecuteReader();

                    if (!drProducto.Read())
                    {
                        mensaje = "No hay ningun producto con este identificador";
                        return null;
                    }
                    Producto prod = new Producto(drProducto["IdProducto"].ToString(), drProducto["Descripcion"].ToString(), int.Parse(drProducto["Stock"].ToString()), int.Parse(drProducto["StockMinimo"].ToString()), decimal.Parse(drProducto["Precio"].ToString()));
                    mensaje = "";
                    return prod;

                }
                catch (Exception exc)
                {
                    mensaje = exc.Message;
                    return null;
                }
            }
        }
        public string IdUltimoTicketDeTickets()
        {
            SqlConnection conexion = new SqlConnection(cadena);
            try
            {
                conexion.Open();
                String sql = "SELECT MAX(IdTicket) FROM Tickets";
                SqlCommand cmdProducto = new SqlCommand(sql, conexion);
                string idTicket = cmdProducto.ExecuteScalar().ToString();
                int id = int.Parse(idTicket)+1;
                return id.ToString();

            }
            catch (Exception )
            {
                return null;
            }
        }

        public string IdUltimoTicketDeTicketsProductos()
        {
            string id = IdUltimoTicketDeTickets();
            int idTicket = int.Parse(id);
            return (idTicket - 1).ToString();
        }

        public string AñadirTicketEnTickets()
        {
            string id = IdUltimoTicketDeTickets();
            SqlConnection conexion = new SqlConnection(cadena);

            try
            {
                conexion.Open();
                String sql = "INSERT INTO Tickets (IdTicket,Fecha) VALUES(@id,@fecha)";
                SqlCommand cmdAñadir = new SqlCommand(sql, conexion);
                cmdAñadir.Parameters.AddWithValue("@id", id);
                cmdAñadir.Parameters.AddWithValue("@fecha", DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString());
                int numFiles = cmdAñadir.ExecuteNonQuery();
                if (numFiles != 1)
                {
                    conexion.Close();
                    return "No se ha podido añadir el ticket";
                }
                else
                {
                    conexion.Close();
                    return "";
                }
            }
            catch (Exception exc)
            {
                conexion.Close();
                return exc.Message;
            }
        }

        public string AñadirTicketEnTicketsProductos(string idProducto,decimal precio,string cantidad)
        {
            string id = IdUltimoTicketDeTicketsProductos();
            SqlConnection conexion = new SqlConnection(cadena);
            try
            {
                conexion.Open();
                String sql = "INSERT INTO TicketsProductos (IdTicket,IdProducto,Precio,CantidadVendida) VALUES(@idTicket,@idProducto,@precio,@cantidadVendida)";
                SqlCommand cmdAñadir = new SqlCommand(sql, conexion);
                cmdAñadir.Parameters.AddWithValue("@idTicket", id);
                cmdAñadir.Parameters.AddWithValue("@idProducto", idProducto);
                cmdAñadir.Parameters.AddWithValue("@precio", precio);
                cmdAñadir.Parameters.AddWithValue("@cantidadVendida", int.Parse(cantidad));
                int numFiles = cmdAñadir.ExecuteNonQuery();
                if (numFiles != 1)
                {
                    conexion.Close();
                    return "No se ha podido añadir el ticket";
                }
                else
                {
                    conexion.Close();
                    return "";
                }
            }
            catch (Exception exc)
            {
                conexion.Close();
                return exc.Message;
            }
        }

        public void RecivirLista(List<Ticket> ticket)
        {
            listaRecivida = ticket;
        }

        public string ActualizarStockProducto(string id, string cantidad)
        {
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            String sql = "UPDATE Productos SET [Stock] = [Stock]-@Cantidad WHERE IdProducto=@Id ";
            SqlCommand cmdAñadir = new SqlCommand(sql, conexion);
            cmdAñadir.Parameters.AddWithValue("Cantidad", cantidad);
            cmdAñadir.Parameters.AddWithValue("Id", id);
            int numFiles = cmdAñadir.ExecuteNonQuery();
            if (numFiles == -1 || numFiles == 0)
            {
                conexion.Close();
                return "No se ha podido actualizar el stock";
            }
            else
            {
                return "";
            }
        }
    }
}
