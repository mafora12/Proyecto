using System;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }

    public Producto(int id, string nombre, decimal precio, int cantidad)
    {
        Id = id;
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
    }

    public void ActualizarCantidad(int nuevaCantidad)
    {
        Cantidad = nuevaCantidad;
    }

    public decimal CalcularTotal()
    {
        return Precio * Cantidad;
    }

    public override string ToString()
    {
        return $"{Nombre} - {Cantidad} x {Precio:C} = {CalcularTotal():C}";
    }
}
