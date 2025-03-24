///Registro de notas y el ranking de los estudiante en materias 
public class Estudiante
{
    public string Nombre;
    public string Numerodecedula;
    public Dictionary<string, double> Calificaciones = new Dictionary<string, double>();
    public double Promedio;

    public Estudiante(string nombre, string identificacion)
    {
        Nombre = nombre;
        Numerodecedula = identificacion;
    }

    public void CalcularPromedio()
    {
        if (Calificaciones.Count > 0)
        {
            Promedio = Calificaciones.Values.Average();
        }
    }
}

public class NodoArbol
{
    public Estudiante Estudiante;
    public NodoArbol Izquierda;
    public NodoArbol Derecha;

    public NodoArbol(Estudiante estudiante)
    {
        Estudiante = estudiante;
    }
}

public class ArbolBB
{
    public NodoArbol Raiz;

    public void Insertar(Estudiante estudiante)
    {
        Raiz = Recursivo(Raiz, estudiante);
    }

    private NodoArbol Recursivo(NodoArbol nodo, Estudiante estudiante)
    {
        if (nodo == null)
        {
            return new NodoArbol(estudiante);
        }

        if (estudiante.Promedio < nodo.Estudiante.Promedio)
        {
            nodo.Izquierda = Recursivo(nodo.Izquierda, estudiante);
        }
        else
        {
            nodo.Derecha = Recursivo(nodo.Derecha, estudiante);
        }

        return nodo;
    }

    public List<Estudiante> ObtenerListaInorden()
    {
        List<Estudiante> lista = new List<Estudiante>();
        ObtenerListaInordenRecursivo(Raiz, lista);
        return lista;
    }

    private void ObtenerListaInordenRecursivo(NodoArbol nodo, List<Estudiante> lista)
    {
        if (nodo != null)
        {
            ObtenerListaInordenRecursivo(nodo.Izquierda, lista);
            lista.Add(nodo.Estudiante);
            ObtenerListaInordenRecursivo(nodo.Derecha, lista);
        }
    }
}

public class EstudiantesNotas
{
    private ArbolBB arbolEstudiantes = new ArbolBB();

    public void RegistrarEstudiante()
    {
        Console.Write("Nombre completo: ");
        string nombre = Console.ReadLine();
        Console.Write("Numero de cedula: ");
        string identificacion = Console.ReadLine();

        Estudiante estudiante = new Estudiante(nombre, identificacion);
        arbolEstudiantes.Insertar(estudiante);

        Console.WriteLine("Estudiante registrado con exito.");
    }

    public void AgregarCalificacion(Estudiante estudiante)
    {
        Console.Write("Materia: ");
        string materia = Console.ReadLine();
        Console.Write("Calificacion: ");
        double calificacion = double.Parse(Console.ReadLine());

        estudiante.Calificaciones.Add(materia, calificacion);
        estudiante.CalcularPromedio();

        arbolEstudiantes.Raiz = null; // Reiniciar el arbol para reordenar
        var lista = arbolEstudiantes.ObtenerListaInorden();
        foreach (var est in lista)
        {
            arbolEstudiantes.Insertar(est);
        }
        

        Console.WriteLine("Calificacion agregada con exito.");
    }

    public void MostrarRanking()
    {
        var lista = arbolEstudiantes.ObtenerListaInorden().OrderByDescending(e => e.Promedio).ToList();

        Console.WriteLine("\n--- Ranking de rendimiento ---");
        for (int i = 0; i < lista.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {lista[i].Nombre} - Promedio: {lista[i].Promedio:F2}");
        }
    }

    public void MostrarMenu()
    {
        while (true)
        {
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("                    UNIVERSIDAD ESTATAL AMAZONICA                   ");
            Console.WriteLine("**********************************************************************");
            Console.WriteLine("");
            Console.WriteLine("***********************   MENU DE OPCIONE ****************************************");
            Console.WriteLine("");
            Console.WriteLine("1. Registro del estudiante");
            Console.WriteLine("2. Agregar la calificacion del estudiante");
            Console.WriteLine("3. Mostrar ranking");
            Console.WriteLine("0. Salir");
            Console.Write("Ingrese una opcion: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    RegistrarEstudiante();
                    break;
                case 2:
                    if (arbolEstudiantes.Raiz != null)
                    {
                        Console.WriteLine("Seleccione uno de los estudiante:");
                        var lista = arbolEstudiantes.ObtenerListaInorden();
                        for (int i = 0; i < lista.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {lista[i].Nombre}");
                        }
                        int estudianteIndex = int.Parse(Console.ReadLine()) - 1;
                        AgregarCalificacion(lista[estudianteIndex]);
                    }
                    else
                    {
                        Console.WriteLine("No hay estudiantes registrados.");
                    }
                    break;
                case 3:
                    MostrarRanking();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Opcion invalida.");
                    break;
            }
        }
    }
}

public class PrograEstudiantes
{
    public static void Main(string[] args)
    {
        EstudiantesNotas sistema = new EstudiantesNotas();
        sistema.MostrarMenu();
    }
}