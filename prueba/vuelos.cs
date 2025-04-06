public class Vuelos
{
    private Dictionary<string, List<(string Destino, int Precio)>> aeropuertos;

    public Vuelos()
    {
        aeropuertos = new Dictionary<string, List<(string Destino, int Precio)>>();
    }

    public void AgregarVuelo(string origen, string destino, int precio)
    {
        if (!aeropuertos.ContainsKey(origen))
        {
            aeropuertos[origen] = new List<(string Destino, int Precio)>();
        }
        if (!aeropuertos.ContainsKey(destino))
        {
            aeropuertos[destino] = new List<(string Destino, int Precio)>();
        }
        aeropuertos[origen].Add((destino, precio));
    }

    public (int PrecioMinimo, List<string> ruta) EncontrarVueloBarato(string inicio, string fin)
    {
        var distancias = aeropuertos.Keys.ToDictionary(aeropuerto => aeropuerto, aeropuerto => int.MaxValue);
        distancias[inicio] = 0;
        var colaPrioridad = new PriorityQueue<(int Precio, string Aeropuerto, List<string> ruta), int>();
        colaPrioridad.Enqueue((0, inicio, new List<string> { inicio }), 0);

        while (colaPrioridad.Count > 0)
        {
            var (precioActual, aeropuertoActual, itinerarioActual) = colaPrioridad.Dequeue();

            if (aeropuertoActual == fin)
            {
                return (precioActual, itinerarioActual);
            }

            if (precioActual > distancias[aeropuertoActual])
            {
                continue;
            }

            if (aeropuertos.ContainsKey(aeropuertoActual))
            {
                foreach (var vuelo in aeropuertos[aeropuertoActual])
                {
                    string vecino = vuelo.Destino;
                    int precioVuelo = vuelo.Precio;
                    int precioTotal = precioActual + precioVuelo;

                    if (precioTotal < distancias[vecino])
                    {
                        distancias[vecino] = precioTotal;
                        var nuevaruta = new List<string>(itinerarioActual);
                        nuevaruta.Add(vecino);
                        colaPrioridad.Enqueue((precioTotal, vecino, nuevaruta), precioTotal);
                    }
                }
            }
        }

        return (int.MaxValue, new List<string>());
    }

    public void MostrarBaseDeDatos()
    {
        Console.WriteLine("\n--- Base de Datos de Vuelos ---");
        foreach (var origen in aeropuertos.Keys)
        {
            foreach (var vuelo in aeropuertos[origen])
            {
                Console.WriteLine($"{origen} -> {vuelo.Destino}: ${vuelo.Precio}");
            }
        }
        Console.WriteLine("--- Fin de la Base de Datos ---");
    }
}

public class PriorityQueue<T, TPriority> where TPriority : IComparable<TPriority>
{
    private List<(T Item, TPriority Priority)> elements = new List<(T Item, TPriority Priority)>();

    public int Count => elements.Count;

    public void Enqueue(T item, TPriority priority)
    {
        elements.Add((item, priority));
        elements.Sort((a, b) => a.Priority.CompareTo(b.Priority));
    }

    public T Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("La cola de prioridad está vacía.");
        }
        T item = elements[0].Item;
        elements.RemoveAt(0);
        return item;
    }
}

public class Vuelosbaratos
{
    public static void Main(string[] args)
    {
        Vuelos grafo = new Vuelos();
        // Agregar algunos vuelos iniciales
        grafo.AgregarVuelo("Quito", "Guayaquil", 50);
        grafo.AgregarVuelo("Quito", "Cuenca", 80);
        grafo.AgregarVuelo("Guayaquil", "Manta", 40);
        grafo.AgregarVuelo("Cuenca", "Guayaquil", 60);
        grafo.AgregarVuelo("Quito", "Ibarra", 30);
        grafo.AgregarVuelo("Lima", "Santiago", 120);
        grafo.AgregarVuelo("Quito", "Santiago", 280);
        grafo.AgregarVuelo("Quito", "Brazil", 280);
        
//SECCION DE MENU
        while (true)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese la ciudad de origen: ");
                    string origen = Console.ReadLine();
                    Console.Write("Ingrese la ciudad de destino: ");
                    string destino = Console.ReadLine();
                    var resultado = grafo.EncontrarVueloBarato(origen, destino);
                    if (resultado.PrecioMinimo == int.MaxValue)
                    {
                        Console.WriteLine($"No se encontraron vuelos de {origen} a {destino}.");
                    }
                    else
                    {
                        Console.WriteLine($"El vuelo más barato de {origen} a {destino} tiene un precio de: ${resultado.PrecioMinimo}");
                        Console.WriteLine($"El ruta es: {string.Join(" -> ", resultado.ruta)}");
                    }
                    break;
                case "2":
                    Console.Write("Ingrese la ciudad de origen del nuevo vuelo: ");
                    string nuevoOrigen = Console.ReadLine();
                    Console.Write("Ingrese la ciudad de destino del nuevo vuelo: ");
                    string nuevoDestino = Console.ReadLine();
                    Console.Write("Ingrese el precio del vuelo: ");
                    if (int.TryParse(Console.ReadLine(), out int nuevoPrecio))
                    {
                        grafo.AgregarVuelo(nuevoOrigen, nuevoDestino, nuevoPrecio);
                        Console.WriteLine("Vuelo agregado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Precio inválido.");
                    }
                    break;
                case "3":
                    grafo.MostrarBaseDeDatos();
                    break;
                case "4":
                    Console.WriteLine("¡Gracias por usar el buscador de vuelos!");
                    return;
                default:
                    Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                    break;
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");

        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("*******************************************************************");
        Console.WriteLine("                    UNIVERSIDAD ESTATAL AMAZONICA                   ");
        Console.WriteLine("**********************************************************************");
        Console.WriteLine("");
        Console.WriteLine("***********************   MENU DE OPCIONE ****************************************");
        Console.WriteLine("");
        Console.WriteLine("1. Buscar Vuelos Baratos");
        Console.WriteLine("2. Agregar Nuevo Vuelo");
        Console.WriteLine("3. Mostrar Base de Datos de Vuelos");
        Console.WriteLine("4. Salir");
        Console.Write("Seleccione una opción: ");
    }
}