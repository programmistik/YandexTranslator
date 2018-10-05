using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YandexTranslator.Model;
using YandexTranslator.Services;
using YandexTranslator.View;

namespace YandexTranslator.Presenter
{
    class YandexPresenter
    {
        IView View;
        IModel Model;

        public ICacheDataStorage Storage { get; set; } = new CacheDataStorage();
        public IFileSaver Saver { get; set; } = new JSON_Save();
        public TranslateAPI API { get; set; } = new TranslateAPI();


        public YandexPresenter(IModel Model, IView View)
        {
            this.Model = Model;
            this.View = View;

            View.TranslateText += TranslateText;
            View.getLangList += getLangList;
            View.LoadTranslations += LoadTranslations;
            View.SaveTranslations += SaveTranslations;
        }

        public string TranslateText(string textFrom, string LangFrom, string LangTo)
        {
            if (String.IsNullOrWhiteSpace(textFrom))
                throw new Exception("No text to translate.");

            if (String.IsNullOrWhiteSpace(LangTo))
                throw new Exception("Translate language is not specified.");

            string lang;
            if (String.IsNullOrWhiteSpace(LangFrom))
                lang = LangTo;
            else
                lang = LangFrom + "-" + LangTo;


            string text = null;
            // search in cache

            if (lang.Contains("-")) // при автоопределении языка искать в кеше нет смысла
                if (Storage.GetValue(textFrom, lang) is IModel)
                {
                    text = (Storage.GetValue(textFrom, lang) as IModel).GetTranslation();
                    return text;
                }

            try
            {
                var tr = API.getTranslate(textFrom, lang);
                Storage.AddValue(new Tuple<string, string, Translate>(textFrom, lang, tr));
                text = tr.GetTranslation();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return text;

        }

        public dynamic getLangList()
        {
            return API.getLanguages();
        }

        public void LoadTranslations(string filename)
        {
            Storage.GetList(filename);
        }

        public void SaveTranslations(string filename) => Storage.SaveList(filename);
       

    }
}
