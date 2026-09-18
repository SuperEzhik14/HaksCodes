
using System.Dynamic;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Runtime.InteropServices;

namespace Redactor_Music
{
    class Account 
    { 
        public Guid Id { get; set; }
        public MassangerSupport massanger;

        public Account()
        {
            Id = Guid.NewGuid();
            massanger = new MassangerSupport(Id, 1);
        }

        public Account(Guid Id, byte MaxSupports)
        {
            massanger = new MassangerSupport(Id, MaxSupports);
            this.Id = Id;
        }
    }

    class MassangerSupport
    {
        private Guid IdPerson;
        public byte MaxSupports;
        public List<Support> Supports = new List<Support>();

        public MassangerSupport(Guid Id, byte MaxSupports)
        {
            IdPerson = Id;
            this.MaxSupports = MaxSupports;
        }
        public void SetMessage()
        {
            Support.SetSupport(new Account(IdPerson));
        }
    }

    partial class Support
    {
        public DateTime date { get; set; }
        public bool result { get; set; }
        public string message { get; set; }

        public Support(Task<bool> task)
        {
            date = DateTime.Now;
            result = task.Result;
        }
    }

    partial class Support
    {
        private static Dictionary<Guid,Support> supports = new Dictionary<Guid, Support>();
        public static Support SetSupport(Account account)
        {

            if (supports.ContainsKey(account.Id))
            {
                return supports[account.Id];
            }
            else
            {
                
                supports[account.Id] = new Support(Processing());
                return supports[account.Id];
            }
        }
        public static void DeleteSupport(Account account)
        {
            if (supports.ContainsKey(account.Id))
            {
                supports.Remove(account.Id);
            }
        }
        public static string HowMuchTime()
        {
            return $"{(supports.Count * 2) / 1000} сек";
        }

        private static async Support Processing()
        {
            Random r = new Random();
            await Task.Delay(supports.Count * 2);
            if (r.Next(0, 2) == 0)
            {
                
            }
            else
            {
                
            }
        }
    }



    internal class Program
    {
        static async Task Main(string[] args)
        {
            
        }
    }
}
