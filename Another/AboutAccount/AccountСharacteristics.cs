using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Another.AboutAccount
{
    internal class CharacteristicsAc
    {
        public string Name { get; protected set; }
        public Guid AcId { get; protected set; }

        public CharacteristicsAc()
        {
            AcId = Guid.NewGuid();
        }

        public void SetNewName(string Name)
        {
            if (Name.Length < 20)
            {
                this.Name = Name;
            }
        }
    }
}
