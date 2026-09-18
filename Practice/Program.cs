using System.IO;
using System.Numerics;
using System.Runtime;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Practice
{
    internal class Program
    {
        static int count = 0;   
        static async Task Main(string[] args)
        {

            Account account = new Account();
            account.Create("GyperTronic112", "ИДИ НАХУЙЙЙЙЙЙЙЙЙЙЙЙЙЙЙЙЙ");
            Console.ReadLine();
            account.Create("Blad", "7771");
        }

    }

    partial class Account
    {


        public string name { get; private set; }
        public string password { get; private set; }
        public Guid? Id { get; private set; }
        public DateTime data { get; private set; }


        public void Create(string Name, string Password)
        {
            Thread.Sleep(10);
            DirectoryInfo deltaforest = new DirectoryInfo($"E:\\DeltaForest");
            if (deltaforest.Exists)
            {
                DirectoryInfo bazaaccounts = new DirectoryInfo($"{deltaforest.FullName}\\BazaAccounts");


                if (!File.Exists($"{deltaforest.FullName}\\Account"))
                {
                    name = Name;
                    password = Password;                   
                    data = DateTime.Now;
                    bool temp = true;
                    Guid? IdDemo = Guid.NewGuid();
                    
                    Id = IdDemo;

                    FileInfo account = new FileInfo($"{deltaforest.FullName}\\Account.txt");
                    using (account.Create());

                    string[] Lines = { Id.ToString(), Password, Name, data.ToString() };

                    File.AppendAllLines(account.FullName, Lines);

                    account.CopyTo($"{bazaaccounts.FullName}\\Account_{Id}.txt");


                    Console.WriteLine("Аккаунт был успешно создан");
                }
                else
                {
                    Console.WriteLine("Извиняюсь вы уже создали аккаунт");
                    return;
                }
                

                
            }
            else
            {
                throw new Exception("Удалена важная папка программы <DeltaForest>");
            }
        }
    }

    partial class Account
    {
        private static List<Account> accounts;
        static Account()
        {
            accounts = new List<Account>();
            DirectoryInfo deltaforest = new DirectoryInfo($"E:\\DeltaForest");
            DirectoryInfo bazapeople = new DirectoryInfo($"{deltaforest.FullName}\\BazaAccounts");
            if (!deltaforest.Exists)
            {
                deltaforest.Create();
                
                bazapeople.Create();
            }

            //Lines[0] = Id аккаунта
            //Lines[1] = Password аккаунта
            //Lines[2] = Name аккаунта
            //Lines[3] = Date создания аккаунта

        }
    }
}
