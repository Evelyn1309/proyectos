//Desarrolle un traductor básico de inglés español o español ingles utilizando para ello diccionarios

class TraductorInEs
{
    //Crea un el diccionario ingles español.
    static readonly Dictionary<string, string> InglesaEspanol = new Dictionary<string, string>
    {
        {"time", "tiempo"},
        {"person", "persona"},
        {"year", "año"},
        {"love", "amor"},
        {"I", "yo"},
        {"they", "ellos"},
        {"man", "hombre"},
        {"word", "trabajo"},
        {"eyes", "ojo"},
        {"Sky", "cielo"},
        {"my dear", "cariño"},
        {"child", "niño/a"},
        {"celestial", "celeste"},
        {"woman", "mujer"},
        {"city", "ciudad"},
        {"Cellphone", "celular"},
        {"computer", "computadora"},
        {"night", "noche"},
        {"Days", "dia"},
        {"restaurant", "restaurante"},
        {"sing", "cantar"}
    };

//Crea un diccionario español a ingles 
 static Dictionary<string, string> EspanoalIngles = new Dictionary<string, string>();

    static void Main(string[] args)
    {
        //Inicializa el diccionario español ingles invirtiendo el diccionario ingles español.
        foreach(KeyValuePair<string, string> palabra in InglesaEspanol){
            EspanoalIngles.Add(palabra.Value, palabra.Key);
        }

//Crea un menu de opciones 
        int opcion;
        do
        { 
            MostrarMenu();
            opcion = ObtenerOpcion();

            switch (opcion)// Estructura switch para manejar las opciones del menú.
            {
                case 1:
                    Traducir();// Llama al método para traducir una frase.
                    break;
                case 2:
                    AgregarPalabraAlDiccionario();// Llama al método para agregar una palabra al diccionario.
                    break;
                case 0:
                    Console.WriteLine("¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        } while (opcion != 0);
    }

//Traduce a palabra
    static void Traducir()
    {
        Console.WriteLine("1. Inglés a español");
        Console.WriteLine("2. Español a inglés");
        int opcionIdioma = ObtenerOpcion();

        Console.Write("Ingrese la frase: ");
        string frase = Console.ReadLine().ToLower();

        if (opcionIdioma == 1)
        {
            Console.WriteLine("Traducción: " + TraducirFrase(frase, EspanoalIngles));
        }
        else if (opcionIdioma == 2)
        {
            Console.WriteLine("Traducción: " + TraducirFrase(frase, InglesaEspanol));
        }
        else
        {
            Console.WriteLine("Opción de idioma inválida.");
        }
    }

// Método para traducir una frase utilizando un diccionario dado.
    static string TraducirFrase(string frase, Dictionary<string, string> diccionario)
    {
        string[] palabras = frase.Split(' ');
        List<string> palabrasTraducidas = new List<string>();

        foreach (string palabra in palabras)
        {
            if (diccionario.ContainsKey(palabra))
            {
                palabrasTraducidas.Add(diccionario[palabra]);
            }
            else
            {
                palabrasTraducidas.Add(palabra); // Si no se encuentra, se deja la palabra original.
            }
        }

        return string.Join(" ", palabrasTraducidas);
    }

// Método para agregar una palabra al diccionario.
    static void AgregarPalabraAlDiccionario()
    {
        Console.WriteLine("1. Inglés a español");
        Console.WriteLine("2. Español a inglés");
        int opcionIdioma = ObtenerOpcion();

        Console.Write("Ingrese la palabra original: ");
        string Original = Console.ReadLine().ToLower();

        Console.Write("Ingrese la palabra traducida: ");
        string Traducida = Console.ReadLine().ToLower();

        if (opcionIdioma == 1)
        {
            AgregarPalabra(Original, Traducida, InglesaEspanol, EspanoalIngles);
        }
        else if (opcionIdioma == 2)
        {
            AgregarPalabra(Original, Traducida, EspanoalIngles, InglesaEspanol);
        }
        else
        {
            Console.WriteLine("Opción de idioma inválida.");
        }
    }

    static void AgregarPalabra(string Original, string Traducida, Dictionary<string, string> diccionarioOriginal, Dictionary<string, string> diccionarioTraducido)
    {
        diccionarioOriginal[Original] = Traducida;
        diccionarioTraducido[Traducida] = Original;
        Console.WriteLine("Palabra agregada con éxito.");
    }

// Método para mostrar el menú de opciones.
    static void MostrarMenu()
    {
        Console.WriteLine("*******************************************************************");
        Console.WriteLine("                    UNIVERSIDAD ESTATAL AMAZONICA                   ");
        Console.WriteLine("**********************************************************************");
        Console.WriteLine("");
        Console.WriteLine("***********************   MENU DE OPCIONE ****************************************");
        Console.WriteLine("");
        Console.WriteLine("\n                               MENU");
        Console.WriteLine("=======================================================");
        Console.WriteLine("1. Traducir una frase");
        Console.WriteLine("2. Ingresar más palabras al diccionario");
        Console.WriteLine("0. Salir");
    }

    static int ObtenerOpcion()
    {
        Console.Write("Ingrese una opción: ");
        if (int.TryParse(Console.ReadLine(), out int opcion))
        {
            return opcion;
        }
        return -1;
    }
}