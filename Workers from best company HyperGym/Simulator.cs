using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers_from_best_company_HyperGym
{
    class Simulator
    {
        public Simulator()
        {
            //Поменяй диск E:\\ с зависимости от диска
            DirectoryInfo dir = new DirectoryInfo("E:\\");
        }
        public void Start()
        {
            Console.WriteLine("0. = Удалить все данные");
            Console.WriteLine("1. = Придти в редактор");
            Console.WriteLine("2. = Выйти");

            while (true)
            {
                Console.SetCursorPosition(0, 4);
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey().Key;

                    switch (key)
                    {
                        case ConsoleKey.S: break;
                        case ConsoleKey.D: break;
                    }
                }
            }
        }

        private void CreateCompany()
        {

        }
    }
}
