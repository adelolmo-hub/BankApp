namespace ConsoleApp
{
    class Team
    {
        private ITWorker manager;
        protected List<Worker> Technicians { get; private set; }
        protected ITWorker Manager { get => manager; set => assignTeamManager(value); }

        public Team(ITWorker manager, List<Worker> technicians)
        {
            assignTeamManager(manager);
            Technicians = technicians;
        }

        public bool assignTeamManager(ITWorker iTWorker)
        {
            if (iTWorker.Level != "Senior" || iTWorker.Level != "Senior")
            {
                Console.WriteLine("El trabajador debe ser senior para poder ser manager");
                return false;
            }
            this.Manager = iTWorker;
            return true;
        }

    }
}
