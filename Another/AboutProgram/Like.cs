using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another.AboutProgram
{
    internal class Like
    {
        private Account account;
        public Like(Account account)
        {
            this.account = account;
        }

        public string GetNameSender()
        {
            return account.characteristics.Name;
        }
    }
}
