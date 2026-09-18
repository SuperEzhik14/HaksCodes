using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another.AboutProgram
{
    

    class Message
    {
        public Account Sender;
        public DateTime date { get; } = DateTime.Now;
        public string Title { get; set; }
        public Message(Account account, string Title)
        {
            this.Title = Title;
            this.Sender = account;
        }    
    }
}
