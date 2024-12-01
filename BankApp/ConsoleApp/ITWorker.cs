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
            "Senior"
        };

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
