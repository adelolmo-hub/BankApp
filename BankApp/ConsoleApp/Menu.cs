using System.Runtime.CompilerServices;

namespace ConsoleApp
{
    class Menu
    {
        public static bool menuLoop = true;
        private Dictionary<string, List<string>> MenuPorUsuario = new Dictionary<string, List<string>>
        {
            {"Admin", new List<string>{ "1. Register new IT worker", "2. Register new team", "3. Register new task (unassigned to anyone)", "4. List all team names", "5. List team members by team name", "6. List unassigned tasks", "7.List task assignments by team name", "8. Assign IT worker to a team as manager", "9. Assign IT worker to a team as technician", "10.Assign task to IT worker", "11.Unregister IT worker", "12.Exit" } },
            {"Manager", new List<string>{ "1. List team members in my team", "2. List unassigned tasks", "3.List task assignments in my team", "4. Assign IT worker to a team as technician", "5.Assign task to IT worker", "6.Exit" } },
            {"ITWorker", new List<string>{ "1. List unassigned tasks", "2.List task assignments in my team", "3.Assign task to me", "4.Exit" } }
        };
        private Dictionary<string, Dictionary<int,Action>> AccionesPorUsuario = new Dictionary<string, Dictionary<int, Action>>
        {
            {
                "Admin", new Dictionary<int, Action>
                {
                    { 1 ,() => registerNewITWorker() },
                    { 2 ,() => Uno() },
                    { 3 ,() => Uno() },
                    { 4 ,() => Uno() },
                    { 5 ,() => Uno() },
                    { 6 ,() => Uno() },
                    { 7 ,() => Uno() },
                    { 8 ,() => Uno() },
                    { 9 ,() => Uno() },
                    { 10 ,() => Uno() },
                    { 11 ,() => Uno() },
                    { 12 ,() => Exit() }
                }
            },
            {
                "Manager", new Dictionary<int, Action>
                {
                        { 1 ,() => Uno() },
                        { 2 ,() => Uno() },
                        { 3 ,() => Uno() },
                        { 4 ,() => Uno() },
                        { 5 ,() => Uno() },
                        { 6 ,() => Exit() }
                }
            },
            {
                "ITWorker", new Dictionary<int, Action>
                {
                        { 1 ,() => Uno() },
                        { 2 ,() => Uno() },
                        { 3 ,() => Uno() },
                        { 4 ,() => Exit() }
                }
            }
        };

        public string PrintMenu(string userType)
        {
            string menu = "";
            var colorcito = AccionesPorUsuario;
            foreach (var item in MenuPorUsuario[userType]) {
                menu += item.ToString() + "\n";
            }
            return menu;
        }
        public static void Uno()
        {

        }
        public static void Exit()
        {
            menuLoop = false;
        }

        public void ActionSelected(string userType, int option)
        {
            if(AccionesPorUsuario.ContainsKey(userType) && AccionesPorUsuario[userType].ContainsKey(option))
            {
                AccionesPorUsuario[userType][option]();
            }
            else
            {
                Console.WriteLine("Opcion no valida");
            }
        }

        public static void registerNewITWorker()
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

            while (levelisinvalid)
            {
                Console.WriteLine("Introduce el nivel del trabajador");
                level = Console.ReadLine();
                levelisinvalid = !Utils.levelisValid(level, yearsOfExperience);
            }
            Console.WriteLine("Introduce el nombre del trabajador");
            name = Console.ReadLine();

            Console.WriteLine("Introduce el apellido del trabajador");
            surname = Console.ReadLine();

            Console.WriteLine("Introduce la fecha de nacimiento");
            birthDate = Utils.readDate();

            Console.WriteLine("Introduce la fecha de salida del trabajador");
            leavingDate = Utils.readDate();

            worker = new ITWorker(yearsOfExperience, techKnowledges, level, name, surname, birthDate, leavingDate);
            Program.workers.Add(worker);

        }
    }
}
