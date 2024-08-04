using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Estructura__1
{
    internal class ConsultarPagos
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
        Console.Clear(); // Limpiar la ventana
        Console.Write("Ingrese el número de pago a consultar: ");
        int numeroConsulta = int.Parse(Console.ReadLine());

        for (int i = 0; i < size; i++)
        {
            if (pagosRealizados[i] && numeroPago[i] == numeroConsulta)
            {
                Console.Clear(); // Limpiar la ventana
                Console.WriteLine($"Pago encontrado: ");
                Console.WriteLine($"Fecha: {fecha[i]}");
                Console.WriteLine($"Hora: {hora[i]}");
                Console.WriteLine($"Cédula: {cedula[i]}");
                Console.WriteLine($"Nombre: {nombre[i]}");
                Console.WriteLine($"Primer Apellido: {apellido1[i]}");
                Console.WriteLine($"Segundo Apellido: {apellido2[i]}");
                Console.WriteLine($"Número de Caja: {numeroCaja[i]}");
                Console.WriteLine($"Tipo de Servicio: {tipoServicio[i]}");
                Console.WriteLine($"Número de Factura: {numeroFactura[i]}");
                Console.WriteLine($"Monto a Pagar: {montoPagar[i]}");
                Console.WriteLine($"Monto Comisión: {montoComision[i] * montoPagar[i]}");
                Console.WriteLine($"Monto Deducido: {montoDeducido[i]}");
                Console.WriteLine($"Monto Pagado por Cliente: {montoPagaCliente[i]}");
                Console.WriteLine($"Vuelto: {vuelto[i]}");
                return;
            }
        }
        Console.Clear(); // Limpiar la ventana
        Console.WriteLine("Pago no se encuentra Registrado.");
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
                    Console.Write
