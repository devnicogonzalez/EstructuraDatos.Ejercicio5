using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraDatos.Ejercicio5.Datos;

internal class Producto
{
    public static List<Producto> Todos = new List<Producto>();

    public string Codigo { get; set; }
    public string NombreCorto { get; set; }
    public string Descripcion { get; set; }
    public decimal? Costo { get; set; } /* ? => significa que puede ser un numero decimal o nulo */
    public decimal Precio { get; set; }

    public List<string> Componentes { get; set; }
}
