//Escribir un programa que almacene las asignaturas de un curso (por ejemplo Matemáticas, Física, Química, Historia y Lengua) 
//en una lista y la muestre por pantalla el mensaje Yo estudio <asignatura>, donde <asignatura> es cada una de las asignaturas de la lista.
Console.WriteLine("*******************************************************************");
Console.WriteLine("                    UNIVERSIDAD ESTATAL AMAZONICA                   ");
Console.WriteLine("**********************************************************************");
Console.WriteLine("");
Console.WriteLine("-----------------------EJERCICIO 1-------------------------");
 // Lista de asignaturas
            List<string> asignaturas= ["Matemáticas","Física","Química","Historia","Lengua"];

            // Mostrar las asignaturas
            Console.WriteLine("Asignaturas del curso:");
            foreach (string asignatura in asignaturas)
            {
                Console.WriteLine(asignatura);
            } 
//Escribir un programa que almacene las asignaturas de un curso (por ejemplo Matemáticas, Física, Química, Historia y Lengua) 
//en una lista y la muestre por pantalla el mensaje Yo estudio <asignatura>, donde <asignatura> es cada una de las asignaturas de la lista.
Console.WriteLine("");
Console.WriteLine("-----------------------EJERCICIO 2-------------------------");
List<string> materias = 
            ["Matemáticas",
                "Física",
                "Química",
                "Historia",
                "Lengua"];

            // Mostrar el mensaje para cada asignatura.
            foreach (string materia in materias)
            {
                Console.WriteLine($"Yo  Evelyn Arce estudio {materia}");
            }

//Escribir un programa que almacene en una lista los siguientes precios, 50, 75, 46, 22, 80, 65, 8, y muestre por pantalla el menor y el mayor de los precios.
Console.WriteLine("");
Console.WriteLine("-----------------------EJERCICIO 3-------------------------");
            // Lista de precios
            List<int> precios = [50, 75, 46, 22, 80, 65, 8];

            // Encontrar el precio mínimo y máximo usando LINQ
            int precioMinimo = precios.Min();
            int precioMaximo = precios.Max();

            // Mostrar los resultados
            Console.WriteLine($"El precio mínimo es: {precioMinimo}");
            Console.WriteLine($"El precio máximo es: {precioMaximo}");
//Escribir un programa que pida al usuario una palabra y muestre por pantalla el número de veces que contiene cada vocal.     
Console.WriteLine("");
Console.WriteLine("-----------------------EJERCICIO 4-------------------------");
            Console.Write("Ingrese una palabra: ");
            string palabra = Console.ReadLine().ToLower();

            // Lista para almacenar las vocales y sus frecuencias
            List<char> vocales = ['a', 'e', 'i', 'o', 'u'];
            List<int> frecuencias = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0];

            // Contar las vocales
            foreach (char letra in palabra)
            {
                int indice = vocales.IndexOf(letra);
                if (indice != -1)
                {
                    frecuencias[indice]++;
                }
            }

            // Mostrar el resultado
            Console.WriteLine("La frecuencia de cada vocal es:");
            for (int i = 0; i < vocales.Count; i++)
            {
                Console.WriteLine($"{vocales[i]}: {frecuencias[i]}");
            }
//Escribir un programa que almacene el abecedario en una lista, elimine de la lista las letras que ocupen posiciones múltiplos de 3, y muestre por pantalla la lista resultante.
Console.WriteLine("");
Console.WriteLine("-----------------------EJERCICIO 5-------------------------");
          // Crear una lista con el abecedario
            List<char> abecedario = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            // Eliminar las letras en posiciones múltiplos de 3
            abecedario.RemoveAll(letra => (abecedario.IndexOf(letra) + 1) % 3 == 0);

            // Mostrar la lista resultante
            Console.WriteLine("El abecedario sin las letras en posiciones múltiplos de 3 es:");
            Console.WriteLine(string.Join(", ", abecedario));
