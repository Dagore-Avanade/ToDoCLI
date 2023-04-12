using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoCLI
{
    class Menu
    {
        static bool watch = true;
        static string[] arguments = { };
        static readonly ToDoRepository repository = new ToDoRepository();
        public static void MainLoop()
        {
            Console.WriteLine("TODO");
            while (watch)
            {
                Console.WriteLine();
                Console.WriteLine(repository.GetAll());
                PrintOptions();
                string input = Console.ReadLine();
                if (input.Length != 0)
                {
                    arguments = input.Split(separator: new char[] { ' ' }, options: StringSplitOptions.RemoveEmptyEntries);
                    string command = arguments[0];
                    switch (command)
                    {
                        case "ADD":
                        case "add":
                            Add();
                            break;
                        case "DEL":
                        case "del":
                            DeleteById();
                            break;
                        case "CH":
                        case "ch":
                            ChangeStateById();
                            break;
                        default:
                            watch = !ConfirmExit();
                            break;
                    }
                }
                else
                {
                    watch = !ConfirmExit();
                }
            }
        }
        static void PrintOptions()
        {
            Console.WriteLine();
            TabWriteLine("\"ADD Descripión\" para agregar una nueva tarea.");
            TabWriteLine("\"DEL Id\" para eliminar una tarea.");
            TabWriteLine("\"CH Id\" para cambiar el estado de una tarea.");
            TabWriteLine("Puede abandonar el programa con cualquier tecla + ENTER.");
            Console.WriteLine();
            Console.Write("Escribe aquí el comando a ejecutar: ");
        }
        static void ChangeStateById()
        {
            if (arguments.Length > 1 && int.TryParse(arguments[1], out int id))
            {
                if (!repository.ToggleById(id))
                {
                    Console.WriteLine("No encuentro el Id especificado.");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No entiendo el comando que ha ingresado.");
            }
        }
        static void Add()
        {
            if (arguments.Length > 1)
            {
                string description = CollectDescription();
                repository.Add(description);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No entiendo el comando que ha ingresado.");
            }
        }
        static void DeleteById()
        {
            if (arguments.Length > 1 && int.TryParse(arguments[1], out int id))
            {
                if (!repository.DeleteById(id))
                {
                    Console.WriteLine("No encuentro el Id especificado.");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No entiendo el comando que ha ingresado.");
            }
        }
        static bool ConfirmExit()
        {
            Console.WriteLine();
            Console.WriteLine("¿Está seguro de querer salir?");
            Console.Write("Pulse cualquier tecla para dejar la aplicación o \"N\" para permanecer en ella: ");
            string input = Console.ReadLine();

            if (input == "N")
                return false;
            else
                return true;

        }
        static string CollectDescription()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 1; i < arguments.Length; i++)
            {
                stringBuilder.Append(arguments[i]).Append(' ');
            }
            return stringBuilder.ToString();
        }
        static void TabWriteLine(string s)
        {
            Console.WriteLine($"    {s}");
        }
    }
}
