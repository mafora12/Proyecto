using System;

class Program
{
    static void Main(string[] args)
    {
        Restaurante restaurante = new Restaurante();

        // Agregar mesas y productos al menú de ejemplo
        restaurante.Mesas.Add(new Mesa(1));
        restaurante.Mesas.Add(new Mesa(2));

        restaurante.MenuRestaurante.AgregarProducto(new Producto(1, "Pizza", 8.99m, 1));
        restaurante.MenuRestaurante.AgregarProducto(new Producto(2, "Hamburguesa", 5.99m, 1));
        restaurante.MenuRestaurante.AgregarProducto(new Producto(3, "Refresco", 1.99m, 1));

        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("Sistema de Facturación - Restaurante");
            Console.WriteLine("1. Seleccionar Mesa");
            Console.WriteLine("2. Imprimir Menú");
            Console.WriteLine("3. Agregar Producto a Mesa");
            Console.WriteLine("4. Editar Producto de la Mesa");
            Console.WriteLine("5. Editar Menú del Restaurante");
            Console.WriteLine("6. Imprimir Cuenta Mesa");
            Console.WriteLine("7. Buscar Producto por ID");
            Console.WriteLine("8. Mostrar Facturas");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el ID de la mesa: ");
                    string? temp = Console.ReadLine();
                    if (int.TryParse(temp, out int mesaId))
                    {
                        var mesa = restaurante.SeleccionarMesa(mesaId);
                        if (mesa != null)
                        {
                            Console.WriteLine($"Mesa {mesaId} seleccionada.");
                        }
                        else
                        {
                            Console.WriteLine("Mesa no encontrada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID de mesa no válido.");
                    }
                    break;

                case "2":
                    restaurante.MenuRestaurante.ImprimirMenu();
                    break;

                case "3":
                    Console.Write("Ingrese el ID de la mesa: ");
                    temp = Console.ReadLine();
                    if (int.TryParse(temp, out mesaId))
                    {
                        var mesa = restaurante.SeleccionarMesa(mesaId);
                        if (mesa != null)
                        {
                            Console.Write("Ingrese el ID del producto a agregar: ");
                            temp = Console.ReadLine();
                            if (int.TryParse(temp, out int productoId))
                            {
                                var producto = restaurante.BuscarProductoPorId(productoId);
                                if (producto != null)
                                {
                                    Console.Write("Ingrese la cantidad: ");
                                    temp = Console.ReadLine();
                                    if (int.TryParse(temp, out int cantidad))
                                    {
                                        mesa.AgregarProducto(new Producto(producto.Id, producto.Nombre, producto.Precio, cantidad));
                                        Console.WriteLine("Producto agregado a la mesa.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Cantidad no válida.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Producto no encontrado.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("ID de producto no válido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Mesa no encontrada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID de mesa no válido.");
                    }
                    break;

                case "4":
                    Console.Write("Ingrese el ID de la mesa: ");
                    temp = Console.ReadLine();
                    if (int.TryParse(temp, out mesaId))
                    {
                        var mesa = restaurante.SeleccionarMesa(mesaId);
                        if (mesa != null)
                        {
                            Console.Write("Ingrese el ID del producto a editar: ");
                            temp = Console.ReadLine();
                            if (int.TryParse(temp, out int productoId))
                            {
                                var producto = mesa.Productos.Find(p => p.Id == productoId);
                                if (producto != null)
                                {
                                    Console.Write("Ingrese el nuevo nombre: ");
                                    string? nombre = Console.ReadLine();
                                    if (string.IsNullOrEmpty(nombre))
                                    {
                                        throw new ArgumentNullException(nameof(nombre), "El nombre no puede ser nulo o vacío.");
                                    }
                                    Console.Write("Ingrese el nuevo precio: ");
                                    temp = Console.ReadLine();
                                    if (decimal.TryParse(temp, out decimal precio))
                                    {
                                        Console.Write("Ingrese la nueva cantidad: ");
                                        temp = Console.ReadLine();
                                        if (int.TryParse(temp, out int cantidad))
                                        {
                                            mesa.EditarProducto(productoId, new Producto(productoId, nombre, precio, cantidad));
                                            Console.WriteLine("Producto editado.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Cantidad no válida.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Precio no válido.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Producto no encontrado.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("ID de producto no válido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Mesa no encontrada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID de mesa no válido.");
                    }
                    break;

                case "5":
                    restaurante.MenuRestaurante.ImprimirMenu();
                    Console.Write("Ingrese el ID del producto a editar: ");
                    temp = Console.ReadLine();
                    if (int.TryParse(temp, out int productoMenuId))
                    {
                        var producto = restaurante.MenuRestaurante.Productos.Find(p => p.Id == productoMenuId);
                        if (producto != null)
                        {
                            Console.Write("Ingrese el nuevo nombre: ");
                            string? nombre = Console.ReadLine();
                            if (string.IsNullOrEmpty(nombre))
                            {
                                throw new ArgumentNullException(nameof(nombre), "El nombre no puede ser nulo o vacío.");
                            }
                            Console.Write("Ingrese el nuevo precio: ");
                            temp = Console.ReadLine();
                            if (decimal.TryParse(temp, out decimal precio))
                            {
                                restaurante.MenuRestaurante.EditarProducto(productoMenuId, new Producto(productoMenuId, nombre, precio, producto.Cantidad));
                                Console.WriteLine("Producto editado en el menú.");
                            }
                            else
                            {
                                Console.WriteLine("Precio no válido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Producto no encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID de producto no válido.");
                    }
                    break;

                case "6":
                    Console.Write("Ingrese el ID de la mesa: ");
                    temp = Console.ReadLine();
                    if (int.TryParse(temp, out mesaId))
                    {
                        var mesa = restaurante.SeleccionarMesa(mesaId);
                        if (mesa != null)
                        {
                            mesa.ImprimirCuenta();
                        }
                        else
                        {
                            Console.WriteLine("Mesa no encontrada.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID de mesa no válido.");
                    }
                    break;

                case "7":
                    Console.Write("Ingrese el ID del producto a buscar: ");
                    temp = Console.ReadLine();
                    if (int.TryParse(temp, out int buscarProductoId))
                    {
                        var producto = restaurante.BuscarProductoPorId(buscarProductoId);
                        if (producto != null)
                        {
                            Console.WriteLine($"Producto encontrado: {producto.Nombre} - {producto.Precio:C}");
                        }
                        else
                        {
                            Console.WriteLine("Producto no encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID de producto no válido.");
                    }
                    break;

                case "8":
                    restaurante.MostrarFacturas();
                    break;

                case "0":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

            if (!salir)
            {
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
