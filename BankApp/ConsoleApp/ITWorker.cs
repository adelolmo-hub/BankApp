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
                    if(value.Equals("Senior") && value.Equals("senior") && yearsOfExperience < 5)
                    {
                        Console.WriteLine("Debes tener al menos 5 años para poder ser senior");
                    }
                    else
                    {
                        level = value;
                    }
                }
                else
                {
                    Console.WriteLine("El nivel debe ser uno de los siguientes: " + string.Join(", ", validStates));
                }
            }
        }

        public List<string> TechKnowledges { get => techKnowledges; set => techKnowledges = value; }
        public int YearsOfExperience { get => yearsOfExperience; set => yearsOfExperience = value; }
    }
}
