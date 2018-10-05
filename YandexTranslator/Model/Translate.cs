using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTranslator.Model
{
    public class Translate : IModel
    {
        public int code { get; set; }
        public string message { get; set; }
        public string lang { get; set; }
        public List<string> text { get; set; }

        public string GetTranslation()
        {
            return text[0];
        }
    }

}

