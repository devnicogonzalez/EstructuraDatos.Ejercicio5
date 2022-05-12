using EstructuraDatos.Ejercicio5.Datos;

namespace EstructuraDatos.Ejercicio5
{
    internal static class AgregarProductos
    {
        internal static void Iniciar()
        {
            while (true)
            {
                //Datos que componen el producto:
                //[Codigo];[Nombre corto];[Descripcion];[Costo];[Precio];[Componentes 1..n]                

                //ciclo del código
                string codigo = "";
                while (true)
                {
                    Console.WriteLine("Ingrese el código de producto:");
                    codigo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(codigo))
                    {
                        Console.WriteLine("Debe ingresar un código.");
                        continue;
                    }

                    if (codigo.Length != 6)
                    {
                        Console.WriteLine("El código debe consistir de 6 caracteres alfanuméricos.");
                        continue;
                    }

                    bool ok = true;
                    foreach (char caracter in codigo)
                    {
                        if ((caracter < 'A' || caracter > 'Z') && (caracter < '0' || caracter > '9'))
                        {
                            Console.WriteLine("Debe utilizar A-Z y 0-9 solamente.");
                            ok = false;
                            break;
                        }
                    }

                    if (!ok)
                    {
                        continue;
                    }

                    ok = true;
                    foreach(Producto productoExistente in Producto.Todos)
                    {
                        if(codigo == productoExistente.Codigo)
                        {
                            Console.WriteLine("El código ingresado ya existe.");
                            ok = false;
                            break;
                        }
                    }

                    if (!ok)
                    {
                        continue;
                    }


                    break;
                }

                //nombre corto
                string nombreCorto = "";
                while (true)
                {
                    Console.WriteLine("Ingrese el nombre corto.");
                    nombreCorto = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nombreCorto))
                    {
                        Console.Write("Debe ingresar un nombre corto");
                        continue;
                    }

                    if (nombreCorto.Length > 15)
                    {
                        Console.WriteLine("Debe utilizar como máximo 15 caracteres.");
                        continue;
                    }

                    break;
                }

                //descripcion
                string descripcion = "";
                while (true)
                {
                    Console.WriteLine("Ingrese la descripcion.");
                    descripcion = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(descripcion))
                    {
                        Console.Write("Debe ingresar una descripcion");
                        continue;
                    }

                    if (descripcion.Length > 200)
                    {
                        Console.WriteLine("Debe utilizar como máximo 200 caracteres.");
                        continue;
                    }

                    break;
                }

                //costo
                decimal? costo = null;
                while (true)
                {
                    Console.WriteLine("Ingrese el costo o [ENTER] para continuar.");
                    string ingreso = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(ingreso))
                    {
                        break;
                    }

                    if (!decimal.TryParse(ingreso, out decimal costoIngresado))
                    {
                        Console.Write("Ingrese un valor decimal válido.");
                        continue;
                    }

                    if (costoIngresado <= 0M)
                    {
                        Console.Write("El costo debe ser positivo.");
                        continue;
                    }

                    costo = costoIngresado;
                    break;
                }

                //precio
                decimal precio = 0M;
                while (true)
                {
                    Console.WriteLine("Ingrese el precio.");
                    string ingreso = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(ingreso))
                    {
                        Console.Write("Debe ingresar un valor.");
                        continue;
                    }

                    if (!decimal.TryParse(ingreso, out decimal precioIngresado))
                    {
                        Console.Write("Ingrese un valor decimal válido.");
                        continue;
                    }

                    if (precioIngresado <= 0M)
                    {
                        Console.Write("El precio debe ser positivo.");
                        continue;
                    }

                    precio = precioIngresado;
                    break;
                }

                var producto = new Producto();
                producto.Codigo = codigo;
                producto.Descripcion = descripcion;
                producto.NombreCorto = nombreCorto;
                producto.Costo = costo;
                producto.Precio = precio;

                //ciclo de ingreso de componentes.
                while (true)
                {
                    Console.WriteLine("Ingrese un nuevo código de componente o [ENTER] para continuar.");
                    string componente = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(componente))
                    {
                        break;
                    }

                    bool ok = false;
                    foreach (Producto productoYaIngresado in Producto.Todos)
                    {
                        if (componente == productoYaIngresado.Codigo)
                        {
                            ok = true;
                            break;
                        }
                    }
                    if (!ok)
                    {
                        Console.WriteLine("Debe ingresar el código de un producto existente.");
                        continue;
                    }

                    producto.Componentes.Add(componente);
                }

                Producto.Todos.Add(producto);
            }
        }
    }
}