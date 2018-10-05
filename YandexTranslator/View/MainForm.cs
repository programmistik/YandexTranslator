using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YandexTranslator.Model;
using YandexTranslator.Services;

namespace YandexTranslator.View
{
    
    public partial class MainForm : Form, IView
    {
        public TranslateAPI API { get; set; } = new TranslateAPI();
        string filename = "TanslationList.json";

        public event Func<string, string, string, string> TranslateText;
        public event Func<dynamic> getLangList;
        public event Action<string> LoadTranslations;
        public event Action<string> SaveTranslations;

        public MainForm()
        {
            InitializeComponent();

        }

        private void buttonTranslate_Click(object sender, EventArgs e)
        {
            string lang1 = null;
            string lang2 = null;

            if (LangFrom.SelectedItem is Language)
                if (LangFrom.ToString() != "Autodetect")
                    lang1 = (LangFrom.SelectedItem as Language).Code;

            if (LangTo.SelectedItem is Language)
                lang2 = (LangTo.SelectedItem as Language).Code;

            try
            {
                richTextBoxTo.Text = TranslateText?.Invoke(richTextBoxFrom.Text,lang1, lang2);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonChangeLang_Click(object sender, EventArgs e)
        {
            int index = LangTo.SelectedIndex;
            if (LangFrom.SelectedIndex == -1)
                LangTo.SelectedIndex = -1;
            else
                LangTo.SelectedIndex = LangFrom.SelectedIndex - 1;
            LangFrom.SelectedIndex = index + 1;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTranslations?.Invoke(filename);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTranslations?.Invoke(filename);

            LangFrom.Items.Add("Autodetect");

            dynamic data = getLangList?.Invoke();


            foreach (var item in data.langs)
            {
                LangFrom.Items.Add(new Language
                {
                    Code = item.Name,
                    FullName = item.Value.Value
                });
                LangTo.Items.Add(new Language
                {
                    Code = item.Name,
                    FullName = item.Value.Value
                });
            }

        }
    }
}
