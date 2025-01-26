using System;
using System.Collections.Generic;
// Balance de expresiones
public class BalancedExpressionChecker
{
    public static bool IsBalanced(string expression)
    {
        var Exps = new Stack<char>();

        foreach (char c in expression)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                Exps.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (Exps.Count == 0)
                {
                    return false; // No hay paréntesis de apertura para cerrar
                }
                char top = Exps.Pop();
                if ((c == ')' && top != '(') ||
                    (c == '}' && top != '{') ||
                    (c == ']' && top != '['))
                {
                    return false; // Los paréntesis no coinciden
                }
            }
        }

        return Exps.Count == 0; // La pila debe estar vacía si todos los paréntesis están balanceados
    }

    public static void Main()
    {
        Console.WriteLine("*******************************************************************");
        Console.WriteLine("                    UNIVERSIDAD ESTATAL AMAZONICA                   ");
        Console.WriteLine("**********************************************************************");
        Console.WriteLine("");
        Console.Write("Ingrese una expresión matemática: ");
        string expression = Console.ReadLine();
        bool isBalanced = IsBalanced(expression);
        Console.WriteLine(isBalanced ? "La expresión está balanceada" : "La expresión está desbalanceada");
    }
}

// Realice  el uso de pilas para resolver el problema de las torres de Hanoi.
class TorreH
{
    static void Mover(Stack<int> origen, Stack<int> destino)
    {
        int disco = origen.Pop();
        destino.Push(disco);
        Console.WriteLine($"Moviendo disco {disco} de {origen.Count + 1} a {destino.Count}");
    }

    static void Hanoi(int n, Stack<int> origen, Stack<int> auxiliar, Stack<int> destino)
    {
        if (n == 1)
        {
            Mover(origen, destino);
        }
        else
        {
            Hanoi(n - 1, origen, destino, auxiliar);
            Mover(origen, destino);
            Hanoi(n - 1, auxiliar, origen, destino);
        }
    }

    static void Main()
    {
        Console.WriteLine("*******************************************************************");
        Console.WriteLine("                    UNIVERSIDAD ESTATAL AMAZONICA                   ");
        Console.WriteLine("**********************************************************************");
        Console.WriteLine("EJERCICIO 2----------");
        int n = 4; // Número de discos
        Stack<int> origen = new Stack<int>();
        Stack<int> auxiliar = new Stack<int>();
        Stack<int> destino = new Stack<int>();

        // Inicializar la torre de origen
        for(int i = n; i > 0; i--)
        {
            origen.Push(i);
        }

        Hanoi(n, origen, auxiliar, destino);
    }
}
