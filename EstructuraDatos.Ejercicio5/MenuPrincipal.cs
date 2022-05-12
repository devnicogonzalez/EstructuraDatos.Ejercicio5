using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Ejercicio5;

internal static class MenuPrincipal
{
    public static void Mostrar()
    {
        do
        {
            Console.WriteLine("1. Leer archivo");
            Console.WriteLine("2. Agregar productos");
            Console.WriteLine("3. Grabar archivo");
            Console.WriteLine("4. Salir");
            Console.WriteLine("Ingrese su opcion:");
            string ingreso = Console.ReadLine();
            if (!int.TryParse(ingreso, out int opcion))
            {
                Console.WriteLine("Ingrese un número de opción");
                continue;
            }

            if (opcion == 1)
            {
                LeerArchivo.Iniciar();
            }
            else if (opcion == 2)
            {
                AgregarProductos.Iniciar();
            }
            else if (opcion == 3)
            {
                GrabarArchivo.Iniciar();
            }
            else if (opcion == 4)
            {
                break;
            }
            else
            {
                Console.WriteLine("Ingrese un número del 1 a 4.");
            }
        }
        while (true);
    }
}
