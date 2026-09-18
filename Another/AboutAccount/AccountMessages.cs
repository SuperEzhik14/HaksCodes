using Another.AboutProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Another.AboutAccount
{
    internal class Messanger
    {
        private List<Message> messages = new List<Message>();

        public List<Message> GetMessages()
        {
            var readymessages = from m in messages
                                orderby m.date descending
                                select m;
            var readymessages2 = from m in readymessages
                                 orderby m.Sender.chaekmarklvl descending
                                 select m;
           return readymessages2.ToList();
        }
        public void SetNewMessages(Message mes)
        {
            messages.Add(mes);
        }
    }
}
