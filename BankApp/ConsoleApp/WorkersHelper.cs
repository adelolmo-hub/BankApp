using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class WorkersHelper
    {
        public static ITWorker SelectWorker(List<Worker> workers)
        {
            while (true)
            {
                int idWorker = Utils.readInt();
                Worker workerFound = FindWorkerById(workers, idWorker);

                if (workerFound is ITWorker itWorker)
                {
                    Console.WriteLine($"Manager seleccionado: {itWorker.Name}");
                    return itWorker;
                }
                else
                {
                    Console.WriteLine("El trabajador no existe o no es un ITWorker.");
                }
            }
        }

        public static Worker FindWorkerById(List<Worker> listWorker, int idWorker)
        {
            return listWorker.Find(it => it.Id == idWorker);
        }

    }
}
