using EstructuraDatos.Ejercicio5.Datos;
using System.Globalization;

namespace EstructuraDatos.Ejercicio5
{
    internal class GrabarArchivo
    {
        /*
         * Formato del archivo de productos
         * 1 linea para cada producto
         * [Codigo];[Nombre corto];[Descripcion];[Costo];[Precio];[Componentes 1..n]
         */

        /*Ejemplo*/
        /*             
        ABCGGH;Tuercas;Tuercas cromadas 4mm;3.56;10.44;HIJKKL|PRTKGJ|PIUYTH
        HIJKKL;Acero;Acero base;3.2;10.00;
        PRTKGJ;Transporte;1.64;200.10;LLOMMT|FFFKKK
        PIUYTH;Energia;2.5;45.2;
        LLOMMT;Alquiler prop.;100.2;40.5;
        FFFKKK;RRHH prop.;10.4;55.2;
        */

        /*Otra posibilidad para componentes => archivo aparte (cabecera/detalle).*/

        /*Productos.txt*/
        /*1 linea para cada producto
         [Codigo]; [Nombre corto]; [Descripcion]; [Costo]; [Precio]; 


        ProductosComponentes.txt => guarda las relaciones entre productos.
        1 línea por relación.
        [CodigoProducto];[CodigoComponente]

        Ejemplo: mismos datos que el anterior.

        Productos.txt
        ABCGGH;Tuercas;Tuercas cromadas 4mm;3.56;10.44
        HIJKKL;Acero;Acero base;3.2;10.00
        PRTKGJ;Transporte;1.64;200.10
        PIUYTH;Energia;2.5;45.2
        LLOMMT;Alquiler prop.;100.2;40.5
        FFFKKK;RRHH prop.;10.4;55.2

        ProductosComponentes.txt
        ABCGGH;HIJKKL 
        ABCGGH;PRTKGJ
        ABCGGH;PIUYTH
        PRTKGJ;LLOMMT
        PRTKGJ;FFFKKK           
        */

        internal static void Iniciar()
        {
            //Recomendación: NUNCA explicitar la ruta, solo el nombre, y que
            //se grabe en la carpeta por defecto. Normalmente es:
            //[Carpeta del proyecto]\bin\debug

            //crea un archivo nuevo y devuelve un StreamWriter
            //para escribir en él.
            using StreamWriter writer = File.CreateText("Productos.txt");

            foreach (Producto producto in Producto.Todos)
            {
                //[Codigo];[Nombre corto];[Descripcion];[Costo];[Precio];[Componentes 1..n]                
                //ABCGGH;Tuercas;Tuercas cromadas 4mm;3.56;10.44;HIJKKL|PRTKGJ|PIUYTH

                string linea = producto.Codigo + ";" +
                    producto.NombreCorto + ";" +
                    producto.Descripcion + ";" +
                    producto.Costo?.ToString(CultureInfo.InvariantCulture) + ";" +
                    producto.Precio.ToString(CultureInfo.InvariantCulture) + ";";

                foreach (string componente in producto.Componentes)
                {
                    linea = linea + componente + "|";
                }

                if (linea.EndsWith("|"))
                {
                    linea = linea.Substring(0, linea.Length - 1);
                }

                writer.WriteLine(linea);
            }
        }
    }
}
