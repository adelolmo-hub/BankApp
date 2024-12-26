using System.Xml.Linq;

namespace ConsoleApp
{
    class Team
    {
        public string name;
        private ITWorker manager;
        protected List<Worker> Technicians { get; private set; }
        internal ITWorker Manager { get => manager; private set => manager = value; }
        public string Name { get => name; private set => name = value; }

        public Team(string name, ITWorker manager, List<Worker> technicians)
        {
            AssignTeamManager(manager);
            Technicians = technicians;
            this.name = name;
        }

        public bool AssignTeamManager(ITWorker iTWorker)
        {

            if (iTWorker.Level != "Senior" && iTWorker.Level != "senior")
            {
                Console.WriteLine("El trabajador debe ser senior para poder ser manager");
                return false;
            }
            this.Manager = iTWorker;
            return true;
        }

        public bool AssignNewTechnician(ITWorker itWorker)
        {
            if (Technicians.Contains(itWorker))
            {
                Console.WriteLine("Este trabajador ya esta asignado al equipo");
                return false;
            }
            else
            {
                Technicians.Add(itWorker);
            }
            return true;
        }

        public void PrintWorkerInfo()
        {
            Console.WriteLine("Equipo: " + this.Name);
            Console.WriteLine("El manager es: ");
            Console.WriteLine(Manager?.printWorkerInfo() ?? "Este equipo no tiene manager, recuerda asignar uno antes de que transcurra el tiempo limite");
            for (int i = 0; i < Technicians.Count; i++)
            {
                Console.WriteLine("Worker nº " + i);
                Console.WriteLine(Technicians[i].printWorkerInfo());
            }
        }

        public string GetTasksAssigned(List<Task> tasks)
        {
            string taskByTeam = "";
            for (int i = 0; i < Technicians.Count; i++) 
            {
                for(int y = 0; y < tasks.Count; y++)
                {
                    if (Technicians[i].Equals(tasks[y].WorkerAssigned))
                    {
                        taskByTeam += tasks[y].ToString();
                        taskByTeam += ".............................\n";
                    }
                }
            }
            return taskByTeam;
        }

        public void RemoveWorker(Worker worker)
        {
            if (this.Manager.Equals(worker)) {
                Console.WriteLine("Este equipo se ha quedado sin manager, deber seleccionar uno nuevo en los proximos 3 dias");
                this.Manager = null;
            }
            this.Technicians.Remove(worker);
        }

    }
}
