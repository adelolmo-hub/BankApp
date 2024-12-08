using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Utils
    {
        private static readonly HashSet<string> validStates = new HashSet<string>
        {
            "Junior",
            "Medium",
            "Senior",
            "junior",
            "medium",
            "senior"
        };
        public static int readInt()
        {
            int read = 0;
            while (true)
            {
                Console.WriteLine("Introduce un entero");
                if (int.TryParse(Console.ReadLine(), out read))
                {
                    break;
                }
                
            }
            return read;
        }
        public static DateTime readDate()
        {
            DateTime read;
            while (true)
            {
                Console.WriteLine("Introduce la fecha en el siguiente formato (DD/MM/YYYY)");
                if (DateTime.TryParse(Console.ReadLine(), out read))
                {
                    break;
                }

            }
            return read;
        }

        public static List<string> readTecnologies()
        {
            List<string> list = new List<string>();
            bool moreTecnologies = true;
            string tecnology = "";
            string customerRespone;

            Console.WriteLine("Introduce las tecnologias");
            while (moreTecnologies) 
            {
                tecnology = Console.ReadLine();
                list.Add(tecnology);
                while (true)
                {
                    Console.WriteLine("Quieres introducir mas tecnologias? (Escribre Y/N)");
                    customerRespone = Console.ReadLine();
                    if (customerRespone == "Y" || customerRespone == "y")
                    {
                        Console.WriteLine("Introduce la siguiente tecnologia");
                        break;
                    }
                    else if(customerRespone == "N" || customerRespone == "n")
                    {
                        moreTecnologies = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Introduce un valor valido (Y/N)");
                    }
                }
            }
            return list;
        }
        public static bool levelisValid(string value, int yearsOfExperience)
        {
            if (validStates.Contains(value))
            {
                if (value.Equals("Senior") || value.Equals("senior") && yearsOfExperience < 5)
                {
                    Console.WriteLine("Debes tener al menos 5 años para poder ser senior");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                Console.WriteLine("El nivel debe ser uno de los siguientes: " + string.Join(", ", validStates));
                return false;
            }
        }
    }
}

