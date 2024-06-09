using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Estructura__1
{
    internal class SubMenuReportes
    {
    }
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
