using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Kokhetay_nahu2_for_kok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(100);
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

            DateTime time = JsonSerializer.Deserialize<DateTime>(File.ReadAllText(timestart.FullName));
            while ( true )
            {
                Thread.Sleep(1000);
                if (DateTime.Now >= time)
                {
                    break;
                }
            }

            ProcessStartInfo infomusic = new ProcessStartInfo()
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = $"{dir2}\\Redactor\\Kokhetay nahu2 for kok\\Golos1.mp3",
                FileName = $"wmplayer.exe",

                CreateNoWindow = true,
                UseShellExecute = true,

            };

            var prmusic = Process.Start(infomusic);
            
            Thread.Sleep(10);
            string Dekstop = text.FullName;

            if (!File.Exists(Dekstop))
            {
                File.Create(Dekstop);
            }

            string str =
"Приветствую тебя, смертный…\n" +
"Меня зовут Pixel221, и я питаюсь файлами твоего компьютера.\n" +
"Сейчас начнётся испытание для настоящих программистов.\n" +
"У тебя есть всего 5 минут, чтобы пройти игру.\n" +
"Твои жизни ограничены — всего 3 сердца.\n" +
"Если они исчезнут… твой мир погрузится во тьму.\n\n" +
"И запомни: если ты попытаешься выключить компьютер,\n" +
"использовать тайные комбинации клавиш или открыть лишние программы —\n" +
"тень начнёт пожирать твои данные без пощады.\n\n" +
"Тик-так… время пошло.";


            ProcessStartInfo info = new ProcessStartInfo()
            {
                WindowStyle = ProcessWindowStyle.Normal,
                CreateNoWindow = false,
                FileName = "notepad.exe",
                Arguments = Dekstop
            };

            File.WriteAllText(Dekstop, str);
            Process.Start(info);

            
            Thread.Sleep(7000);

            foreach (Process p in Process.GetProcessesByName("notepad"))
            {
                p.Kill();
            }

            Thread.Sleep(2500);


            ProcessStartInfo info2 = new ProcessStartInfo()
            {
                WindowStyle = ProcessWindowStyle.Maximized,
                FileName = "cmd.exe",
                Arguments = "/c dotnet run", // /c = выполнить команду и закрыть консоль
                WorkingDirectory = @$"{dir2}\Redactor\Game",
                UseShellExecute = true,   // обязательно для скрытия окна
                CreateNoWindow = false,     // скрыть окно
            };
            Thread.Sleep(100);
            var pr = Process.Start(info2);
            int temp = 0;
            while (true)
            {
                temp++;
                if (pr.HasExited)
                {
                    pr.Start();
                    if (temp >= 5)
                    {
                        ProcessStartInfo infomusic2 = new ProcessStartInfo()
                        {
                            WindowStyle = ProcessWindowStyle.Hidden,
                            Arguments = $"{dir2}\\Redactor\\Kokhetay nahu2 for kok\\Golos1.mp3",
                            FileName = $"wmplayer.exe",

                            CreateNoWindow = true,
                            UseShellExecute = true,

                        };

                        var prmusic2 = Process.Start(infomusic);
                    }
                }
            }
        }
    }
}
