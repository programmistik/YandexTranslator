using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YandexTranslator.Model;

namespace YandexTranslator.Services
{
    public class TranslateAPI
    {
        private const string APIkey = "trnsl.1.1.20181001T045221Z.bc7301da69ddbad5.89c23df283bf7d38569b4eb09c3efabb86bd6870";

        public Translate getTranslate(string textFrom, string Lang)
        {
            using (WebClient web = new WebClient())
            {
                web.Encoding = Encoding.UTF8;
                string url = $"https://translate.yandex.net/api/v1.5/tr.json/translate?key={APIkey}&text={textFrom}&lang={Lang}";
                string json = "";

                try
                {
                    json = web.DownloadString(url);
                }
                catch (WebException ex)
                {
                    throw ex;
                }
                var jsObj = JsonConvert.DeserializeObject<Translate>(json);

                if (jsObj.code != 200)
                    throw new Exception(jsObj.message);

                return jsObj;
            }
        }


        public dynamic getLanguages()
        {
            using (WebClient web = new WebClient())
            {
                try
                {
                    var result = web.DownloadString($"https://translate.yandex.net/api/v1.5/tr.json/getLangs?key={APIkey}&ui=en");
                    dynamic data = JsonConvert.DeserializeObject(result);
                    return data;
                }
                catch (WebException ex)
                {
                    throw ex;
                }

                
            }
        }



    }
}
