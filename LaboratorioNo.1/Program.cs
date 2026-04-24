class Prestamos
{
    private int codigo;
    private string nombre;
    private string carnet;
    private string carrera;
    private string equipoPrestado;
    private int cantidad;
    private string estado = "Disponible";

    public Prestamos(int codigo, string nombre, string carnet, string carrera, string equipoPrestado, int cantidad, string estado)
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

        Dictionary<int, Prestamos> paciente = new Dictionary<int, Prestamos>();

        int opcion;

        do {

            Console.WriteLine("Desea continuar: ");
            Console.WriteLine("Opcion 1: No");
            Console.WriteLine("Opcion 2: Si");
            Console.WriteLine("Opcion 1: No");
            Console.WriteLine("Opcion 2: Si");
            Console.WriteLine("Opcion 1: No");
            Console.WriteLine("Opcion 2: Si");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                    case 1:

                    int op;
                    do
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese el codigo");
                        int codigo = int.Parse(Console.ReadLine());

                        if (paciente.ContainsKey(codigo))
                        {
                            Console.WriteLine("El codigo ya fue registrado");
                        }
                        else
                        {
                            Console.Write("Ingrese el nombre: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Ingrese el carnet: ");
                            string carnet = Console.ReadLine();
                            Console.Write("Ingrese la carrera: ");
                            string carrera = Console.ReadLine();
                            Console.Write("Ingrese el equipo prestado");
                            string equipoPrestado = Console.ReadLine();
                            Console.Write("Ingrese la cantidad: ");
                            int cantidad = int.Parse(Console.ReadLine());

                            string estado = Console.ReadLine();

                            Prestamos dato = new Prestamos(codigo, paciente);
                            


                        }
                        Console.WriteLine("Desea ingresa otro");
                        Console.WriteLine("Opcion 1: No");
                        Console.WriteLine("Opcion 2: Si");
                        Console.Write("Ingrese: ");
                        op = int.Parse(Console.ReadLine());

                    } while (op == 1);
                    Console.WriteLine("Proceso finalizado");
                    break;
                    case 2:
                    Console.WriteLine("");

                    break;
                    case 3:
                    Console.WriteLine("");

                    break;
                    case 4:
                    Console.WriteLine("");

                    break;
                default:
                    break;

            }


        } while (opcion == 5);

    }
}