using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymShark.ForObject
{
    internal class Sale
    {
        public byte procent { get; private set; }
        public DateTime date { get; private set; }

        public Sale(byte procent, int days = 0, int hours = 0, int minutes = 0)
        {
            this.procent = procent;
            this.date = DateTime.Now;
            date = date.AddDays(days);
            date = date.AddHours(hours);
            date = date.AddMinutes(minutes);
        }
    }
}
