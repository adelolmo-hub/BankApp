namespace ConsoleApp
{
    class Team
    {
        protected ITWorker Manager { get; private set; }
        protected string Technicians { get; private set; }


        public bool assignTeamManager(ITWorker iTWorker)
        {
            if (iTWorker.Level != "Senior")
            {
                Console.WriteLine("El trabajador debe ser senior para poder ser manager");
                return false;
            }
            this.Manager = iTWorker;
            return true;
        }

    }
}
