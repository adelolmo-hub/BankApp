using System.Timers;
using ConsoleApp;

class Program
{
    static List<Worker> workers = new List<Worker>();
    static List<ConsoleApp.Task> taskList = new List<ConsoleApp.Task>();
    static List<Team> teamList = new List<Team>();
    public static void Main(String[] args)
    {
        workers = new List<Worker>();
        taskList = new List<ConsoleApp.Task>();
        teamList = new List<Team>();

        string menu = " 1. Register new IT worker\n 2. Register new team\n 3. Register new task (unassigned to anyone)\n 4. List all team names\n 5. List team members by team name\n 6. List unassigned tasks\n 7. List task assignments by team name\n 8. Assign IT worker to a team as manager\n 9. Assign IT worker to a team as technician\n 10.Assign task to IT worker\n 11.Unregister IT worker\n 12.Exit";
        int option;

        ITWorker i = new ITWorker(1,new List<string> { ".Net","JavaScript"},"junior","mikel","maricon",new DateTime(2003,05,01),new DateTime(2024,02,01));
        ITWorker x = new ITWorker(5, new List<string> { ".Net","SQL" }, "senior", "mikel", "maricon", new DateTime(2000, 03, 01), new DateTime(2024, 02, 01));
        Worker admin = new Worker(-1, "admin", "gay", new DateTime(2000, 05, 07), new DateTime(2026, 02, 01));
        Worker pringao = new Worker(-2, "noadmin", "gay", new DateTime(2000, 05, 07), new DateTime(2026, 02, 01));
        workers.Add(admin);
        workers.Add(pringao);
        workers.Add(x);
        workers.Add(i);

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
                    workers.Add(registerNewITWorker());
                    break;
                case 2:
                    bool moreWorkers = true;
                    int idWorker;
                    string customerInput;
                    Worker workerFound;
                    ITWorker manager = null;
                    List<Worker> workerList = new List<Worker>();
                    listAllWorkers();

                    Console.WriteLine("Selecciona los integrantes del nuevo equipo (Introduce el id)");
                    while (moreWorkers)
                    {
                        idWorker = Utils.readInt();
                        workerFound = workers.Find(it => it.Id == idWorker);
                        if(workerFound != null)
                        {
                            workerList.Add(workerFound);
                        }
                        else
                        {
                            Console.WriteLine("El trabajador no existe");
                        }
                       
                        while (true)
                        {
                            Console.WriteLine("Quieres añadir mas integrantes? (introduce Y/N)");
                            customerInput = Console.ReadLine();
                            if (customerInput == "N" || customerInput == "n")
                            {
                                moreWorkers = false;
                                break;
                            }
                            else if(customerInput == "Y" || customerInput == "y")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Introduce un valor valido");
                            }
                        }
                    }
                    moreWorkers = true;
                    listAllWorkers();
                    while (moreWorkers)
                    {
                        Console.WriteLine("Introduce el id del manager del equipo");
                        idWorker = Utils.readInt();
                        workerFound = workers.Find(it => it.Id == idWorker);
                        if (workerFound != null && workerFound is ITWorker)
                        {
                            manager = workerFound as ITWorker;
                            moreWorkers = false;
                        }
                        else
                        {
                            Console.WriteLine("El trabajador no existe o no es un ITWorker");
                        }
                    }
                    Team newTeam = new Team(manager, workerList);
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

    private static void listAllWorkers()
    {
        for (int i = 0; i < workers.Count(); i++) 
        {
            Console.WriteLine(workers[i].printWorkerInfo()); 
        }
    }

    private static ITWorker registerNewITWorker()
    {
        bool levelisinvalid = true;
        int yearsOfExperience;
        List<string> techKnowledges;
        string level = "";
        string name;
        string surname;
        DateTime birthDate;
        DateTime leavingDate;
        ITWorker worker;

        Console.WriteLine("Introduce los años de experiencia");
        yearsOfExperience = Utils.readInt();
        
        techKnowledges = Utils.readTecnologies();

        while (levelisinvalid) {
            Console.WriteLine("Introduce el nivel del trabajador");
            level = Console.ReadLine();
            levelisinvalid = !Utils.levelisValid(level,yearsOfExperience);
        }
        Console.WriteLine("Introduce el nombre del trabajador");
        name = Console.ReadLine();

        Console.WriteLine("Introduce el apellido del trabajador");
        surname = Console.ReadLine();

        Console.WriteLine("Introduce la fecha de nacimiento");
        birthDate = Utils.readDate();

        Console.WriteLine("Introduce la fecha de salida del trabajador");
        leavingDate = Utils.readDate();

        worker = new ITWorker(yearsOfExperience,techKnowledges,level,name,surname,birthDate, leavingDate);
        return worker;

    }
}
