using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortText.Model
{
    public static class CheckErrorText
    {
        public static string NotErrorText = "Нет ошибок";
        public static string TextIsNotTXT(bool isTXT)
        {
            if (!isTXT)
                return "Файл должен быть формата .txt";
            return NotErrorText;
        }
    }
}
