namespace ConsoleApp
{
    class Worker
    {
        private int id;
        private string name;
        private string surname;
        private DateTime birthDate;
        private DateTime leavingDate;
        private static int newItWorker;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public DateTime LeavingDate { get => leavingDate; set => leavingDate = value; }
    }
}
