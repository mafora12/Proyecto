using System;
using System.Collections.Generic;

public class Restaurante
{
    public List<Mesa> Mesas { get; set; }
    public Menu MenuRestaurante { get; set; }
    public List<Factura> Facturas { get; set; }

    public Restaurante()
    {
        Mesas = new List<Mesa>();
        MenuRestaurante = new Menu();
        Facturas = new List<Factura>();
    }

    public Mesa? SeleccionarMesa(int mesaId)
    {
        return Mesas.Find(m => m.Id == mesaId);
    }

    public Producto? BuscarProductoPorId(int productoId)
    {
        return MenuRestaurante.Productos.Find(p => p.Id == productoId);
    }

    public void AgregarFactura(Factura factura)
    {
        Facturas.Add(factura);
    }

    public void MostrarFacturas()
    {
        foreach (var factura in Facturas)
        {
            factura.MostrarFactura();
        }
    }
}
