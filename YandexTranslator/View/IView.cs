using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YandexTranslator.View
{
    public interface IView
    {
        event Func<string, string, string, string> TranslateText;
        event Func<dynamic> getLangList;
        event Action<string> LoadTranslations;
        event Action<string> SaveTranslations;
    }
}
