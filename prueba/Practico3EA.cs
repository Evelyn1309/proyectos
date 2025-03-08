

public class Premio
{
    public string Tipo;
    public string Lugar;

    public Premio(string tipo, string lugar)
    {
        Tipo = tipo;
        Lugar = lugar;
    }

    public override string ToString()
    {
        return $"- {Tipo} en {Lugar}";
    }
}

public class Deportista
{
    public string Nombre;
    public string Deporte;
    public List<Premio> Premios;

    public Deportista(string nombre, string deporte)
    {
        Nombre = nombre;
        Deporte = deporte;
        Premios = new List<Premio>();
    }

    public void AgregarPremio(Premio premio)
    {
        Premios.Add(premio);
    }

    public override string ToString()
    {
        string premiosString = "";
        foreach (var premio in Premios)
        {
            premiosString += $"  {premio}\n";
        }
        return $"Nombre: {Nombre}\nDeporte: {Deporte}\nPremios:\n{premiosString}";
    }
}

public class ProPremio
{
    private Dictionary<string, Deportista> deportistas = new Dictionary<string, Deportista>();

    public void PremioDeportista(string nombre, string deporte, string tipoPremio, string lugarPremio)
    {
        if (!deportistas.ContainsKey(nombre))
        {
            deportistas[nombre] = new Deportista(nombre, deporte);
        }
        deportistas[nombre].AgregarPremio(new Premio(tipoPremio, lugarPremio));
    }

    public void VerDeportistas()
    {
        foreach (var deportista in deportistas.Values)
        {
            Console.WriteLine(deportista);
            Console.WriteLine(new string('-', 20));
        }
    }

    public void ConsultarDeportista(string nombre)
    {
        if (deportistas.ContainsKey(nombre))
        {
            Console.WriteLine(deportistas[nombre]);
        }
        else
        {
            Console.WriteLine($"No se encontró al deportista {nombre}.");
        }
    }

    public static void Main(string[] args)
    {
        ProPremio programa = new ProPremio();
        int opcion;

        do
        {
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("                    UNIVERSIDAD ESTATAL AMAZONICA                   ");
            Console.WriteLine("**********************************************************************");
            Console.WriteLine("");
            Console.WriteLine("***********************   MENU DE OPCIONE ****************************************");
            Console.WriteLine("");
            Console.WriteLine("\n---                   Menú de Premiación de Deportistas                     ---");
            Console.WriteLine("1. Premiar Deportista");
            Console.WriteLine("2. Visualizar Deportistas");
            Console.WriteLine("3. Consultar Deportista");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                
                switch (opcion)
                {
                    case 1:
                        Console.Write("Nombre del deportista: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Disciplina: ");
                        string disciplina = Console.ReadLine();
                        Console.Write("Tipo de medalla ganada: ");
                        string tipoPremio = Console.ReadLine();
                        Console.Write("Lugar de competencia: ");
                        string lugarPremio = Console.ReadLine();
                        programa.PremioDeportista(nombre, disciplina, tipoPremio, lugarPremio);
                        break;
                    case 2:
                        programa.VerDeportistas();
                        break;
                    case 3:
                        Console.Write("Nombre del deportista a consultar: ");
                        string nombreConsulta = Console.ReadLine();
                        programa.ConsultarDeportista(nombreConsulta);
                        break;
                    case 4:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Ingrese un número.");
            }

        } while (opcion != 4);
    }
}