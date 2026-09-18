using GD_W.AboutSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD_W.AboutAccount
{
    class Account
    {
        public Phone Phone { get; private set; }
        public string Name {  get; private set; }

        private DateTime? dateleave { get; set; }

        public string GetData()
        {
            if (dateleave != null)
            {
                if (DateTime.Now < dateleave.Value.AddMinutes(1))
                {
                    return "Был(а) всего минуту назад";
                }
                else if (DateTime.Now < dateleave.Value.AddMinutes(5))
                {
                    return "Был(а) совсем недавно";
                }
                else if (DateTime.Now < dateleave.Value.AddMinutes(15))
                {
                    return "Был(а) несколько минут назад";
                }
                else if (DateTime.Now < dateleave.Value.AddMinutes(30))
                {
                    return "Был(а) около получаса назад";
                }
                else if (DateTime.Now < dateleave.Value.AddHours(1))
                {
                    return "Был(а) примерно час назад";
                }
                else if (DateTime.Now < dateleave.Value.AddHours(12))
                {
                    return "Был(а) пару часов назад";
                }
                else if (DateTime.Now < dateleave.Value.AddDays(1))
                {
                    return "Был(а) вчера";
                }
                else if (DateTime.Now < dateleave.Value.AddDays(3))
                {
                    return "Был(а) несколько дней назад";
                }
                else if (DateTime.Now < dateleave.Value.AddDays(7))
                {
                    return "Был(а) на прошлой неделе";
                }
                else
                {
                    return "Был(а) давно";
                }
            }
            else
            {
                return "В Сети";
            }
        }
        public void CloseApp()
        {
            dateleave = DateTime.Now;
        }

        public void OpenApp()
        {
            dateleave = null;
        }
    }
}
