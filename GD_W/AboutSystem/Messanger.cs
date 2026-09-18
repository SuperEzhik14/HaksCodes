using GD_W.AboutSystem.AboutSystenMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD_W.AboutSystem
{
    class Messanger
    {
        public List<IMessage> messages {  get; protected set; }
        public Messanger()
        {
            messages = new List<IMessage>();
        }

        public void RemoveMessage(params IMessage[] messages)
        {
            for (int i = 0; i < messages.Length; i++)
            {
                this.messages.Remove(messages[i]);
            }
        }
    }
}
