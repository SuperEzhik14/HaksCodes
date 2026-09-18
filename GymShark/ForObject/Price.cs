using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymShark.ForObject
{
    internal class Price
    {
        public Sale Sale { get; private set; }
        private int Count { get; set; }
        public void Change(int Count)
        {
            this.Count = Count;
        }
        public void ChangeSale(Sale Sale)
        {
            this.Sale = Sale;
        }
        public Price(int Count, Sale? sale = null)
        {
            this.Count = Count;
            this.Sale = sale;
        }
        public int GetCount()
        {
            
            if (Sale != null)
            {
                return Count - (Count * Sale.procent / 100);
            }
            else
            {
                return Count;
            }
        }
    }
}
