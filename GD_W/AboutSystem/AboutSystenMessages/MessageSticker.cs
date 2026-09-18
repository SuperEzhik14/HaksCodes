using GD_W.AboutAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD_W.AboutSystem.AboutSystenMessages
{
    class MessageSticker : IMessage
    {
        public string Title { get; set; }
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime date { get; set; }
        public Account Sender { get; set; }
    }
}
