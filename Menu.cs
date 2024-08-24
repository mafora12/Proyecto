using System;
using System.Collections.Generic;

public class Menu
{
    public List<Producto> Productos { get; set; }

    public Menu()
    {
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
        }
    }

    public void EliminarProducto(int productoId)
    {
        Productos.RemoveAll(p => p.Id == productoId);
    }

    public void ImprimirMenu()
    {
        Console.WriteLine("Menú del Restaurante:");
        foreach (var producto in Productos)
        {
            Console.WriteLine($"{producto.Id}. {producto.Nombre} - {producto.Precio:C}");
        }
    }
}
