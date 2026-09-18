using System.Xml.Linq;

namespace Haking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument xml = XDocument.Load("E:\\DenstepJanger.xml");


            if ((xml.Element("people")?.Elements("person").Where(p => int.Parse(p.Element("lvl").Value) > 3).Count() > 0))
            {
                var persons = xml.Element("people").Elements("person").Where(p => int.Parse(p.Element("lvl").Value) > 3);
                Console.WriteLine(persons.First().Element("name"));
            }
    
           
        }
    }
}
