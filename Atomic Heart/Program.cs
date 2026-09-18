using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        Game game = new Game();
        game.OpenConsole();
    }  
}

class Game
{
    private DirectoryInfo gamedir = new DirectoryInfo("E:\\Decstore");
    private FileInfo gamefile;
    public Game()
    {
        try
        {
            // Создание основной папки
            if (!gamedir.Exists)
                gamedir.Create();

            DirectoryInfo supportdir = new DirectoryInfo("E:\\Decstore\\Support");
            if (!supportdir.Exists)
                supportdir.Create();

            gamefile = new FileInfo(Path.Combine(supportdir.FullName, "info.xml"));

            if (!gamefile.Exists)
            {
                XDocument doc = new XDocument(
                    new XElement("program",
                        new XComment("Главное читайте комментарии!"),
                        new XElement("workers"),
                        new XElement("games")
                    )
                );
                doc.Save(gamefile.FullName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    public void OpenConsole()
    {
        while (true)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Добро Пожаловать! Welcome to SportKit!");
            Console.WriteLine("Управления: [S][D]");
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.S:AddGame(); break;
                    case ConsoleKey.D: AddWorker(); break;
                }
            }
        }
    }

    public void AddWorker()
    {
        Console.Clear();
        Console.WriteLine("Введите имя фамилию!");
        Console.WriteLine();
        Guid id = Guid.NewGuid();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.WriteLine();
        Console.Write("LastName: ");
        string lastname = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine());
        XDocument doc = XDocument.Load(gamefile.FullName);
        XElement worker = new XElement("worker",new XAttribute("ID", id), new XElement("name", name), new XElement("lastname", lastname), new XElement("age", age));

        var nodes = doc.Root.Elements();
        foreach ( XElement node in nodes )
        {
            if ( node.Name == "workers")
            {
                node.Add(worker);
                doc.Save(gamefile.FullName);
                break;
            }
        }
        Console.Clear();
    }

    public void AddGame()
    {
        Console.Clear();
        Console.WriteLine("Введите названия игры!");
        Console.WriteLine();
        Guid id = Guid.NewGuid();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        
        XDocument doc = XDocument.Load(gamefile.FullName);
        
        XElement game = new XElement("game", new XAttribute("ID", id), new XElement("name", name));

        var nodes = doc.Root.Elements();
        foreach (XElement node in nodes)
        {
            if (node.Name == "games")
            {
                node.Add(game);
                doc.Save(gamefile.FullName);
                break;
            }
        }
        Console.Clear();
    }
}
 