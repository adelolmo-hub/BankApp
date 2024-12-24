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
            assignTeamManager(manager);
            Technicians = technicians;
        }

        public bool assignTeamManager(ITWorker iTWorker)
        {
            if (iTWorker.Level != "Senior" && iTWorker.Level != "senior")
            {
                Console.WriteLine("El trabajador debe ser senior para poder ser manager");
                return false;
            }
            this.Manager = iTWorker;
            return true;
        }

        public void PrintWorkerInfo()
        {
            Console.WriteLine("Equipo: " + this.Name);
            Console.WriteLine("El manager es: ");
            Console.WriteLine(Manager.printWorkerInfo());
            for (int i = 0; i < Technicians.Count; i++)
            {
                Console.WriteLine("Worker nº " + i);
                Console.WriteLine(Technicians[i].printWorkerInfo());
            }
        }

    }
}
