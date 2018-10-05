using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTranslator.Model;


namespace YandexTranslator.Services
{
    class JSON_Save : IFileSaver
    {
        //--------------------------------------------------------------------------------------------------------
        public IEnumerable<Tuple<string, string, Translate>> Load(string filename)
        {

            if (File.Exists(filename))
            {
                var json = File.ReadAllText(filename);
                var list = JsonConvert.DeserializeObject<IEnumerable<Tuple<string, string, Translate>>>(json);
                return list;
            }
            else
            {
                var list = new List<Tuple<string, string, Translate>>();
                return list;
            }
           
        }
        //--------------------------------------------------------------------------------------------------------
        public void Save(IEnumerable<object> Obj, string filename)
        {
            var json = JsonConvert.SerializeObject(Obj);
            File.WriteAllText(filename, json);
        }
        //--------------------------------------------------------------------------------------------------------
    }
}
