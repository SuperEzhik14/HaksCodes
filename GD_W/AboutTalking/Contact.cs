using GD_W.AboutAccount;
using GD_W.AboutSystem;
using GD_W.AboutSystem.AboutSystenMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD_W.AboutTalking
{
    internal class Contact : Messanger, InterfaceMessanger
    {        
        public Account Friend { get; private set; }
        public string Name { get; private set; }

        public void StartWindow()
        {
            int lastindex = messages.Count(); 
            Console.WriteLine($"_ {Name} _ | {Friend.GetData()}          |W, Settings|Esc, Exit|S,D,↑↓|");
            for (int i = 10; i < 10; i--)
            {
                try
                {
                    IMessage message = messages[lastindex - i];

                    // the cheak sender
                    if (Friend.Phone.ToString() == message.Sender.Phone.ToString())
                    {
                        Console.WriteLine($"{Name} {message.Title} {message.date}");
                    }
                }
                catch
                {
                    break;
                }
                finally
                {

                }
                
            }

            Console.WriteLine();
        }
        public void Controler()
        {

        }
    }
}
