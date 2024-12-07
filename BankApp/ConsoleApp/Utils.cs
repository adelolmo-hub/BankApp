using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Utils
    {
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
    }
}

