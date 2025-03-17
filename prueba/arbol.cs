
//búsqueda iterativa para saber si un titulo existe dentro de un catálogo de revistas, adjunte el link del repositorio de código. 
//Cree un catálogo de revistas.
class Nodo
{
    public string Titulo;
    public Nodo nodIz;
    public Nodo nodoDer;
    
    public Nodo(string titulo)
    {
        Titulo = titulo;
        nodIz = null;
        nodoDer = null;
    }
}

class Arbol
{
    private Nodo raiz;

    public void Insertar(string titulo)
    {
        raiz = InsertarRec(raiz, titulo);
    }

    private Nodo InsertarRec(Nodo nodo, string titulo)
    {

        if (string.Compare(titulo, nodo.Titulo) < 0)
        {
            nodo.nodIz = InsertarRec(nodo.nodIz, titulo);
        }
        else if (string.Compare(titulo, nodo.Titulo) > 0)
        {
            nodo.nodoDer = InsertarRec(nodo.nodoDer, titulo);
        }
        return nodo;
    }

    public bool Buscar(string titulo)
    {
        return BuscarRec(raiz, titulo);
    }

    private bool BuscarRec(Nodo nodo, string titulo)
    {
        if (nodo == null)
        {
            return false;
        }
        if (nodo.Titulo.Equals(titulo))
        {
            return true;
        }
        return string.Compare(titulo, nodo.Titulo) < 0 ?
               BuscarRec(nodo.nodIz, titulo) :
               BuscarRec(nodo.nodoDer, titulo);
    }
      private Nodo EliminarRec(Nodo nodo, string titulo)
    {
        if (nodo == null)
        {
            return null;
        }
        if (string.Compare(titulo, nodo.Titulo) < 0)
        {
            nodo.nodIz = EliminarRec(nodo.nodIz, titulo);
        }
        else if (string.Compare(titulo, nodo.Titulo) > 0)
        {
            nodo.nodoDer = EliminarRec(nodo.nodoDer, titulo);
        }
        else
        {
            if (nodo.nodIz == null)
                return nodo.nodoDer;
            else if (nodo.nodoDer == null)
                return nodo.nodIz;
            
            Nodo sucesor = EncontrarMinimo(nodo.nodoDer);
            nodo.Titulo = sucesor.Titulo;
            nodo.nodoDer = EliminarRec(nodo.nodoDer, sucesor.Titulo);
        }
        return nodo;
    }

    private Nodo EncontrarMinimo(Nodo nodo)
    {
        while (nodo.nodIz != null)
        {
            nodo = nodo.nodIz;
        }
        return nodo;
    }

    internal void Eliminar(string? tituloEliminar)
    {
        throw new NotImplementedException();
    }
}


class Program
{
    static void Main()
    {
        Arbol catalogo = new Arbol();
        string[] revistas = { "National Geographic", "Time", "Forbes", "Scientific American", "Popular Science", "The Economist", "Nature", "Science", "Harvard Business Review", "Wired" };
        
        foreach (string revista in revistas)
        {
            catalogo.Insertar(revista);
        }
        
        while (true)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Agregar un título");
            Console.WriteLine("3. Eliminar un título");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            
            string opcion = Console.ReadLine();
            
            if (opcion == "1")
            {
                Console.Write("Ingrese el título a buscar: ");
                string tituloBuscar = Console.ReadLine();
                Console.WriteLine(catalogo.Buscar(tituloBuscar) ? "Encontrado" : "No encontrado");
            }
            else if (opcion == "2")
            {
                Console.Write("Ingrese el título a agregar: ");
                string tituloAgregar = Console.ReadLine();
                catalogo.Insertar(tituloAgregar);
                Console.WriteLine("Título agregado correctamente.");
            }
            else if (opcion == "3")
            {
                Console.Write("Ingrese el título a eliminar: ");
                string tituloEliminar = Console.ReadLine();
                catalogo.Eliminar(tituloEliminar);
                Console.WriteLine("Título eliminado correctamente.");
            }
            else if (opcion == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }
}
