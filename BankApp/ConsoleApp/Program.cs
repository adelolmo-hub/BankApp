using ConsoleApp;

class Program
{
    public static void Main(String[] args)
    {
        List<Worker> workers = new List<Worker>();
        List<ITWorker> itWorkerList = new List<ITWorker>();
        List<ConsoleApp.Task> taskList = new List<ConsoleApp.Task>();
        List<Team> teamList = new List<Team>();

        string menu = " 1. Register new IT worker\n 2. Register new team\n 3. Register new task (unassigned to anyone)\n 4. List all team names\n 5. List team members by team name\n 6. List unassigned tasks\n 7. List task assignments by team name\n 8. Assign IT worker to a team as manager\n 9. Assign IT worker to a team as technician\n 10.Assign task to IT worker\n 11.Unregister IT worker\n 12.Exit";
        int option;

        ITWorker i = new ITWorker(1,new List<string> { ".Net","JavaScript"},"junior","mikel","maricon",new DateTime(2003,05,01),new DateTime(2024,02,01));
        ITWorker x = new ITWorker(1, new List<string> { ".Net","SQL" }, "senior", "mikel", "maricon", new DateTime(2000, 03, 01), new DateTime(2024, 02, 01));
        itWorkerList.Add(i);
        itWorkerList.Add(x);

        Worker admin = new Worker(0, "admin", "gay", new DateTime(2000, 05, 07), new DateTime(2026, 02, 01));
        Worker pringao = new Worker(1, "noadmin", "gay", new DateTime(2000, 05, 07), new DateTime(2026, 02, 01));
        workers.Add(admin);
        workers.Add(pringao);

        ConsoleApp.Task task = new ConsoleApp.Task(1, "Crear un formulario de registro", "To do", ".Net", 2);
        taskList.Add(task);

        Team team = new Team(x, new List<Worker>());
        teamList.Add(team);

        while (true)
        {
            Console.WriteLine("Introduce un numero para elegir una opcion");
            Console.WriteLine(menu);
            option = Utils.readInt();
            switch (option) 
            {
                case 1:
                    registerNewITWorker();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
            }
        }
    }

    private static void registerNewITWorker()
    {
        int yearsOfExperience;
        List<string> techKnowledges;
        string level;
        string name;
        string surname;
        DateTime birthDate;
        DateTime leavingDate;

        Console.WriteLine("Introduce los años de experiencia");
        yearsOfExperience = Utils.readInt();
        
        techKnowledges = Utils.readTecnologies();
    }
}
