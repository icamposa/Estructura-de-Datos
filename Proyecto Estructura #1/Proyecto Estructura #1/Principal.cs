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
    static int[] numeroPago = new int[size];
    static DateTime[] fecha = new DateTime[size];
    static string[] hora = new string[size];
    static string[] cedula = new string[size];
    static string[] nombre = new string[size];
    static string[] apellido1 = new string[size];
    static string[] apellido2 = new string[size];
    static int[] numeroCaja = new int[size];
    static string[] tipoServicio = new string[size];
    static string[] numeroFactura = new string[size];
    static double[] montoPagar = new double[size];
    static double[] montoComision = new double[size];
    static double[] montoDeducido = new double[size];
    static double[] montoPagaCliente = new double[size];
    static double[] vuelto = new double[size];
    static int contadorPagos = 0;

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
    static void SubmenuReportes()
    {
        int opcionReporte;

        do
        {
            Console.Clear(); // Limpiar la ventana

            // Mostrar el submenú de reportes
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
                    VerPagosPorTipoServicio();
                    break;
                case 3:
                    VerPagosPorCodigoCaja();
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

            if (opcionReporte != 5)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar.");
                Console.ReadKey();
            }
        } while (opcionReporte != 5);
    }


    static void InicializarVectores()
    {
        for (int i = 0; i < size; i++)
        {
            numeroPago[i] = 0;
            fecha[i] = DateTime.MinValue;
            hora[i] = string.Empty;
            cedula[i] = string.Empty;
            nombre[i] = string.Empty;
            apellido1[i] = string.Empty;
            apellido2[i] = string.Empty;
            numeroCaja[i] = 0;
            tipoServicio[i] = string.Empty;
            numeroFactura[i] = string.Empty;
            montoPagar[i] = 0.0;
            montoComision[i] = 0.0;
            montoDeducido[i] = 0.0;
            montoPagaCliente[i] = 0.0;
            vuelto[i] = 0.0;
            pagosRealizados[i] = false;
        }
        contadorPagos = 0;
        Console.WriteLine("Vectores inicializados correctamente.");
    }

    static void RealizarPagos()
    {
        if (contadorPagos >= size)
        {
            Console.WriteLine("Vectores Llenos.");
            return;
        }

        char continuar = 'n';
        do
        {
            if (contadorPagos >= size)
            {
                Console.WriteLine("Vectores Llenos.");
                break;
            }

            numeroPago[contadorPagos] = contadorPagos + 1;

            Console.Write("Ingrese la fecha (dd/mm/yyyy): ");
            fecha[contadorPagos] = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese la hora (hh:mm): ");
            hora[contadorPagos] = Console.ReadLine();

            Console.Write("Ingrese la cédula: ");
            cedula[contadorPagos] = Console.ReadLine();

            Console.Write("Ingrese el nombre: ");
            nombre[contadorPagos] = Console.ReadLine();

            Console.Write("Ingrese el primer apellido: ");
            apellido1[contadorPagos] = Console.ReadLine();

            Console.Write("Ingrese el segundo apellido: ");
            apellido2[contadorPagos] = Console.ReadLine();

            numeroCaja[contadorPagos] = new Random().Next(1, 4);

            Console.Write("Ingrese el tipo de servicio (1= Recibo de Luz, 2= Recibo Teléfono, 3= Recibo de Agua): ");
            int tipo = int.Parse(Console.ReadLine());
            switch (tipo)
            {
                case 1:
                    tipoServicio[contadorPagos] = "Recibo de Luz";
                    montoComision[contadorPagos] = 0.04;
                    break;
                case 2:
                    tipoServicio[contadorPagos] = "Recibo Teléfono";
                    montoComision[contadorPagos] = 0.055;
                    break;
                case 3:
                    tipoServicio[contadorPagos] = "Recibo de Agua";
                    montoComision[contadorPagos] = 0.065;
                    break;
                default:
                    Console.WriteLine("Tipo de servicio no válido. Intente nuevamente.");
                    continue;
            }

            Console.Write("Ingrese el número de factura: ");
            numeroFactura[contadorPagos] = Console.ReadLine();

            Console.Write("Ingrese el monto a pagar: ");
            montoPagar[contadorPagos] = double.Parse(Console.ReadLine());

            montoDeducido[contadorPagos] = montoPagar[contadorPagos] * (1 - montoComision[contadorPagos]);

            Console.Write("Ingrese el monto que paga el cliente: ");
            montoPagaCliente[contadorPagos] = double.Parse(Console.ReadLine());

            if (montoPagaCliente[contadorPagos] < montoPagar[contadorPagos])
            {
                Console.WriteLine("El monto que paga el cliente no puede ser menor al monto a pagar.");
                continue;
            }

            vuelto[contadorPagos] = montoPagaCliente[contadorPagos] - montoPagar[contadorPagos];

            pagosRealizados[contadorPagos] = true;
            contadorPagos++;

            Console.WriteLine("Pago registrado correctamente.");

            Console.Write("¿Desea ingresar otro pago? (s/n): ");
            continuar = Console.ReadLine()[0];

        } while (continuar == 's' || continuar == 'S');
    }

    static void ConsultarPagos()
    {
        Console.Clear(); // Limpiar la ventana

        // Solicitar al usuario el número de pago que desea consultar
        Console.Write("Ingrese el número de pago que desea consultar: ");
        int numeroConsulta = int.Parse(Console.ReadLine());

        bool encontrado = false;

        // Buscar el pago en los vectores
        for (int i = 0; i < size; i++)
        {
            if (pagosRealizados[i] && numeroPago[i] == numeroConsulta)
            {
                // Si se encuentra el pago, mostrar los datos
                encontrado = true;
                Console.WriteLine($"Pago encontrado:");
                Console.WriteLine($"Número de Pago: {numeroPago[i]}");
                Console.WriteLine($"Fecha: {fecha[i]}");
                Console.WriteLine($"Hora: {hora[i]}");
                Console.WriteLine($"Cédula: {cedula[i]}");
                Console.WriteLine($"Nombre: {nombre[i]}");
                Console.WriteLine($"Apellido1: {apellido1[i]}");
                Console.WriteLine($"Apellido2: {apellido2[i]}");
                Console.WriteLine($"Número de Caja: {numeroCaja[i]}");
                Console.WriteLine($"Tipo de Servicio: {tipoServicio[i]}");
                Console.WriteLine($"Número de Factura: {numeroFactura[i]}");
                Console.WriteLine($"Monto a Pagar: {montoPagar[i]}");
                Console.WriteLine($"Monto Comisión: {montoComision[i] * montoPagar[i]}");
                Console.WriteLine($"Monto Deducido: {montoDeducido[i]}");
                Console.WriteLine($"Monto Paga Cliente: {montoPagaCliente[i]}");
                Console.WriteLine($"Vuelto: {vuelto[i]}");
                break;
            }
        }

        // Si no se encuentra el pago, mostrar un mensaje
        if (!encontrado)
        {
            Console.WriteLine("Pago no se encuentra Registrado.");
        }

        Console.WriteLine("\nPresione cualquier tecla para regresar al menú principal.");
        Console.ReadKey();
    }

    static void ModificarPagos()
    {
        Console.Clear(); // Limpiar la ventana

        // Solicitar al usuario el número de pago que desea modificar
        Console.Write("Ingrese el número de pago que desea modificar: ");
        int numeroModificacion = int.Parse(Console.ReadLine());

        bool encontrado = false;

        // Buscar el pago en los vectores
        for (int i = 0; i < size; i++)
        {
            if (pagosRealizados[i] && numeroPago[i] == numeroModificacion)
            {
                // Si se encuentra el pago, mostrar todos los datos
                encontrado = true;
                Console.WriteLine($"Pago encontrado:");
                Console.WriteLine($"Número de Pago: {numeroPago[i]}");
                Console.WriteLine($"Fecha: {fecha[i]}");
                Console.WriteLine($"Hora: {hora[i]}");
                Console.WriteLine($"Cédula: {cedula[i]}");
                Console.WriteLine($"Nombre: {nombre[i]}");
                Console.WriteLine($"Apellido1: {apellido1[i]}");
                Console.WriteLine($"Apellido2: {apellido2[i]}");
                Console.WriteLine($"Número de Caja: {numeroCaja[i]}");
                Console.WriteLine($"Tipo de Servicio: {tipoServicio[i]}");
                Console.WriteLine($"Número de Factura: {numeroFactura[i]}");
                Console.WriteLine($"Monto a Pagar: {montoPagar[i]}");
                Console.WriteLine($"Monto Comisión: {montoComision[i] * montoPagar[i]}");
                Console.WriteLine($"Monto Deducido: {montoDeducido[i]}");
                Console.WriteLine($"Monto Paga Cliente: {montoPagaCliente[i]}");
                Console.WriteLine($"Vuelto: {vuelto[i]}");
                Console.WriteLine();

                // Menú para modificar datos
                do
                {
                    Console.WriteLine("Seleccione el dato que desea modificar:");
                    Console.WriteLine("1. Fecha");
                    Console.WriteLine("2. Hora");
                    Console.WriteLine("3. Cédula");
                    Console.WriteLine("4. Nombre");
                    Console.WriteLine("5. Apellido1");
                    Console.WriteLine("6. Apellido2");
                    Console.WriteLine("7. Número de Caja");
                    Console.WriteLine("8. Tipo de Servicio");
                    Console.WriteLine("9. Número de Factura");
                    Console.WriteLine("10. Monto a Pagar");
                    Console.WriteLine("11. Monto Paga Cliente");
                    Console.WriteLine("12. Salir");

                    Console.Write("Seleccione una opción: ");
                    int opcionModificar = int.Parse(Console.ReadLine());

                    switch (opcionModificar)
                    {
                        case 1:
                            Console.Write("Ingrese la nueva fecha (dd/mm/yyyy): ");
                            fecha[i] = DateTime.Parse(Console.ReadLine());
                            break;
                        case 2:
                            Console.Write("Ingrese la nueva hora (hh:mm): ");
                            hora[i] = Console.ReadLine();
                            break;
                        case 3:
                            Console.Write("Ingrese la nueva cédula: ");
                            cedula[i] = Console.ReadLine();
                            break;
                        case 4:
                            Console.Write("Ingrese el nuevo nombre: ");
                            nombre[i] = Console.ReadLine();
                            break;
                        case 5:
                            Console.Write("Ingrese el nuevo primer apellido: ");
                            apellido1[i] = Console.ReadLine();
                            break;
                        case 6:
                            Console.Write("Ingrese el nuevo segundo apellido: ");
                            apellido2[i] = Console.ReadLine();
                            break;
                        case 7:
                            Console.Write("Ingrese el nuevo número de caja: ");
                            numeroCaja[i] = int.Parse(Console.ReadLine());
                            break;
                        case 8:
                            Console.Write("Ingrese el nuevo tipo de servicio (1= Recibo de Luz, 2= Recibo Teléfono, 3= Recibo de Agua): ");
                            int nuevoTipo = int.Parse(Console.ReadLine());
                            switch (nuevoTipo)
                            {
                                case 1:
                                    tipoServicio[i] = "Recibo de Luz";
                                    montoComision[i] = 0.04;
                                    break;
                                case 2:
                                    tipoServicio[i] = "Recibo Teléfono";
                                    montoComision[i] = 0.055;
                                    break;
                                case 3:
                                    tipoServicio[i] = "Recibo de Agua";
                                    montoComision[i] = 0.065;
                                    break;
                                default:
                                    Console.WriteLine("Tipo de servicio no válido.");
                                    break;
                            }
                            montoDeducido[i] = montoPagar[i] * (1 - montoComision[i]);
                            break;
                        case 9:
                            Console.Write("Ingrese el nuevo número de factura: ");
                            numeroFactura[i] = Console.ReadLine();
                            break;
                        case 10:
                            Console.Write("Ingrese el nuevo monto a pagar: ");
                            montoPagar[i] = double.Parse(Console.ReadLine());
                            montoDeducido[i] = montoPagar[i] * (1 - montoComision[i]);
                            break;
                        case 11:
                            Console.Write("Ingrese el nuevo monto que paga el cliente: ");
                            montoPagaCliente[i] = double.Parse(Console.ReadLine());
                            if (montoPagaCliente[i] < montoPagar[i])
                            {
                                Console.WriteLine("El monto que paga el cliente no puede ser menor al monto a pagar.");
                            }
                            else
                            {
                                vuelto[i] = montoPagaCliente[i] - montoPagar[i];
                            }
                            break;
                        case 12:
                            Console.WriteLine("Saliendo de modificación...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente nuevamente.");
                            break;
                    }

                    Console.WriteLine("¿Desea modificar otro dato? (s/n): ");
                } while (Console.ReadLine().ToLower() == "s");

                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Pago no se encuentra Registrado.");
        }

        Console.WriteLine("\nPresione cualquier tecla para regresar al menú principal.");
        Console.ReadKey();
    }


    static void EliminarPagos()
    {
        Console.Clear(); // Limpiar la ventana

        // Solicitar al usuario el número de pago que desea eliminar
        Console.Write("Ingrese el número de pago que desea eliminar: ");
        int numeroEliminacion = int.Parse(Console.ReadLine());

        bool encontrado = false;

        // Buscar el pago en los vectores
        for (int i = 0; i < size; i++)
        {
            if (pagosRealizados[i] && numeroPago[i] == numeroEliminacion)
            {
                // Si se encuentra el pago, mostrar todos los datos
                encontrado = true;
                Console.WriteLine($"Pago encontrado:");
                Console.WriteLine($"Número de Pago: {numeroPago[i]}");
                Console.WriteLine($"Fecha: {fecha[i]}");
                Console.WriteLine($"Hora: {hora[i]}");
                Console.WriteLine($"Cédula: {cedula[i]}");
                Console.WriteLine($"Nombre: {nombre[i]}");
                Console.WriteLine($"Apellido1: {apellido1[i]}");
                Console.WriteLine($"Apellido2: {apellido2[i]}");
                Console.WriteLine($"Número de Caja: {numeroCaja[i]}");
                Console.WriteLine($"Tipo de Servicio: {tipoServicio[i]}");
                Console.WriteLine($"Número de Factura: {numeroFactura[i]}");
                Console.WriteLine($"Monto a Pagar: {montoPagar[i]}");
                Console.WriteLine($"Monto Comisión: {montoComision[i] * montoPagar[i]}");
                Console.WriteLine($"Monto Deducido: {montoDeducido[i]}");
                Console.WriteLine($"Monto Paga Cliente: {montoPagaCliente[i]}");
                Console.WriteLine($"Vuelto: {vuelto[i]}");

                // Preguntar al usuario si está seguro de eliminar el dato
                Console.Write("¿Está seguro de eliminar el dato? (S/N): ");
                char respuesta = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (respuesta == 'S')
                {
                    // Eliminar el pago
                    pagosRealizados[i] = false;
                    Console.WriteLine("La información ya fue eliminada.");
                }
                else
                {
                    Console.WriteLine("La información no fue eliminada.");
                }

                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Pago no se encuentra Registrado.");
        }

        Console.WriteLine("\nPresione cualquier tecla para regresar al menú principal.");
        Console.ReadKey();
    }

    static void VerTodosLosPagos()
    {
        Console.Clear(); // Limpiar la ventana

        Console.WriteLine("Todos los Pagos:");

        // Mostrar todos los pagos realizados
        for (int i = 0; i < size; i++)
        {
            if (pagosRealizados[i])
            {
                Console.WriteLine($"Número de Pago: {numeroPago[i]}");
                Console.WriteLine($"Fecha: {fecha[i]}");
                Console.WriteLine($"Hora: {hora[i]}");
                Console.WriteLine($"Cédula: {cedula[i]}");
                Console.WriteLine($"Nombre: {nombre[i]}");
                Console.WriteLine($"Apellido1: {apellido1[i]}");
                Console.WriteLine($"Apellido2: {apellido2[i]}");
                Console.WriteLine($"Número de Caja: {numeroCaja[i]}");
                Console.WriteLine($"Tipo de Servicio: {tipoServicio[i]}");
                Console.WriteLine($"Número de Factura: {numeroFactura[i]}");
                Console.WriteLine($"Monto a Pagar: {montoPagar[i]}");
                Console.WriteLine($"Monto Comisión: {montoComision[i] * montoPagar[i]}");
                Console.WriteLine($"Monto Deducido: {montoDeducido[i]}");
                Console.WriteLine($"Monto Paga Cliente: {montoPagaCliente[i]}");
                Console.WriteLine($"Vuelto: {vuelto[i]}");
                Console.WriteLine();
            }
        }
    }

    static void VerPagosPorTipoServicio()
    {
        Console.Clear(); // Limpiar la ventana

        // Mostrar los pagos agrupados por tipo de servicio
        Console.WriteLine("Pagos por Tipo de Servicio:");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Tipo de Servicio\tCantidad de Pagos");
        Console.WriteLine("---------------------------------------");

        int[] contadorPorTipo = new int[3]; // Vector para contar la cantidad de pagos por tipo de servicio

        for (int i = 0; i < size; i++)
        {
            if (pagosRealizados[i])
            {
                switch (tipoServicio[i])
                {
                    case "Recibo de Luz":
                        contadorPorTipo[0]++;
                        break;
                    case "Recibo Teléfono":
                        contadorPorTipo[1]++;
                        break;
                    case "Recibo de Agua":
                        contadorPorTipo[2]++;
                        break;
                }
            }
        }

        Console.WriteLine($"Recibo de Luz\t\t{contadorPorTipo[0]}");
        Console.WriteLine($"Recibo Teléfono\t\t{contadorPorTipo[1]}");
        Console.WriteLine($"Recibo de Agua\t\t{contadorPorTipo[2]}");
    }
        static void VerPagosPorCodigoCaja()
        {
            Console.Clear(); // Limpiar la ventana

            // Mostrar los pagos agrupados por código de caja
            Console.WriteLine("Pagos por Código de Caja:");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Código de Caja\tCantidad de Pagos");
            Console.WriteLine("---------------------------------------");

            int[] contadorPorCaja = new int[3]; // Vector para contar la cantidad de pagos por código de caja

            for (int i = 0; i < size; i++)
            {
                if (pagosRealizados[i])
                {
                    contadorPorCaja[numeroCaja[i] - 1]++;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"{i + 1}\t\t{contadorPorCaja[i]}");
            }
        }
    

    static void VerDineroComisionadoPorServicios()
    {
        Console.Clear(); // Limpiar la ventana

        // Calcular y mostrar el dinero comisionado por servicios
        double comisionReciboLuz = 0;
        double comisionReciboTelefono = 0;
        double comisionReciboAgua = 0;

        for (int i = 0; i < size; i++)
        {
            if (pagosRealizados[i])
            {
                switch (tipoServicio[i])
                {
                    case "Recibo de Luz":
                        comisionReciboLuz += montoComision[i] * montoPagar[i];
                        break;
                    case "Recibo Teléfono":
                        comisionReciboTelefono += montoComision[i] * montoPagar[i];
                        break;
                    case "Recibo de Agua":
                        comisionReciboAgua += montoComision[i] * montoPagar[i];
                        break;
                }
            }
        }

        Console.WriteLine("Dinero Comisionado por Servicios:");
        Console.WriteLine($"Recibo de Luz: ${comisionReciboLuz}");
        Console.WriteLine($"Recibo Teléfono: ${comisionReciboTelefono}");
        Console.WriteLine($"Recibo de Agua: ${comisionReciboAgua}");
    }
}
