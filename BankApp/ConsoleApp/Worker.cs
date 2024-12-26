namespace ConsoleApp
{
    class Worker
    {
        private int id;
        private string name;
        private string surname;
        private DateTime birthDate;
        private DateTime leavingDate;
        public static int itWorkerCount { get; private set; } = 1;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public DateTime LeavingDate { get => leavingDate; set => leavingDate = value; }

        public Worker(int id, string name, string surname, DateTime birthDate, DateTime leavingDate)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.birthDate = birthDate;
            this.leavingDate = leavingDate;
        }

        protected static void incrementITWorkerCount()
        {
            itWorkerCount++;
        }

        public string printWorkerInfo()
        {
            return $"Empleado:\n" +
                   $"ID: {id}\n" +
                   $"Nombre: {name}\n" +
                   $"Apellido: {surname}\n" +
                   $"Fecha de Nacimiento: {birthDate:dd/MM/yyyy}\n" +
                   $"Fecha de Salida: {leavingDate:dd/MM/yyyy}\n";
        }

        

    }
}
