using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Prestamos
{
    private int codigo;
    private string nombre;
    private long carnet;
    private string carrera;
    private string equipoPrestado;
    private int cantidad;
    private string estado = "Disponible";

    public Prestamos(int codigo, string nombre, long carnet, string carrera, string equipoPrestado, int cantidad, string estado)
    {
        this.codigo = codigo;
        this.nombre = nombre;
        this.carnet = carnet;
        this.carrera = carrera;
        this.equipoPrestado = equipoPrestado;
        this.cantidad = cantidad;
        this.estado = estado;
    }

    public int ObtenerCodigo()
    {
        return codigo;
    }

    public string ObtenerDatos()
    {
        return "Codigo: "+ codigo+  Environment.NewLine +
            "Nombre: " + nombre + Environment.NewLine +
            "Carnet: " + carnet + Environment.NewLine +
            "Carrera: " + carrera + Environment.NewLine +
            "Equipo Prestado: " + equipoPrestado + Environment.NewLine +
            "Cantidad: " + cantidad + Environment.NewLine +
            "Estado: " + estado + Environment.NewLine +
            "--------------------------- " + Environment.NewLine;
    }
    public void GuardarArchivo(string ruta)
    {
        File.AppendAllText(ruta, ObtenerDatos());
    }
}

class Program
{
   static void Main()
    {
        string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Prestamos.txt");

        Dictionary<int, Prestamos> cliente = new Dictionary<int, Prestamos>();
        string estado;
        int codigo,cantidad;
        long carnet;
        int opcion;
        bool validacion;

        do {
            Console.Clear();
            Console.WriteLine("Menu: ");
            Console.WriteLine("Opcion 1: Registrar Prestamo");
            Console.WriteLine("Opcion 2: Buscar Prestamo");
            Console.WriteLine("Opcion 3: Mostrar Informacion");
            Console.WriteLine("Opcion 4: Eliminar datos");
            Console.WriteLine("Opcion 5: Salir");
            Console.Write("Opcion:  ");

            while (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opcion invalida");
            }

            switch (opcion)
            {
                    case 1:
                    Console.Clear();
                    int op;
                    do
                    {
                        Console.WriteLine("");
                        Console.Write("Ingrese el codigo: ");
                        codigo = int.Parse(Console.ReadLine());

                        if (cliente.ContainsKey(codigo))
                        {
                            Console.WriteLine("El codigo ya fue registrado");

                        }


                        else
                        {
                            Console.Write("Ingrese el nombre: ");
                            string nombre = Console.ReadLine();


                            do
                            {
                                Console.Write("Ingrese su carnet: ");
                                validacion = long.TryParse(Console.ReadLine(), out carnet);

                                if (!validacion || carnet.ToString().Length != 8)
                                {
                                    Console.WriteLine("El carnet no tiene 8 digitos.");
                                    validacion = false;
                                }

                            } while (!validacion);


                            Console.Write("Ingrese la carrera: ");
                            string carrera = Console.ReadLine();

                            Console.Write("Ingrese el equipo prestado: ");
                            string equipoPrestado = Console.ReadLine();

                            Console.Write("Ingrese la cantidad: ");
                         while (!int.TryParse(Console.ReadLine(), out cantidad))
                            {
                                Console.WriteLine("Dato erroneo");
                            }


                            Console.Write("Ingrese el estado: ");
                            estado = Console.ReadLine();



                            Prestamos dato = new Prestamos(codigo, nombre, carnet, carrera, equipoPrestado, cantidad, estado);
                            cliente.Add(codigo, dato);
                            dato.GuardarArchivo(ruta);

                        }

                        Console.WriteLine("Desea ingresa otro");
                        Console.WriteLine("Opcion 1: si");
                        Console.WriteLine("Opcion 2: no");
                        Console.Write("Ingrese: ");
                        op = int.Parse(Console.ReadLine());

                    } while (op == 1);
                    Console.WriteLine("Proceso finalizado");

                    break;
                    case 2:
                    Console.Clear();
                    Console.WriteLine("Buscar");

                    Console.Write("Ingresa el codigo: ");
                    codigo = int.Parse(Console.ReadLine());
                    if (cliente.ContainsKey(codigo))
                    {

                       Console.WriteLine(cliente[codigo].ObtenerDatos()); 

                    }
                    else
                    {
                        Console.WriteLine("No existe");
                    }
                    Console.ReadKey();
                    break;
                    
                    case 3:
                    Console.Clear();
                    Console.WriteLine("Mostrar");

                  
                    if (cliente.Count > 0)
                    {
                        foreach (var item in cliente)
                        {
                            Console.WriteLine("" + item.Value.ObtenerDatos());

                        }

                    }
                    else
                    {
                        Console.WriteLine("No existe");
                    }
                    Console.ReadKey();
                    break;


                    case 4:
                    Console.Clear();
                    Console.WriteLine("Eliminar");

                    Console.Write("Ingresa el codigo: ");
                    codigo = int.Parse(Console.ReadLine());
                    if (cliente.ContainsKey(codigo))
                    {
                        cliente.Remove(codigo);
                        Console.WriteLine("Eliminado correctamente");
                    }
                    else
                    {
                        Console.WriteLine("No existe");
                    }
                    Console.ReadKey();
                   
                    break;
                default:
                    break;

            }
              

        } while (opcion != 5);

    }
}