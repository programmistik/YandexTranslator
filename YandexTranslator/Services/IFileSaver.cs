using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTranslator.Model;

namespace YandexTranslator.Services
{
    public interface IFileSaver
    {
        void Save(IEnumerable<object> List, string filename);
        IEnumerable<Tuple<string, string, Translate>> Load(string filename);
    }
}
