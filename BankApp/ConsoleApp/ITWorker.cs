namespace ConsoleApp
{
    class ITWorker : Worker
    {
        private int yearsOfExperience;
        private List<string> techKnowledges;
        private string level; 
        public bool manager { get; set; }

        

        public ITWorker(int yearsOfExperience, List<string> techKnowledges, string level,string name, string surname, DateTime birthDate, DateTime leavingDate) : base(Worker.itWorkerCount, name, surname, birthDate, leavingDate)
        {
            this.yearsOfExperience = yearsOfExperience;
            this.techKnowledges = techKnowledges;
            Level = level;
            this.BirthDate = isAdult(birthDate) ? birthDate : throw new ArgumentException("La edad debe ser superior a 18");
            Worker.incrementITWorkerCount();
        }

        public string Level { get => level; set
            {
                if (Utils.levelisValid(value, this.yearsOfExperience))
                {
                    level = value;
                }
            }
        }

        public List<string> TechKnowledges { get => techKnowledges; set => techKnowledges = value; }
        public int YearsOfExperience { get => yearsOfExperience; set => yearsOfExperience = value; }
        private bool isAdult(DateTime birthDate)
        {
            DateTime now = DateTime.Now;
            int years = now.Year - birthDate.Year;

            if (birthDate.AddYears(years) > now)
            {
                years--;
            }
            return years >= 18;
        }

    }
}
