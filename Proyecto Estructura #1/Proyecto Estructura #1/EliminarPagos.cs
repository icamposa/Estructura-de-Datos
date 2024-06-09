using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Estructura__1
{
    internal class EliminarPagos
    {
    }
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
