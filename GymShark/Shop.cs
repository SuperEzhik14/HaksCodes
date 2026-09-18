using GymShark.ForObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GymShark
{
    static class ShopBass
    {
        private static Dictionary<Guid,Account> Accounts = new Dictionary<Guid,Account>();
        public static void AddAccount(Account account)
        {
            if (!Accounts.ContainsKey(account.Id))
            {
                Accounts.Add(account.Id, account);
            }
        }

        public static Account GetAccount(Guid Id)
        {
            if (Accounts.ContainsKey(Id))
            {
                return Accounts[Id];
            }
            else
            {
                return new Account();
            }
        }

        public static Account GetAccount(string Name)
        {
            if (Accounts.ContainsValue(new Account() { Name = Name}))
            {
                List<Account> accounts = new List<Account>((IEnumerable<Account>)Accounts.ToList());
                return accounts.FirstOrDefault(p => p.Name == Name);
            }
            else
            {
                return new Account();
            }
        }
    }
    class Shop
    {
        private static List<Product> Products = new List<Product>();
        static Shop()
        {
            Products.Add(new Product("Onyx V6",new Price(80,new Sale(30,30)),Chapter.Onyx,For.Man));
        }
    }
}
