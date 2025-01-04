using System;
//                       ESTRUCTURA DE PACIENTE        ///
struct Paciente
{
    public string Nombre;
    public string Apellido;
    public string Cedula;
    public DateTime FechaNacimiento ;
}
//                       ESTRUCTURA DE TURNO          ///
struct Turno
{
    public DateTime Fecha;

    public TimeSpan Hora;
    public string Motivo;
    public Paciente Paciente;


}

class Agenda
{
    static List<Turno> agenda = new List<Turno>();//         LISTA DONDE SE VA ALMACENAR LOS TURNOS           ///
//                       MENU DE OPCIONES                 ///
    static void Main(string[] args)
    {
        while (true)
        {   
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("                    UNIVERSIDAD ESTATAL AMAZONICA                   ");
            Console.WriteLine("**********************************************************************");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("                    \nMENU DE AGENDA MEDICA"                          );
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("1. Agregar nuevo turno");
            Console.WriteLine("2. Buscar turno por nombre");
            Console.WriteLine("3. Mostrar todos los turnos");
            Console.WriteLine("4. Salir");
            Console.Write("Ingrese una opción: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarTurno();
                    break;
                case 2:
                    BuscarTurnoPorNombre();
                    break;
                case 3:
                    MostrarTodosLosTurnos();
                    break;
                case 4:
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static void AgregarTurno()//Agrega el turno del paciente al sistema
    {
        Paciente paciente = new Paciente();
        Turno turno = new Turno();
        //                       INGRESA LA CEDULA                  ///
        Console.Write("Ingrese la cédula del paciente: ");
        paciente.Cedula = Console.ReadLine();
        

        // Verificar si la cédula ya existe
        if (agenda.Any(t => t.Paciente.Cedula == paciente.Cedula))
        {
            Console.WriteLine("Ya existe un paciente con esa cédula.");
            return;
        }

        //                       INGRESA EL NOMBRE Y APELLIDO                  ///
        Console.Write("Ingrese el nombre del paciente: ");
        paciente.Nombre = Console.ReadLine();
        Console.Write("Ingrese el apellido del paciente: ");
        paciente.Apellido = Console.ReadLine();

        //                       INGRESA LA FECHA DE NACIMIENTO                    ///
       Console.Write("Ingrese la fecha de nacimiento: ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime fechaNacimiento))
        {
            paciente.FechaNacimiento = fechaNacimiento;
        }
        else
        {
            Console.WriteLine("Fecha inválida. Por favor, ingrese la fecha en formato AAAA-MM-DD.");
            return;
        }
        //                       INGRESA LA FECHA DEL TURNO                     ///

        Console.Write("Ingrese la fecha del turno (AAAA-MM-DD): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
        {
            turno.Fecha = fecha;
        }
        else
        {
            Console.WriteLine("Fecha inválida. Por favor, ingrese la fecha en formato AAAA-MM-DD.");
            return;
        }
        //                             INGRESA LA HORA DEL TURNO                    //
        Console.Write("Ingrese la hora del turno (HH:mm): ");
        if (TimeSpan.TryParse(Console.ReadLine(), out TimeSpan hora))
        {
            turno.Hora = hora;
        }
        else
        {
            Console.WriteLine("Hora inválida. Por favor, ingrese la hora en formato HH:mm.");
            return;
        }



        turno.Paciente = paciente;
        agenda.Add(turno);
        Console.WriteLine("Turno agregado correctamente.");
    }

    static void BuscarTurnoPorNombre()
    {
        Console.Write("Ingrese el nombre del paciente a buscar: ");//busca el turno por el nombre
        string nombreBuscado = Console.ReadLine();

        bool encontrado = false;
        foreach (var turno in agenda)
        {
            if (turno.Paciente.Nombre.Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Turno encontrado:");
                Console.WriteLine($"Fecha: {turno.Fecha}");
                Console.WriteLine($"Hora: {turno.Hora}");
                Console.WriteLine($"Motivo: {turno.Motivo}");
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontró ningún turno para ese nombre.");
        }
    }

    static void MostrarTodosLosTurnos()//Muesta todos los turnos del sitema
    {
        if (agenda.Count == 0)
        {
            Console.WriteLine("La agenda está vacía.");
        }
        else
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("                    LISTA DE TURNOS AGENDADOS                     ");
            Console.WriteLine("------------------------------------------------------------------");
            foreach (var turno in agenda)
            {
                Console.WriteLine($"Cedula: {turno.Paciente.Cedula}");
                Console.WriteLine($"Fecha de nacimiento: {turno.Paciente.FechaNacimiento}");
                Console.WriteLine($"Paciente: {turno.Paciente.Nombre} {turno.Paciente.Apellido}");
                Console.WriteLine($"Fecha: {turno.Fecha}");
                Console.WriteLine($"Hora: {turno.Hora}");
                Console.WriteLine($"Motivo: {turno.Motivo}");
                Console.WriteLine("--------------------");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("                 Programado por @Evelyn Arce                      ");
            }
        }
    }
}