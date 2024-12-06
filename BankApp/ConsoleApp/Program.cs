using ConsoleApp;

class Program
{
    public static void Main(String[] args)
    {
        string menu = " 1. Register new IT worker\r\n 2. Register new team\r\n 3. Register new task (unassigned to anyone)\r\n 4. List all team names\r\n 5. List team members by team name\r\n 6. List unassigned tasks\r\n 7. List task assignments by team name\r\n 8. Assign IT worker to a team as manager\r\n 9. Assign IT worker to a team as technician\r\n 10.Assign task to IT worker\r\n 11.Unregister IT worker\r\n 12.Exit";
        //ITWorker i = new ITWorker(1,new List<string>(),"junior","mikel","maricon",new DateTime(2024,03,01),new DateTime(2024,02,01));
        //ITWorker x = new ITWorker(1, new List<string>(), "senior", "mikel", "maricon", new DateTime(2024, 03, 01), new DateTime(2024, 02, 01));
        //ITWorker j = new ITWorker(1, new List<string>(), "junior", "mikel", "maricon", new DateTime(2024, 03, 01), new DateTime(2024, 02, 01));
        //ITWorker k = new ITWorker(1, new List<string>(), "medium", "mikel", "maricon", new DateTime(2024, 03, 01), new DateTime(2024, 02, 01));
        //ITWorker l = new ITWorker(1, new List<string>(), "medium", "mikel", "maricon", new DateTime(2024, 03, 01), new DateTime(2024, 02, 01));
        //ITWorker m = new ITWorker(1, new List<string>(), "senior", "mikel", "maricon", new DateTime(2006, 12, 06), new DateTime(2024, 02, 01));
        //ITWorker n = new ITWorker(1, new List<string>(), "senior", "mikel", "maricon", new DateTime(2006, 12, 08), new DateTime(2024, 02, 01));
        //ITWorker l = new ITWorker(1, new List<string>(), "senior", "mikel", "maricon", new DateTime(2006, 12, 07), new DateTime(2024, 02, 01));

        while (true)
        {
            Console.WriteLine("Introduce un numero para elegir una opcion");
            Console.WriteLine(menu);
            Console.ReadLine();
        }
    }
}
