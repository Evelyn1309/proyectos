using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Lista de nombres ficticios
        string[] nombres = { "Juan", "María", "Carlos", "Ana", "Luis", "Elena", "Pedro", "Sofía", "José", "Laura", "Miguel", "Carmen", "Javier", "Isabel", "Andrés", "Patricia", "Fernando", "Lucía", "Raúl", "Gabriela", "Manuel", "Silvia", "Ricardo", "Beatriz", "Daniel", "Marta", "Alberto", "Teresa", "Francisco", "Rosa", "Roberto", "Cristina", "Eduardo", "Verónica", "Hugo", "Natalia", "Diego", "Paula", "Álvaro", "Clara", "Sergio", "Eva", "Adrián", "Alicia", "Pablo", "Irene", "Jorge", "Esther", "Raquel", "David" };

        // Conjunto de los ciudadanos 
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int a = 1; a <= 500; a++)
        {
            ciudadanos.Add($"{nombres[a % nombres.Length]}_{a}");
        }

        // Conjunto de personas vacunadas con Pfizer
        HashSet<string> vacunadosPfizer = new HashSet<string>();
        for (int b = 1; b <= 75; b++)
        {
            vacunadosPfizer.Add($"{nombres[b % nombres.Length]}_{b}");
        }

        // Conjunto de vacunados con AstraZeneca
        HashSet<string> vacunadosAstrazeneca = new HashSet<string>();
        for (int c = 76; c <= 150; c++)
        {
            vacunadosAstrazeneca.Add($"{nombres[c % nombres.Length]}_{c}");
        }

        // Conjunto de ciudadanos que recibieron ambas vacunas (intersección)
        HashSet<string> vacunadosAmbas = new HashSet<string>(vacunadosPfizer);
        vacunadosAmbas.IntersectWith(vacunadosAstrazeneca);

        // Conjunto de ciudadanos que solo han recibido Pfizer
        HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstrazeneca);

        // Conjunto de ciudadanos que solo han recibido AstraZeneca
        HashSet<string> soloAstrazeneca = new HashSet<string>(vacunadosAstrazeneca);
        soloAstrazeneca.ExceptWith(vacunadosPfizer);

        // Conjunto de ciudadanos no vacunados
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunadosPfizer);
        noVacunados.ExceptWith(vacunadosAstrazeneca);

        void MostrarLista(HashSet<string> lista)
        {
            int count = 0;
            foreach (var persona in lista)
            {
                Console.WriteLine(persona);
                count++;
                if (count % 10 == 0)
                {
                    Console.WriteLine("Presione ENTER para continuar...");
                    Console.ReadLine();
                }
            }
        }

        int opcion;
        do
        {
            Console.WriteLine("\nMenú de opciones:");
            Console.WriteLine("1. Mostrar ciudadanos que no se han vacunado");
            Console.WriteLine("2. Mostrar ciudadanos que han recibido ambas vacunas");
            Console.WriteLine("3. Mostrar ciudadanos que solo han recibido la vacuna de Pfizer");
            Console.WriteLine("4. Mostrar ciudadanos que solo han recibido la vacuna de AstraZeneca");
            Console.WriteLine("5. Mostrar todos los ciudadanos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ciudadanos que no se han vacunado: " + noVacunados.Count);
                    MostrarLista(noVacunados);
                    break;
                case 2:
                    Console.WriteLine("Ciudadanos que han recibido ambas vacunas: " + vacunadosAmbas.Count);
                    MostrarLista(vacunadosAmbas);
                    break;
                case 3:
                    Console.WriteLine("Ciudadanos que solo se han vacunado de Pfizer: " + soloPfizer.Count);
                    MostrarLista(soloPfizer);
                    break;
                case 4:
                    Console.WriteLine("Ciudadanos que solo se han vacunado de AstraZeneca: " + soloAstrazeneca.Count);
                    MostrarLista(soloAstrazeneca);
                    break;
                case 5:
                    Console.WriteLine("Todos los ciudadanos: " + ciudadanos.Count);
                    MostrarLista(ciudadanos);
                    break;
                case 6:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida, intente nuevamente.");
                    break;
            }
        } while (opcion != 6);
    }
}
