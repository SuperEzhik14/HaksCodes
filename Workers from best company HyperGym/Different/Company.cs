using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers_from_best_company_HyperGym.Different
{
    class Company
    {
        public string Name { get; private set; }
        public List<string> Workers = new List<string>();

        public Company(string Name)
        {
            this.Name = Name;
        }

        
    }
}
