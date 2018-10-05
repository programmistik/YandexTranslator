using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTranslator.Model;

namespace YandexTranslator.Services
{
    public interface ICacheDataStorage
    {
        IModel GetValue(string textFrom, string Lang);
        void AddValue(Tuple<string, string, Translate> t);
        void GetList(string filename);
        void SaveList(string filename);
    }
}
