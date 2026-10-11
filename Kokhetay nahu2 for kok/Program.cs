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
                Arguments = $"E:\\TheFatRat_-_Unity_64349365.mp3",
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

            string str = "Здарова, меня зовут Pixel221, я предпочитаю файлы на завтрак\nя не буду тебя спрашивать можно ли мне их есть или нет\nа начну пожалуй сейчас 3.... 2........ 1...... Удачи! @=@";

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
