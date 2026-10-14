using System.Diagnostics;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
        }
    }


    class Game
    {
        public int hearts = 3;
        public List<Question> questions = new List<Question>();
        public Game()
        {
            string disk = "";

            foreach (var dr in DriveInfo.GetDrives())
            {
                if (dr.DriveType == DriveType.Fixed)
                {
                    foreach (var obj in Directory.GetDirectories(dr.Name))
                    {
                        if (Path.GetFileName(obj) == "Windows10t")
                        {
                            disk = dr.Name;
                            Console.WriteLine("найдено");
                            break;
                        }
                    }
                }
            }

            if (disk == "")
            {
                Console.WriteLine("не найдено");
            }

            DirectoryInfo dir = new DirectoryInfo($"{disk}Windows10t");
            DirectoryInfo dir2 = new DirectoryInfo($"{disk}Windows10t\\Info");
            FileInfo timestart = new FileInfo($"{dir2.FullName}\\TimeStart.json");
            FileInfo text = new FileInfo($"{dir2.FullName}\\Text.txt");


            ProcessStartInfo infomusic = new ProcessStartInfo()
            {
                FileName = "wmplayer.exe",
                Arguments = $@"/play /close ""{dir2.FullName}\Redactor\Kokhetay nahu2 for kok\Music1.mp3""",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = true

            };

            var prmusic = Process.Start(infomusic);


            int count = 0;
            count++;
            Response response = null;
            Response response2 =null;
            Response response3 = null;
            Response response4 = null;
            Question question = null;


            response = new Response("1945", 'a');
            response2 = new Response("1950", 's');
            response3 = new Response("1955", 'd');
            response4 = new Response("1962", 'f');
            question = new Question("В какой году были созданы первые ИИ?", response2,response,response2,response3,response4);
            questions.Add(question);

            response = new Response("Фишинг", 'a');
            response2 = new Response("Вирус", 's');
            response3 = new Response("Ддос", 'd');
            response4 = new Response("Взлом пароля", 'f');
            question = new Question("Какая самая популярная хакер атака?", response3, response, response2, response3, response4);
            questions.Add(question);
            response = new Response("Nistory", 'a');
            response2 = new Response("OptionStandart", 's');
            response3 = new Response("Sender", 'd');
            response4 = new Response("Kaspersky", 'f');
            question = new Question("Какая программа может остановить вирус?", response4, response, response2, response3, response4);
            questions.Add(question);

            response = new Response("Kenbak‑1", 'a');
            response2 = new Response("Micral N", 's');
            response3 = new Response("Altair 8800", 'd');
            response4 = new Response("Apple I", 'f');
            question = new Question("Название первого персонального компьютера на земле?", response, response, response2, response3, response4);
            questions.Add(question);

            response = new Response("данные", 'a');
            response2 = new Response("шаблоны", 's');
            response3 = new Response("програмный код", 'd');
            response4 = new Response("изображение", 'f');
            question = new Question("Что хранит тип файла xml?", response, response, response2, response3, response4);
            questions.Add(question);

            response = new Response("Anonymous", 'a');
            response2 = new Response("Lizard Squad", 's');
            response3 = new Response("MR.robots", 'd');
            response4 = new Response("Chaos Computer Club (CCC)", 'f');
            question = new Question("Какой хакерской организации не существует?", response3, response, response2, response3, response4);
            questions.Add(question);

            response = new Response("омлет", 'a');
            response2 = new Response("ойгурт", 's');
            response3 = new Response("бургер", 'd');
            response4 = new Response("стейк", 'f');
            question = new Question("Что обычно едят хакеры на завтрак?", new Response("ахахаха", 'g'), response, response2, response3, response4);
            questions.Add(question);

            response = new Response("sdotbv", 'a');
            response2 = new Response("stropppgenryyy", 's');
            response3 = new Response("icantt", 'd');
            response4 = new Response("ASCEND", 'f');
            question = new Question("Программироваыврлыуде?", new Response("ахахаха", 'g'), response, response2, response3, response4);
            questions.Add(question);

            response = new Response("Давай", 'a');
            response2 = new Response("Можно закончить", 's');
            response3 = new Response("Хочу в кентуки", 'd');
            response4 = new Response("Удалить все файлы", 'f');
            question = new Question("Последний Вопрос?", new Response("ахахаха", 'g'), response, response2, response3, response4);
            questions.Add(question);


            int countquestion = 0;
            foreach (Question questionobj in questions)
            {
                countquestion++;
                Console.Clear();
                Console.WriteLine($"Жизней {hearts}");
                Console.WriteLine($"Вопрос {countquestion}");
                Console.WriteLine();
                Console.WriteLine($"{questionobj.text}");
                Console.WriteLine($"");
                Console.Write($"Ключи ");
                foreach (var item in questionobj.options)
                {
                    Console.Write($"[ {item.obj.ToString().ToUpper()} {item.text}]  ");

                    if (questionobj.options.Count > 2 && questionobj.options.Count < 4)
                    {
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
                Console.WriteLine($"Введи букву правильного ключа");
                Console.Write($"Ключ: ");
                char key = ' ';
                try
                {
                    key = Console.ReadKey().KeyChar;
                }
                catch
                {
                    Console.WriteLine("Ухты захотел поиграться со мной");
                    Console.WriteLine("Ну тогда получай рандом ключ");
                    key = questionobj.options[new Random().Next(0, questionobj.options.Count)].obj;
                }

                // Фразы для правильных ответов
                string[] correctPhrases = {
    "Ключ принят. Доступ разрешён.",
    "Поздравляем! Алгоритм выполнен верно.",
    "Система подтверждает правильный ввод.",
    "Ключ совпал. Всё работает идеально.",
    "Ответ принят. Продолжай путь."
};

                // Фразы для неправильных ответов
                string[] wrongPhrases = {
    "Ключ был сломан. Наши извинения.",
    "Неправильный ключ. Доступ отклонён.",
    "Ошибка проверки. Попробуй снова.",
    "Система отвергла твой ввод.",
    "Ключ не совпал. Потеряна одна жизнь."
};

                response = questionobj.options.First(p => p.obj.ToString().ToUpper() == key.ToString().ToUpper());

                if (response.ID.Equals(questionobj.rightpersonse.ID))
                {
                    Console.WriteLine($"{correctPhrases[new Random().Next(0, 5)]}");
                }
                else
                {
                    hearts--;

                    Console.WriteLine($"{wrongPhrases[new Random().Next(0, 5)]}");
                    Console.WriteLine($"- Жизнь");

     
                    if (hearts == 0)
                    {
                        Console.WriteLine("Смерть");                       

                        try
                        {
                            if (prmusic != null && !prmusic.HasExited)
                            {
                                prmusic.Kill();
                            }
                        }
                        catch 
                        {

                           
                        }

                        ProcessStartInfo video = new ProcessStartInfo()
                        {
                            FileName = "wmplayer.exe",
                            Arguments = $@"""{dir2.FullName}\Redactor\Kokhetay nahu2 for kok\Video1.mp4""",
                            UseShellExecute = true
                        };

                        var pr = Process.Start(video);



                        pr.WaitForExit();

                        ProcessStartInfo text2 = new ProcessStartInfo()
                        {
                            WindowStyle = ProcessWindowStyle.Normal,
                            Arguments = $"{text.FullName}",
                            FileName = $"notepad.exe",

                            CreateNoWindow = false,
                            UseShellExecute = true,

                        };

                        File.WriteAllText(text.FullName, "А и ище удали папку Windows10t на диске\nНу просто чтобы активировать 2 фазу вируса\n;)");
                        var text2_ = Process.Start(text2);
                        prmusic.Start();
                        Thread.Sleep(5000);
                        foreach (var item in Process.GetProcessesByName("cmd.exe"))
                        {
                            item.Kill();
                        }

                        return;
                    }
                }
                Console.ReadKey();
            }
        }
    }

    class Response
    {
        public string text;
        public char obj;
        public Guid ID;
        public Response(string text, char obj)
        {
            this.text = text;
            this.obj = obj;
            ID = Guid.NewGuid();
        }
        
    }
    class Question
    {
        public string text;
        public List<Response> options = new List<Response>();
        public Response rightpersonse;
        public Question(string text, Response rightpersonse, params Response[] options)
        {
            this.text = text;
            this.options = options.ToList();
            this.rightpersonse = rightpersonse;
        }
    }

}
