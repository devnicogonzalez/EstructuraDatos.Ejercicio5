using EstructuraDatos.Ejercicio5.Datos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Ejercicio5
{
    internal static class LeerArchivo
    {
        public static void Iniciar()
        {
            //Tienen que utilizar StreamReader.
            using StreamReader reader = new StreamReader("Productos.txt");

            while (!reader.EndOfStream)
            {
                string linea = reader.ReadLine();

                //[Codigo];[Nombre corto];[Descripcion];[Costo];[Precio];[Componentes 1..n]                
                //ABCGGH;Tuercas;Tuercas cromadas 4mm;3.56;10.44;HIJKKL|PRTKGJ|PIUYTH
                //LLLFFF;TOrnillos;Tornillos cromados 4mm;;10.44;HIJKKL|PRTKGJ|PIUYTH
                string[] datos = linea.Split(";"); //devuelve un string[] de 6 posiciones (0..5)

                Producto producto = new Producto();
                producto.Codigo = datos[0];
                producto.NombreCorto = datos[1];
                producto.Descripcion = datos[2];

                //Costo puede estar o no presente (es Nullable<decimal>)
                if (!string.IsNullOrWhiteSpace(datos[3]))
                {
                    producto.Costo = decimal.Parse(datos[3], CultureInfo.InvariantCulture);
                }

                producto.Precio = decimal.Parse(datos[4], CultureInfo.InvariantCulture);

                //en datos[5] yo tengo, por ejemplo: HIJKKL|PRTKGJ|PIUYTH
                string[] componentes = datos[5].Split("|");
                producto.Componentes.AddRange(componentes);

                Producto.Todos.Add(producto);
            }
        }
    }
}
