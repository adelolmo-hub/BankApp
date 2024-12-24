using System.Reflection.Emit;

namespace ConsoleApp
{
    class Task
    {
        protected int id { get; private set; }
        public string description;
        public string status;
        public string technology;
        public int? idWorker { get; private set; }
        private static int IdCount = 0;

        private static readonly HashSet<string> validStatus = new HashSet<string>
        {
            "To do",
            "Doing",
            "Done"
        };

        public Task(string description, string status, string technology, int? idWorker)
        {
            incrementID();
            this.id = IdCount;
            this.description = description;
            this.Status = status;
            this.technology = technology;
            this.idWorker = idWorker;
        }

        public string Description { get => description; set => description = value; }
        public string Status
        {
            get => status; set
            {
                if (checkStatus(value))
                {
                    status = value;
                }
            }
        }
        public string Technology { get => technology; set => technology = value; }

        private bool assignWorkerToTask(ITWorker iTWorker)
        {
            {
                if (this.Status.Equals("Done"))
                {
                    Console.WriteLine("La tarea esta terminada y no se puede assignar");
                    return false; 
                }
                if(!iTWorker.TechKnowledges.Contains(technology))
                {
                    Console.WriteLine("El trabajador no conoce la tecnologia necesaria");
                    return false;
                }
                idWorker = iTWorker.Id;
                return true;
            }
        }

        private void incrementID()
        {
            IdCount++;
        }

        public static bool checkStatus(string status)
        {
            if (validStatus.Contains(status))
            {
                return true;
            }
            else
            {
                Console.WriteLine("El estado debe ser uno de los siguientes: " + string.Join(", ", validStatus));
                return false;
            }
        }

        public string ToString()
        {
            return $"Detalles de la tarea:\n" +
               $"ID: {id}\n" +
               $"Descripción: {description}\n" +
               $"Estado: {status}\n" +
               $"Tecnología: {technology}\n" +
               $"ID del Trabajador: {idWorker}\n";
        }
    }
}
