using System;
using System.Xml.Linq;

namespace Haking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RedactorInformation redactor = new RedactorInformation();
            redactor.Start();

        }
    }

    class RedactorInformation
    {
        public List<Person> users = new List<Person>();
        public List<Company> companies = new List<Company>();
        private char disk;

        public void Start()
        {
            bool temp = true;
            bool temp2 = false;
            foreach (var dis in DriveInfo.GetDrives())
            {
                Console.Write($"{dis.Name} ");
            }
            Console.WriteLine();
            Console.Write("Введите букву доп. диска: ");
            disk = char.Parse(Console.ReadLine());
            Console.Clear();
            while (temp)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("                  **=- Redactor Information -=**");
                Console.WriteLine("[W сохранить] [E скачять] [R, выбрать компанию] [Esc выйти]");
                Console.WriteLine("[A создать компанию] [S, удалить компанию]");

                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.W: SaveXML(); temp2 = true; break;
                        case ConsoleKey.E: LoadXML(); break;
                        case ConsoleKey.A: CreateCompany(); break;
                        case ConsoleKey.S: DeleteCompany(); break;
                        case ConsoleKey.R: ChooseCompany(); break;
                        case ConsoleKey.Escape: temp = false; break;
                    }
                }
            }

            if (!temp2)
            {
                Console.Clear();
                Console.WriteLine(" [S да] [D нет]");
                Console.WriteLine("Вы не сохранили редактор, данные могут удалиться навсегда");
                Console.WriteLine("Сохранить данные?");
                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.S: SaveXML();break;
                    case ConsoleKey.D: break;
                }
            }
        }

        public async void SaveXML()
        {
            Console.Clear();
            Console.Write($"Сохранить в диск {disk}: ");
            string name = $"{disk}:\\{Console.ReadLine()}";
            

            if (!Directory.Exists(name))
            {
                DirectoryInfo dir = new DirectoryInfo(name);
                dir.Create();

                XDocument doc = new XDocument();

                
                doc.Add(new XElement("University"));
                var root = doc.Element("University");
                root.Add(new XElement("users", new XComment("Тут все users этой программы")));
                root.Add(new XElement("companies", new XComment("Тут будут компании удачи в поиске хакера!")));

                foreach (var user in users)
                {
                    root.Element("users").Add(new XElement("person", new XElement("name", user.Name), new XElement("age", user.Age), new XElement("ID", user.Id)));
                }

                foreach (var company in companies)
                {
                    XElement workers = new XElement("workers");
                    foreach (var user in company.workers)
                    {
                        workers.Add(new XElement("person", new XElement("name", user.Name), new XElement("age", user.Age), new XElement("ID", user.Id)));
                    }
                    root.Element("companies").Add(new XElement("company", new XElement("name", company.Name), new XElement("maxcountworkers", company.maxcountworkers), new XElement("entryage", company.entryage), new XElement("countworkers", company.workers.Count), workers));
                }
                

                doc.Save($"{dir.FullName}\\info.xml");
            }
            else
            {
                XDocument doc = new XDocument();

                
                doc.Add(new XElement("University"));
                var root = doc.Element("University");
                root.Add(new XElement("users", new XComment("Тут все users этой программы")));
                root.Add(new XElement("companies", new XComment("Тут будут компании удачи в поиске хакера!")));

                foreach (var user in users)
                {
                    root.Element("users").Add(new XElement("person", new XElement("name", user.Name), new XElement("age", user.Age), new XElement("ID", user.Id)));
                }

                foreach (var company in companies)
                {
                    XElement workers = new XElement("workers");
                    foreach (var user in company.workers)
                    {
                        workers.Add(new XElement("person", new XElement("name", user.Name), new XElement("age", user.Age), new XElement("ID", user.Id)));
                    }
                    root.Element("companies").Add(new XElement("company", new XElement("name", company.Name), new XElement("maxcountworkers", company.maxcountworkers), new XElement("entryage", company.entryage), new XElement("countworkers", company.workers.Count), workers));
                }

                doc.Save($"{name}\\info.xml");
            }
            Console.WriteLine();
            Console.WriteLine("Сохранено!");
            Console.ReadKey();
            Console.Clear();
        }
        public void LoadXML()
        {
            Console.Clear();
            List<FileInfo> mightxmls = new List<FileInfo>();
            //Поиск возможных файлов
            foreach (var doc in Directory.GetDirectories($"{disk}:\\"))
            {

                try
                {
                    foreach (var xml in Directory.GetFiles($"{doc}"))
                    {

                        if (xml.EndsWith("xml"))
                        {
                            try
                            {
                                XDocument doc2 = XDocument.Load($"{xml}");
                                mightxmls.Add(new FileInfo($"{xml}"));
                            }
                            catch
                            {

                            }
                        }
                    }
                }
                catch
                {

                }

            }
            Queue<FileInfo> queue = new Queue<FileInfo>(mightxmls.ToArray());
            FileInfo file = null;
            bool temp = true;
            while (temp)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("[S скип] [D скачять] [ESC выйти]");
                Console.WriteLine("Возможные xml редакторы: ");

                int temp2 = 0;
                foreach (var xml in queue)
                {
                    if (temp2 == 0)
                    {
                        Console.WriteLine($" >{xml.FullName.Remove(xml.FullName.Length - 9)} :  доп инфо [создано {xml.CreationTime}] [последние изменение {xml.LastWriteTime}]                            ");
                        temp2 = 1;
                    }
                    else
                    {
                        Console.WriteLine($"  {xml.FullName.Remove(xml.FullName.Length - 9)} :  доп инфо [создано {xml.CreationTime}] [последние изменение {xml.LastWriteTime}]                               ");
                    }
                        
                    
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.S:
                            if (queue.Count > 1)
                            {
                                queue.Enqueue(queue.Dequeue());
                            }
                            break;
                        case ConsoleKey.D: if (queue.Count >= 1)
                            {
                                file = queue.Peek();
                            }
                            
                            temp = false; break;
                        case ConsoleKey.Escape: temp = false; break;
                    }
                }
            }
            
            if (file != null)
            {
                users = new List<Person>();
                XDocument doc = XDocument.Load(file.FullName);
                foreach (var person in doc.Root.Element("users").Elements("person"))
                {
                    
                    users.Add(new Person(person.Element("name").Value, Guid.Parse(person.Element("ID").Value), int.Parse(person.Element("age").Value)));
                }
                companies = new List<Company>();
                foreach (var company in doc.Root.Element("companies").Elements("company"))
                {
                    
                    Company comp = new Company(company.Element("name").Value, int.Parse(company.Element("entryage").Value), int.Parse(company.Element("maxcountworkers").Value));
                    foreach (var person in company.Element("workers").Elements("person"))
                    {
                        comp.AddPerson(new Person(person.Element("name").Value, Guid.Parse(person.Element("ID").Value), int.Parse(person.Element("age").Value)), in users);
                    }
                    
                    companies.Add(comp);
                }
                Console.WriteLine("Скачено!");
                Console.ReadKey();

            }

            
            Console.Clear();
        }

        public void ChooseCompany()
        {
            Console.Clear();

            Queue<Company> queue = new Queue<Company>(companies.ToArray());
            FileInfo file = null;
            bool temp = true;

            while (temp)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("[S скип] [D открыть] [ESC выйти]");
                Console.WriteLine("Компании:");

                int temp2 = 0;
                foreach (var xml in queue)
                {
                    if (temp2 == 0)
                    {
                        Console.WriteLine($" >{xml.Name}                                   ");
                        temp2 = 1;
                    }
                    else
                    {
                        Console.WriteLine($"  {xml.Name}                                   ");
                    }


                }

                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.S: if (queue.Count > 1)
                                queue.Enqueue(queue.Dequeue());
                                break;
                        case ConsoleKey.D:
                            if (queue.Count >= 1)
                            {
                                queue.Peek().Open(in users);
                            }
                            
                           
                            break;
                        case ConsoleKey.Escape: temp = false; break;
                    }
                }
            }

            Console.Clear();

        }
        public void DeleteCompany()
        {

            Console.Clear();
            Queue<Company> queue = new Queue<Company>(this.companies);
            Company comp = null;
            bool temp = true;

            if (companies.Count == 0)
                return;

            
            while (temp)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("[S скип] [D удалить] [ESC выйти]");
                Console.WriteLine("Компании: ");

                int temp2 = 0;
                foreach (var xml in queue)
                {
                    if (temp2 == 0)
                    {
                        Console.WriteLine($" >{xml.Name} :  доп инфо [кол.во рабочих. {xml.workers.Count}] [осталось мест {xml.maxcountworkers - xml.workers.Count}] [с {xml.entryage} лет]                           ");
                        temp2 = 1;
                    }
                    else
                    {
                        Console.WriteLine($"  {xml.Name} :  доп инфо [кол.во рабочих. {xml.workers.Count}] [осталось мест {xml.maxcountworkers - xml.workers.Count}] [с {xml.entryage} лет]                           ");
                    }


                }

                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.S:
                            if (queue.Count > 1)
                            {
                                queue.Enqueue(queue.Dequeue());
                            }

                            break;
                        case ConsoleKey.D: comp = queue.Peek(); temp = false; break;
                        case ConsoleKey.Escape: temp = false; break;
                    }
                }
            }

            if (comp != null)
            {
                if (companies.Contains(comp)){
                    companies.Remove(comp);
                    Console.WriteLine("Успешно удалена!");
                    Console.ReadKey();
                }
            }
            Console.Clear();
        }
        public void CreateCompany()
        {
            Console.Clear();
            Console.Write("Введите название компании: ");
            string Name = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Введите входной возраст: ");
            int Entryage = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Введите макс число рабочик в компании: ");
            int maxcount = int.Parse(Console.ReadLine());

            Company comp = new Company(Name,Entryage,maxcount);
            companies.Add(comp);
            Console.WriteLine("Компания успешно создана!");
            Console.ReadKey();
            Console.Clear();
        }
    }


    class Person
    {
        public Guid Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        public Person(string Name, Guid Id, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
    }

    class Company
    {
        public int maxcountworkers { get; private set; }
        public int entryage { get; private set; }
        public string Name { get; private set; }
        public List<Person> workers {  get; private set; }

        public Company(string Name, int Entryage, int Maxcountworkers)
        {
            this.Name = Name;
            this.workers = new List<Person>();
            entryage = Entryage;
            maxcountworkers = Maxcountworkers;
        }
        
        public void Open(in List<Person> users)
        {
            bool temp = true;
            Console.Clear();
            while (temp)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("[S добавить чел] [D удалить чел] [F показать людей] [Esc выйти]");
                Console.WriteLine($"Компания: {Name}                   ");
                Console.WriteLine($"Количество рабочих: {workers.Count}          ");
                Console.WriteLine($"Входной возраст: {entryage}           ");
                Console.WriteLine($"Количество свободных мест: {maxcountworkers - workers.Count}          ");



                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.S:
                            Console.Clear();
                            Console.WriteLine("Добавление рабочего");
                            Console.Write("Введите имя: ");
                            string name = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Введите возраст: ");
                            int age = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            Guid ID = Guid.NewGuid();
                            Person person = new Person(name, ID, age);
                            AddPerson(person, users);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case ConsoleKey.D:
                            Console.Clear();
                            Console.WriteLine("Удаление рабочего");
                            Console.Write("Введите имя-ID: ");
                            string text = Console.ReadLine();

                            Person pers;

                            if (Guid.TryParse(text, out var id))
                            {
                                pers = FindPerson(id);
                                if (pers == null)
                                {
                                    Console.WriteLine("Рабочий с таким ID не найден.");
                                    return;
                                }
                            }
                            else
                            {
                                pers = FindPerson(text);
                                if (pers == null)
                                {
                                    Console.WriteLine("Рабочий с таким именем не найден.");
                                    return;
                                }
                            }

                            DeletePerson(pers, users);

                            Console.WriteLine("Рабочий успешно удалён.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case ConsoleKey.F:
                            Console.Clear();
                            Console.WriteLine("Cписок рабочих: ");
                            foreach (var worker in workers)
                            {
                                Console.WriteLine($" {worker.Name} Age:{worker.Age} ID: {worker.Id} ");
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case ConsoleKey.Escape: temp = false; break;
                    }
                }
            }
            Console.Clear();
        }

        public void AddPerson(Person person, in List<Person> users)
        {
            if (!workers.Contains(person) && workers.Count < maxcountworkers && person.Age >= entryage)
            {
                users.Add(person);
                workers.Add(person);
                Console.WriteLine("Успешно добавлен!");
            }
            else
            {
                Console.WriteLine("Количество мест ограничено или недостаточный возраст!");
            }
        }

        public Person FindPerson(string name)
        {
            Person person = workers.FirstOrDefault(p => p.Name == name);
            if (person != null)
            {
                return person;
            }
            else
            {
                return null;
            }
        }

        public Person FindPerson(Guid ID)
        {
            Person person = workers.FirstOrDefault(p => p.Id == ID);
            if (person != null)
            {
                return person;
            }
            else
            {
                return null;
            }
        }
        public void DeletePerson(Person person, in List<Person> users)
        {
            if (workers.Contains(person))
            {
                users.Remove(person);
                workers.Remove(person);
                Console.WriteLine("Успешно удален!");
            }
        }
    }
}
