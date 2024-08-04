using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Estructura__1
{
    internal class RealizarPago
    {
    }
}


using System;

class Program
{
    // Definir el tamaño del vector
    const int size = 10;

    // Definir vectores para almacenar la información de los pagos
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
    static bool[] pagosRealizados = new bool[size]; // Para saber si se ha realizado un pago en una posición del vector
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

        char continuar;
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
        Console.Write("Ingrese el número de pago a consultar: ");
        int numeroConsulta = int.Parse(Console.ReadLine());

        for (int i = 0; i < size; i++)
        {
            if (pagosRealizados[i] && numeroPago[i] == numeroConsulta)
            {
                Console.WriteLine($"Pago encontrado: Fecha {fecha[i]}, Hora {hora[i]}, Cédula {cedula[i]}, Nombre {nombre[i]}, Apellidos {apellido1[i]} {apellido2[i]}, " +
                    $"Número de Caja {numeroCaja[i]}, Tipo de Servicio {tipoServicio[i]}, Número de Factura {numeroFactura[i]}, Monto a Pagar {montoPagar[i]}, " +
                    $"Monto Comisión {montoComision[i] * montoPagar[i]}, Monto Deducido {montoDeducido[i]}, Monto Pagado por Cliente {montoPagaCliente[i]}, Vuelto {vuelto[i]}");
                return;
            }
        }
        Console.WriteLine("Pago no encontrado.");
    }

    static void ModificarPagos()
    {
        Console.Write("Ingrese el número de pago a modificar: ");
        int numeroModificacion = int.Parse(Console.ReadLine());

        for (int i = 0; i < size; i++)
        {
            if (pagosRealizados[i] && numeroPago[i] == numeroModificacion)
            {
                Console.WriteLine($"Pago encontrado: Fecha {fecha[i]}, Hora {hora[i]}, Cédula {cedula[i]}, Nombre {nombre[i]}, Apellidos {apellido1[i]} {apellido2[i]}, " +
                    $"Número de Caja {numeroCaja[i]}, Tipo de Servicio {tipoServicio[i]}, Número de Factura {numeroFactura[i]}, Monto a Pagar {montoPagar[i]}, " +
                    $"Monto Comisión {montoComision[i] * montoPagar[i]}, Monto Deducido {montoDeducido[i]}, Monto Pagado por Cliente {montoPagaCliente[i]}, Vuelto {vuelto[i]}");

                char continuarModificacion;
                do
                {
                    Console.WriteLine("Seleccione el dato a modificar:");
                    Console.WriteLine("1. Fecha");
                    Console.WriteLine("2. Hora");
                    Console.WriteLine("3. Cédula");
                    Console.WriteLine("4. Nombre");
                    Console.WriteLine("5. Primer Apellido");
                    Console.WriteLine("6. Segundo Apellido");
                    Console.WriteLine("7. Tipo de Servicio");
                    Console.WriteLine("8. Número de Factura");
                    Console.WriteLine("9. Monto a Pagar");
                    Console.WriteLine("10. Monto que Paga el Cliente");
                    Console.WriteLine("11. Salir");
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
                        case 8:
                            Console.Write("Ingrese el nuevo número de factura: ");
                            numeroFactura[i] = Console.ReadLine();
                            break;
                        case 9:
                            Console.Write("Ingrese el nuevo monto a pagar: ");
                            montoPagar[i] = double.Parse(Console.ReadLine());
                            montoDeducido[i] = montoPagar[i] * (1 - montoComision[i]);
                            break;
                        case 10:
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
                        case 11:
                            Console.WriteLine("Saliendo de modificación...");
                            return;
                        default:
                            Console.WriteLine("Opción no válida. Intente nuevamente.");
                            break;
                    }

                    Console.Write("¿Desea modificar otro dato? (s/n): ");
                    continuarModificacion = Console.ReadLine()[0];

                } while (continuarModificacion == 's' || continuarModificacion == 'S');

                Console.WriteLine("Modificación completada.");
                return;
            }
        }
        Console.WriteLine("Pago no se encuentra Registrado.");
    }

    static void EliminarPagos()
    {
        Console.Write("Ingrese el número de pago a eliminar: ");
        int numeroEliminacion = int.Parse(Console.ReadLine());

        for (int i = 0; i < size; i++)
        {
            if (pagosRealizados[i] && numeroPago[i] == numeroEliminacion)
            {
                pagosRealizados[i] = false;
                Console.WriteLine("Pago eliminado correctamente.");
                return;
            }
        }
        Console.WriteLine("Pago no encontrado.");
    }

    static void SubmenuReportes()
    {
        // Implementación del submenú de reportes (si es necesario)
        Console.WriteLine("Funcionalidad de reportes no implementada.");
    }
}
