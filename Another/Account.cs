using Another.AboutAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Another
{
    class Account
    {
        public int chaekmarklvl { get; protected set; }  = 0;
        public CharacteristicsAc characteristics = new CharacteristicsAc();
        public Account(string Name)
        {
            characteristics.SetNewName(Name);
        }

        public void ChangeCheakMark(string password)
        {
            if (password == "6244")
                chaekmarklvl++;
        }
    }
}
