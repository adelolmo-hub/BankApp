using System.Reflection.Emit;

namespace ConsoleApp
{
    class Task
    {
        private int id;
        private string description;
        private string status;
        private string technology;
        private int idWorker;

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
        public int IdWorker
        {
            get => IdWorker; set => assignWorkerToTask(value);
            
        }

        private void assignWorkerToTask(int value)
        {
            {
                if (!this.Status.Equals("Done"))
                {
                    idWorker = value;
                }
                else
                {
                    throw new ArgumentException("La tarea esta en estado DONE");
                }
            }
        }
    }
}
