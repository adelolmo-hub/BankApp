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

        ConsoleApp.Task task = new ConsoleApp.Task("Crear un formulario de registro", "To do", ".Net", 2);
        taskList.Add(task);

        Team team = new Team("Equipo 1", x, new List<Worker>());
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
                    createTeam();
                    break;
                case 3:
                    createTask();
                    break;
                case 4:
                    for (int y = 0; y < teamList.Count; y++)
                    {
                        Console.WriteLine("Equipo: " + teamList[y].Name);
                    }
                    break;
                case 5:
                    for (int y = 0; y < teamList.Count; y++)
                    {
                        teamList[y].PrintWorkerInfo();
                    }
                    break;
                case 6:
                    for (int y = 0; y < taskList.Count; y++)
                    {
                        Console.WriteLine(taskList[y].ToString());
                    }
                    break;
                case 7:
                    break;
            }
        }
    }

    static void createTeam()
    {
        bool moreWorkers = true;
        int idWorker;
        string name;
        ITWorker manager = null;
        List<Worker> workerList = new List<Worker>();
        listAllWorkers();

        Console.WriteLine("Escribe el nombre del nuevo equipo");
        name = Console.ReadLine();

        Console.WriteLine("Selecciona los integrantes del nuevo equipo (Introduce el id)");
        while (moreWorkers)
        {
            workerList.Add(WorkersHelper.SelectWorker(workers));
            Console.WriteLine("Quieres añadir mas integrantes? (introduce Y/N)");
            moreWorkers = Utils.CustomerConfirmAction();
            
        }
        moreWorkers = true;
        listAllWorkers();
        //TODO - ARREGLAR MANAGER FALLA SI NO ES SENIOR
        Console.WriteLine("Introduce el id del manager del equipo");
        while (moreWorkers)
        {
            manager = WorkersHelper.SelectWorker(workers);
            if(manager != null && manager is ITWorker)
            {
                moreWorkers = false;
            }
            else
            {
                Console.WriteLine("El trabajador debe ser un ITWorker");
            }
        }
        Team newTeam = new Team(name, manager, workerList);
    }

    static void createTask()
    {
        string description = "";
        string status = "";
        string technology = "";
        bool statusOK = false;

        Console.WriteLine("Introduce la descripcion de la tarea");
        description = Console.ReadLine();
        while (!statusOK)
        {
            Console.WriteLine("Introduce el estado de la tarea (To do, Doing, Done)");
            status = Console.ReadLine();
            statusOK = ConsoleApp.Task.checkStatus(status);
        }
        Console.WriteLine("Introduce la tecnologia de la tarea");
        technology = Console.ReadLine();
        taskList.Add(new ConsoleApp.Task(description, status, technology, 0));
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
