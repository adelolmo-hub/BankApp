using System.Reflection.Emit;

namespace ConsoleApp
{
    class Task
    {
        private int id;
        private string description;
        private string status;
        private string technology;
        protected int idWorker { get; private set; }

        private static readonly HashSet<string> validStatus = new HashSet<string>
        {
            "To do",
            "Doing",
            "Done"
        };

        public Task(int id, string description, string status, string technology, int idWorker)
        {
            this.id = id;
            this.description = description;
            this.Status = status;
            this.technology = technology;
            this.idWorker = idWorker;
        }

        public int Id { get => id; set => id = value; }
        public string Description { get => description; set => description = value; }
        public string Status
        {
            get => status; set
            {
                if (validStatus.Contains(value))
                {
                    status = value;
                }
                else
                {
                    throw new ArgumentException("El estado debe ser uno de los siguientes: " + string.Join(", ", validStatus));
                }
            }
        }
        public string Technology { get => technology; set => technology = value; }

        private bool assignWorkerToTask(ITWorker iTWorker)
        {
            {
                if (this.Status.Equals("Done"))
                {
                    Console.WriteLine("La tarea esta temrinada y no se puede assignar");
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
    }
}
