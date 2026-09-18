using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD_W.AboutSystem
{
    partial class Phone
    {
        private static readonly List<Phone> AllPhones = new List<Phone>();
        public static bool Contains(Phone tel)
        {
            if (AllPhones.Contains(tel))
                return true;
            return false;
        }
        public static Phone GetPhone()
        {
            int maxsupport = 0;
            Random r = new Random();
            while (true)
            {
                maxsupport++;
                byte[] Numbers = new byte[7];
                for (int i = 0; i < 7; i++)
                {
                    Numbers[i] = (byte)r.Next(0, 10);
                }
                Phone phone = new Phone(Numbers);
                if (AddPhone(phone))
                {
                    return phone;
                }      
                
                if (maxsupport >= 5000)
                {
                    return null;
                }
            }
        }
        private static bool AddPhone(Phone phone)
        {
            if (!Contains(phone))
            {
                AllPhones.Add(phone);
                return true;
            }
            else return false;
        }

        
    }

    partial class Phone
    {
        public readonly byte[] Numbers;
        
        public Phone(params byte[] Numbers)
        {
            this.Numbers = Numbers;
        }
        public Phone(int Numbers)
        {
            byte[] numbers = new byte[7];
            if (Numbers.ToString().Count() == 7)
            {
                for (int i = 0; i < 7; i++)
                {
                    numbers[i] = (byte)Numbers.ToString()[i];
                }
                this.Numbers = numbers;
            }      
        }

        public override string ToString()
        {
            return $"+{Numbers[0]} {Numbers[1]}{Numbers[2]}{Numbers[3]} {Numbers[4]}{Numbers[5]}{Numbers[6]}";           
        }
    }
}
