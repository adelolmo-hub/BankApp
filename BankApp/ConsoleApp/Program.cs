using ConsoleApp;

class Program
{
    public static void Main(String[] args)
    {
        ITWorker i = new ITWorker(1,new List<string>(),"junior","mikel","maricon",new DateTime(2024,03,01),new DateTime(2024,02,01));
        ITWorker x = new ITWorker(1, new List<string>(), "senior", "mikel", "maricon", new DateTime(2024, 03, 01), new DateTime(2024, 02, 01));
        ITWorker j = new ITWorker(1, new List<string>(), "junior", "mikel", "maricon", new DateTime(2024, 03, 01), new DateTime(2024, 02, 01));
        ITWorker k = new ITWorker(1, new List<string>(), "medium", "mikel", "maricon", new DateTime(2024, 03, 01), new DateTime(2024, 02, 01));
        ITWorker l = new ITWorker(1, new List<string>(), "medium", "mikel", "maricon", new DateTime(2024, 03, 01), new DateTime(2024, 02, 01));
        ITWorker m = new ITWorker(1, new List<string>(), "senior", "mikel", "maricon", new DateTime(2024, 03, 01), new DateTime(2024, 02, 01));
        Console.WriteLine(x.Level);
        Console.WriteLine(j.Level);
        Console.WriteLine(k.Level);
        Console.WriteLine(l.Level);
        Console.WriteLine(m.Id);
        
    }
}
