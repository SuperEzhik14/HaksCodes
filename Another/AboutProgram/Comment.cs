using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another.AboutProgram
{
    class Comment
    {
        private Account account;
        public DateTime date { get; } = DateTime.Now;
        public string Text;
        public Comment(Account account, string text)
        {
            this.account = account;
            this.Text = text;
            DateTime dateOnly = DateTime.Now;
        }

        public string GetNameSender()
        {
            return account.characteristics.Name;
        }
    }
}
