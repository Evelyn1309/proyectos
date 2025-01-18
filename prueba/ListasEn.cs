//Función que calcule el número de elementos de una lista
public class Nodo
{
    public int Valor; // valor public 
    public Nodo Siguiente ;
}

public class ListaEl // clase para la lista enlazada
{
    public Nodo Cabeza ;

    public int ContarElementos()// clase para contar lo elementos
    {
        int contador = 0; // contador inicializado en 0
        Nodo actual = Cabeza;

        while (actual != null)// mientras en nodo acutul sea  igual a null aumentale 1 este siempre dara paso al siguiente
        {
            contador++;
            actual = actual.Siguiente;
        }

        return contador;// esta funcion vulve al cantado
    }
}

class Prog1
{
    static void Main(string[] args)
    {
        // Se crea una lista enlazada con algunos elementos
        ListaEl miLista = new ListaEl();
        miLista.Cabeza = new Nodo { Valor = 10 };
        miLista.Cabeza.Siguiente = new Nodo { Valor = 20 };
        miLista.Cabeza.Siguiente.Siguiente = new Nodo { Valor = 30 };
        miLista.Cabeza.Siguiente.Siguiente.Siguiente = new Nodo { Valor = 36 };
        miLista.Cabeza.Siguiente.Siguiente.Siguiente.Siguiente = new Nodo { Valor = 33 };

        // Contador de elementos de la lista
        int cantidadElementos = miLista.ContarElementos();

        // Resultados
        Console.WriteLine("*******************************************************************");
        Console.WriteLine("                    UNIVERSIDAD ESTATAL AMAZONICA                   ");
        Console.WriteLine("**********************************************************************");
        Console.WriteLine("");
        Console.WriteLine("***********************   Ejercicio 1 ****************************************");
        Console.WriteLine("");
        Console.WriteLine("La lista tiene un contenido de  " + cantidadElementos + " elementos.");
    }
}
//Crear una lista enlazada con 50 números enteros, del 1 al 999 generados aleatoriamente. Una
//vez creada la lista, vez creada la lista, se deben eliminar los nodos qu se deben eliminar los nodos que estén fuera de un r e estén fuera de un rango de valores leídos ango de valores leídos
//desde el teclado.
public class Nodo2
{
    public int Valor ;
    public Nodo2 Siguiente ;
}

public class ListaEn
{
    public Nodo2 Cabeza ;

    // Método para agregar un nodo al final de la lista
    public void AgregarNodo(int valor)//Agrega un nodo a la lista
    {
        Nodo2 nuevoNodo = new Nodo2 { Valor = valor };
        if (Cabeza == null)
        {
            Cabeza = nuevoNodo;
        }
        else
        {
            Nodo2 actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
    }

    //  eliminar nodos fuera de un rango
    public void EliminarFueraDeRango(int min, int max)
    {
        Nodo2 anterior = null;
        Nodo2 actual = Cabeza;

        while (actual != null)
        {
            if (actual.Valor < min || actual.Valor > max)
            {
                // funcion que nos dice que si el numero esta fuera de rango lo elimina
                if (anterior == null)
                {
                    Cabeza = actual.Siguiente;
                }
                else
                {
                    anterior.Siguiente = actual.Siguiente;//caso contraraio este vulve al nodo anterior o sigue
                }
            }
            else
            {
                anterior = actual;
            }
            actual = actual.Siguiente;
        }
    }

    // Imprime la lista 
    public void ImprimirLista()
    {
        Nodo2 actual = Cabeza;
        while (actual != null)// Mientras que el nodo actual sea null este imprimira de acuerdo ala contador 
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
}

class Prog2
{
    static void Main(string[] args)
    {
        Random random = new Random();
        ListaEn lista = new ListaEn();

        // Crea 50 nodos con valores al azar
        for (int i = 0; i < 50; i++)
        {
            lista.AgregarNodo(random.Next(1, 1000));
        }
        Console.WriteLine("*******************************************************************");
        Console.WriteLine("                    UNIVERSIDAD ESTATAL AMAZONICA                   ");
        Console.WriteLine("**********************************************************************");
        Console.WriteLine("");
        Console.WriteLine("***********************   MENU DE OPCIONE ****************************************");
        Console.WriteLine("");
        Console.WriteLine("Lista original:");// Imprime la lista original que se creo 
        lista.ImprimirLista();

        // Leer rango del usuario
        Console.Write("Ingrese el límite inferior: ");//Pide ingresar un numero 
        int min = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el límite superior: ");//Pide ingresar un numero
        int max = int.Parse(Console.ReadLine());

        // Elimina nodos fuera de rango
        lista.EliminarFueraDeRango(min, max);

        Console.WriteLine("Lista después de eliminar elementos fuera de rango ");
        Console.WriteLine("Este fue el resultado ");
        Console.WriteLine(" ");
        lista.ImprimirLista();
    }
}