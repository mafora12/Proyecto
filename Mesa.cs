using System;
using System.Collections.Generic;

public class Mesa
{
    public int Id { get; set; }
    public List<Producto> Productos { get; set; }

    public Mesa(int id)
    {
        Id = id;
        Productos = new List<Producto>();
    }

    public void AgregarProducto(Producto producto)
    {
        Productos.Add(producto);
    }

    public void EditarProducto(int productoId, Producto nuevoProducto)
    {
        var producto = Productos.Find(p => p.Id == productoId);
        if (producto != null)
        {
            producto.Nombre = nuevoProducto.Nombre;
            producto.Precio = nuevoProducto.Precio;
            producto.Cantidad = nuevoProducto.Cantidad;
        }
    }

    public void ImprimirCuenta()
    {
        Console.WriteLine($"Cuenta de la Mesa {Id}:");
        foreach (var producto in Productos)
        {
            Console.WriteLine(producto);
        }
        Console.WriteLine($"Total: {CalcularTotal():C}");
    }

    public decimal CalcularTotal()
    {
        decimal total = 0;
        foreach (var producto in Productos)
        {
            total += producto.CalcularTotal();
        }
        return total;
    }
}
