using System;

public class Factura
{
    public int Id { get; set; }
    public Mesa Mesa { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total => Mesa.CalcularTotal();

    public Factura(int id, Mesa mesa)
    {
        Id = id;
        Mesa = mesa;
        Fecha = DateTime.Now;
    }

    public void MostrarFactura()
    {
        Console.WriteLine($"Factura ID: {Id}");
        Console.WriteLine($"Fecha: {Fecha}");
        Console.WriteLine($"Mesa ID: {Mesa.Id}");
        Mesa.ImprimirCuenta();
        Console.WriteLine($"Total: {Total:C}");
    }
}
