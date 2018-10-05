using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using YandexTranslator.View;

namespace YandexTranslator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var Model = new Model.Translate();
            var View = new MainForm();
            var Presenter = new Presenter.YandexPresenter(Model, View);
            Application.Run(View);
        }
    }
}
