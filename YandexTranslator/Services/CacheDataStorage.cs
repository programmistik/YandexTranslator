using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTranslator.Model;

namespace YandexTranslator.Services
{
    class CacheDataStorage : ICacheDataStorage
    {
        IEnumerable<Tuple<string, string, Translate>> Translations = new List<Tuple<string, string, Translate>>();
        public IFileSaver Saver { get; set; } = new JSON_Save();
        

        public void GetList(string filename)
        {
            List<Tuple<string, string, Translate>> tr = Saver.Load(filename).ToList();
            Translations = tr;
        }

        public void SaveList(string filename)
        {
            Saver.Save(Translations, filename);
        }

        public IModel GetValue(string textFrom, string Lang)
        {
            var FromCache = Translations.Where(t => t.Item1 == textFrom)
                                        .Where(t => t.Item2 == Lang).ToList();
            if (FromCache.Count > 0)
            {
                return FromCache[0].Item3;
            }
            return null;
        }

        public void AddValue(Tuple<string, string, Translate> t)
        {
            var FromCache = Translations.Where(tr => tr.Item1 == t.Item1)
                                        .Where(tr => tr.Item2 == t.Item2).ToList();
            if (FromCache.Count == 0)
            {
                var trList = Translations.ToList();
                trList.Add(t);
                Translations = trList;
            }
        }

    }
}
