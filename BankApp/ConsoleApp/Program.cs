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
        ITWorker h = new ITWorker(6, new List<string> { ".Net", "JavaScript","SQL" }, "senior", "mikel", "maricon", new DateTime(2003, 05, 01), new DateTime(2024, 02, 01));
        ITWorker z = new ITWorker(7, new List<string> { ".Net", "SQL", "Java" }, "medium", "mikel", "maricon", new DateTime(2000, 03, 01), new DateTime(2024, 02, 01));
        ITWorker nuevoManager = new ITWorker(7, new List<string> { ".Net", "SQL", "Java" }, "senior", "nuevo", "nuevo", new DateTime(2000, 03, 01), new DateTime(2024, 02, 01));
        Worker admin = new Worker(-1, "admin", "gay", new DateTime(2000, 05, 07), new DateTime(2026, 02, 01));
        Worker pringao = new Worker(-2, "noadmin", "gay", new DateTime(2000, 05, 07), new DateTime(2026, 02, 01));
        workers.Add(admin);
        workers.Add(pringao);
        workers.Add(x);
        workers.Add(i);
        workers.Add(h);
        workers.Add(z);
        workers.Add(nuevoManager);

        ConsoleApp.Task task = new ConsoleApp.Task("Crear un formulario de registro", "To do", ".Net", i);
        ConsoleApp.Task task3 = new ConsoleApp.Task("Hacer un moha", "To do", ".Net", h);
        ConsoleApp.Task task4 = new ConsoleApp.Task("Dormir", "Doing", ".Net", z);
        ConsoleApp.Task task2 = new ConsoleApp.Task("Testear el formulario de registro", "To do", ".Net", null);
        taskList.Add(task);
        taskList.Add(task2);
        taskList.Add(task3);
        taskList.Add(task4);

        Team team = new Team("Equipo 1", x, new List<Worker> {i});
        Team team2 = new Team("Equipo 2", h, new List<Worker> {i,h,z});
        teamList.Add(team);
        teamList.Add(team2);

        bool menuLoop = true;
        while (menuLoop)
        {
            Console.WriteLine("Introduce un numero para elegir una opcion");
            Console.WriteLine(menu);
            option = Utils.readInt();
            switch (option) 
            {
                case 1:
                    // 1. Register new IT worker
                    workers.Add(registerNewITWorker());
                    break;
                case 2:
                    // 2. Register new team
                    createTeam();
                    break;
                case 3:
                    //3. Register new task (unassigned to anyone)
                    createTask();
                    break;
                case 4:
                    // 4. List all team names
                    printTeams();
                    break;
                case 5:
                    //5. List team members by team name
                    printWorkers();
                    break;
                case 6:
                    //6. List unassigned tasks
                    for (int y = 0; y < taskList.Count; y++)
                    {
                        if (taskList[y].WorkerAssigned == null)
                        {
                            Console.WriteLine(taskList[y].ToString());
                        }
                    }
                    break;
                case 7:
                    //7. List task assignments by team name
                    for (int y = 0; y < teamList.Count; y++)
                    {
                        Console.WriteLine("Equipo: " + teamList[y].name);
                        Console.WriteLine(teamList[y].GetTasksAssigned(taskList));
                        Console.WriteLine("---------------------------------------");
                    }
                    break;
                case 8:
                    //8.Assign IT worker to a team as manager
                    Team selectedTeam;
                    Worker selectedManager;
                    Console.WriteLine("Selecciona el equipo al que quieres cambiar el manager");
                    printTeams();
                    selectedTeam = (Team)Utils.findByPosition(teamList);
                    Console.WriteLine("Elige quien va a ser el nuevo manager");
                    listAllWorkers();
                    selectedManager = (Worker)Utils.findByPosition(workers);
                    if(selectedManager is ITWorker)
                    {
                        selectedTeam.AssignTeamManager((ITWorker)selectedManager);
                    }
                    else
                    {
                        Console.WriteLine("El trabajador que has seleccionado no es un trabajador IT por lo que no puede ser Manager");
                    }
                    break;
                case 9:
                    //9.Assign IT worker to a team as technician
                    Team teamSelected;
                    Worker selectedWorker;
                    Console.WriteLine("Selecciona el equipo al que quieres añadir un trabajador");
                    printTeams();
                    teamSelected = (Team)Utils.findByPosition(teamList);
                    Console.WriteLine("Elige quien va a ser el nuevo trabajador");
                    listAllWorkers();
                    selectedWorker = (Worker)Utils.findByPosition(workers);
                    if (selectedWorker is ITWorker)
                    {
                        teamSelected.AssignNewTechnician((ITWorker)selectedWorker);
                    }
                    else
                    {
                        Console.WriteLine("El trabajador que has seleccionado no es un trabajador IT por lo que no puede ser Manager");
                    }
                    break;
                case 10:
                    //10.Assign task to IT worker
                    ConsoleApp.Task selectedTask;
                    Worker workerSelected;
                    Console.WriteLine("Selecciona la tarea que quieres assignar");
                    for (int y = 0; y < taskList.Count; y++)
                    {
                        Console.WriteLine("Tarea nº: " + (y+1));
                        Console.WriteLine(taskList[y].ToString());
                        Console.WriteLine("----------------------------");
                    }
                    selectedTask = (ConsoleApp.Task)Utils.findByPosition(taskList);
                    Console.WriteLine("Elige al trabajador asignado");
                    listAllWorkers();
                    workerSelected = (Worker)Utils.findByPosition(workers);
                    if (workerSelected is ITWorker)
                    {
                        selectedTask.AssignWorkerToTask((ITWorker)workerSelected);
                    }
                    else
                    {
                        Console.WriteLine("El trabajador que has seleccionado no es un trabajador IT por lo que no puede ser Manager");
                    }

                    break;
                case 11:
                    //11.Unregister IT worker
                    break;
                case 12:
                    //12.Exit
                    menuLoop = false;
                    break;
            }
        }
    }

    private static void printWorkers()
    {
        for (int y = 0; y < teamList.Count; y++)
        {
            teamList[y].PrintWorkerInfo();
        }
    }

    private static void printTeams()
    {
        for (int y = 0; y < teamList.Count; y++)
        {
            Console.WriteLine("Equipo: " + teamList[y].Name);
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
        taskList.Add(new ConsoleApp.Task(description, status, technology, null));
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
