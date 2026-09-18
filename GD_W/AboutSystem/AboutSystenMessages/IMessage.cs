using GD_W.AboutAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD_W.AboutSystem.AboutSystenMessages
{
    interface IMessage
    {
        Guid Id { get; }
        DateTime date { get; set; }
        string Title { get; set;  }
        Account Sender {  get; set; }
    }
}
