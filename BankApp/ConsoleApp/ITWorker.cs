namespace ConsoleApp
{
    class ITWorker : Worker
    {
        private int yearsOfExperience;
        private List<string> techKnowledges;
        private string level;

        private static readonly HashSet<string> validStates = new HashSet<string>
        {
            "Junior",
            "Medium",
            "Senior",
            "junior",
            "medium",
            "senior"
        };

        public ITWorker(int yearsOfExperience, List<string> techKnowledges, string level,string name, string surname, DateTime birthDate, DateTime leavingDate) : base(Worker.itWorkerCount, name, surname, birthDate, leavingDate)
        {
            this.yearsOfExperience = yearsOfExperience;
            this.techKnowledges = techKnowledges;
            Level = level;
            Worker.incrementITWorkerCount();
        }

        public string Level { get => level; set
            {
                if (validStates.Contains(value))
                {
                    level = value;
                }
                else
                {
                    throw new ArgumentException("El nivel debe ser uno de los siguientes: " + string.Join(", ", validStates));
                }
            }
        }

        public List<string> TechKnowledges { get => techKnowledges; set => techKnowledges = value; }
        public int YearsOfExperience { get => yearsOfExperience; set => yearsOfExperience = value; }
    }
}
