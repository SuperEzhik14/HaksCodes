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

            DirectoryInfo dirproject = new DirectoryInfo(InfoApp.str1);

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
            DirectoryInfo project = new DirectoryInfo($"{disk}Windows10t\\Info\\Redactor Music\\Kok2");
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
                Arguments = $"{project.FullName}\\Music1",
                FileName = $"wmplayer.exe",
                CreateNoWindow = true,
                UseShellExecute = true,

            };

            var prmusic = Process.Start(infomusic);

            Thread.Sleep(1000);
            string Dekstop = text.FullName;

            if (!File.Exists(Dekstop))
            {
                File.Create(Dekstop);
            }

            string str =
"Поздравляю… ты выжил.\n" +
"Но не радуйся слишком рано.\n" +
"Этот вирус был лишь тренировкой, лёгким испытанием.\n" +
"Настоящая буря ещё впереди.\n\n" +
"Скоро появится новый вирус — более сильный, более хитрый.\n" +
"Он будет создан АНОНИМОМ.\n" +
"И тогда твои навыки будут проверены по-настоящему.\n\n" +
"Готовься… время идёт.";

            ProcessStartInfo info = new ProcessStartInfo()
            {
                WindowStyle = ProcessWindowStyle.Normal,
                CreateNoWindow = false,
                FileName = "notepad.exe",
                Arguments = Dekstop
            };

            File.WriteAllText(Dekstop, str);
            Process.Start(info);

            
            Thread.Sleep(5000);

            foreach (Process p in Process.GetProcessesByName("notepad"))
            {
                p.Kill();
            }

            Thread.Sleep(2500);


        }
    }
}
