using System.Xml.Linq;

namespace Haking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string id = "63bf2f0e-0cfc-4c93-9f89-70e8668abaed";
            XDocument xml = XDocument.Load("E:\\DenstepJanger.xml");

            var person = xml.Element("people").Elements("person").FirstOrDefault(p => p.Attribute("ID").Value == id);
            person.Remove();

            xml.Save("E:\\DenstepJanger.xml");
        }
    }
}
