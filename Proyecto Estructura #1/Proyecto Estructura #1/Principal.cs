using System;

class Principal
{
    // Definir el tamaño del vector
    const int size = 10;

    // Definir vectores para almacenar la información de los pagos
    static int[] codigosCaja = new int[size];
    static string[] servicios = new string[size];
    static double[] montos = new double[size];
    static bool[] pagosRealizados = new bool[size]; // Para saber si se ha realizado un pago en una posición del vector

    static void Main(string[] args)
    {
        int opcion;

        do
        {
            Console.WriteLine("Menú Principal");
            Console.WriteLine("1. Inicializar Vectores");
            Console.WriteLine("2. Realizar Pagos");
            Console.WriteLine("3. Consultar Pagos");
            Console.WriteLine("4. Modificar Pagos");
            Console.WriteLine("5. Eliminar Pagos");
            Console.WriteLine("6. Submenú Reportes");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    InicializarVectores();
                    break;
                case 2:
                    RealizarPagos();
                    break;
                case 3:
                    ConsultarPagos();
                    break;
                case 4:
                    ModificarPagos();
                    break;
                case 5:
                    EliminarPagos();
                    break;
                case 6:
                    SubmenuReportes();
                    break;
                case 7:
                    Console.WriteLine("Saliendo de la aplicación...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        } while (opcion != 7);
    }

    static void InicializarVectores()
    {
        for (int i = 0; i < size; i++)
        {
            codigosCaja[i] = 0;
            servicios[i] = string.Empty;
            montos[i] = 0.0;
            pagosRealizados[i] = false;
        }
        Console.WriteLine("Vectores inicializados correctamente.");
    }

    static void RealizarPagos()
    {
        for (int i = 0; i < size; i++)
        {
            if (!pagosRealizados[i])
            {
                Console.Write("Ingrese el código de caja: ");
                codigosCaja[i] = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el tipo de servicio (agua, electricidad, teléfono): ");
                servicios[i] = Console.ReadLine();

                Console.Write("Ingrese el monto del pago: ");
                montos[i] = double.Parse(Console.ReadLine());

                pagosRealizados[i] = true;

                Console.WriteLine("Pago registrado correctamente.");
                return;
            }
        }
        Console.WriteLine("No hay espacio para más pagos.");
    }

    static void ConsultarPagos()
    {
        Console.Write("Ingrese el código de caja a consultar: ");
        int codigoConsulta = int.Parse(Console.ReadLine());

        for (int i = 0; i < size; i++)
        {
            if (pagosRealizados[i] && codigosCaja[i] == codigoConsulta)
            {
                Console.WriteLine($"Pago encontrado: Servicio {servicios[i]}, Monto {montos[i]}");
                return;
            }
        }
        Console.WriteLine("Pago no encontrado.");
    }

    static void ModificarPagos()
    {
        Console.Write("Ingrese el código de caja del pago a modificar: ");
        int codigoModificacion = int.Parse(Console.ReadLine());

        for (int i = 0; i < size; i++)
        {
            if (pagosRealizados[i] && codigosCaja[i] == codigoModificacion)
            {
                Console.Write("Ingrese el nuevo tipo de servicio (agua, electricidad, teléfono): ");
                servicios[i] = Console.ReadLine();

                Console.Write("Ingrese el nuevo monto del pago: ");
                montos[i] = double.Parse(Console.ReadLine());

                Console.WriteLine("Pago modificado correctamente.");
                return;
            }
        }
        Console.WriteLine("Pago no encontrado.");
    }

    static void EliminarPagos()
    {
        Console.Write("Ingrese el código de caja del pago a eliminar: ");
        int codigoEliminacion = int.Parse(Console.ReadLine());

        for (int i = 0; i < size; i++)
        {
            if (pagosRealizados[i] && codigosCaja[i] == codigoEliminacion)
            {
                codigosCaja[i] = 0;
                servicios[i] = string.Empty;
                montos[i] = 0.0;
                pagosRealizados[i] = false;

                Console.WriteLine("Pago eliminado correctamente.");
                return;
            }
        }
        Console.WriteLine("Pago no encontrado.");
    }

    static void SubmenuReportes()
    {
        int opcionReporte;

        do
        {
            Console.WriteLine("Submenú Reportes");
            Console.WriteLine("1. Ver todos los Pagos");
            Console.WriteLine("2. Ver Pagos por tipo de Servicio");
            Console.WriteLine("3. Ver Pagos por código de caja");
            Console.WriteLine("4. Ver Dinero Comisionado por servicios");
            Console.WriteLine("5. Regresar al Menú Principal");
            Console.Write("Seleccione una opción: ");
            opcionReporte = int.Parse(Console.ReadLine());

            switch (opcionReporte)
            {
                case 1:
                    VerTodosLosPagos();
                    break;
                case 2:
                    VerPagosPorTipoDeServicio();
                    break;
                case 3:
                    VerPagosPorCodigoDeCaja();
                    break;
                case 4:
                    VerDineroComisionadoPorServicios();
                    break;
                case 5:
                    Console.WriteLine("Regresando al Menú Principal...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        } while (opcionReporte != 5);
    }

    static void VerTodosLosPagos()
    {
        Console.WriteLine("Pagos realizados:");
        for (int i = 0; i < size; i++)
        {
            if (pagosRealizados[i])
            {
                Console.WriteLine($"Código de Caja: {codigosCaja[i]}, Servicio: {servicios[i]}, Monto: {montos[i]}");
            }
        }
    }

    static void VerPagosPorTipoDeServicio()
    {
        Console.Write("Ingrese el tipo de servicio a consultar (agua, electricidad, teléfono): ");
        string tipoServicio = Console.ReadLine();

        Console.WriteLine($"Pagos para el servicio {tipoServicio}:");
        for (int i = 0; i < size; i++)
        {
            if (pagosRealizados[i] && servicios[i].Equals(tipoServicio, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Código de Caja: {codigosCaja[i]}, Monto: {montos[i]}");
            }
        }
    }

    static void VerPagosPorCodigoDeCaja()
    {
        Console.Write("Ingrese el código de caja a consultar: ");
        int codigoConsulta = int.Parse(Console.ReadLine());

        Console.WriteLine($"Pagos para el código de caja {codigoConsulta}:");
        for (int i = 0; i < size; i++)
        {
            if (pagosRealizados[i] && codigosCaja[i] == codigoConsulta)
            {
                Console.WriteLine($"Servicio: {servicios[i]}, Monto: {montos[i]}");
            }
        }
    }

    static void VerDineroComisionadoPorServicios()
    {
        double totalComisionado = 0;

        for (int i = 0; i < size; i++)
        {
            if (pagosRealizados[i])
            {
                totalComisionado += montos[i];
            }
        }

        Console.WriteLine($"Dinero comisionado por servicios: {totalComisionado}");
    }
}
//////////Realizar Pagos ver/////////
///
