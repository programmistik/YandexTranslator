using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTranslator.Model
{
    public class Language
    {
        public string Code { get; set; }
        public string FullName { get; set; }

        public override string ToString()
        {
            return $"{Code}-{FullName}";
        }
    }
}
