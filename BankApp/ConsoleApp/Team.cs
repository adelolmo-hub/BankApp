namespace ConsoleApp
{
    class Team
    {
        private ITWorker manager;
        protected List<Worker> Technicians { get; private set; }
        internal ITWorker Manager { get => manager; private set => manager = value; }

        public Team(ITWorker manager, List<Worker> technicians)
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

    }
}
