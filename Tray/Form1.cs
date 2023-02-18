using System.Globalization;
using System.Numerics;
using System.Runtime.InteropServices;
using RawInput;

namespace Tray
{
    public partial class Form1 : Form
    {
        private readonly List<CultureInfo> _cultures;

        private readonly RawInput.RawInput _rawinput;

        public Form1()
        {
            InitializeComponent();
            _cultures = new List<CultureInfo>();
            _rawinput = new RawInput.RawInput(Handle);
        }

        protected override void WndProc(ref Message message)
        {
            switch (message.Msg)
            {
                case (int)RawInput.User32.WM_INPUT:
                    {
                        _rawinput.ProcessRawInput(message.LParam);
                    }
                    break;
            }

            base.WndProc(ref message);
        }

        #region WinForms stuff

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            _cultures.Clear();
            comboBox1.Items.Clear();
            // Gets the list of installed languages.
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                textBox1.Text += lang.Culture.EnglishName + '\n';
                _cultures.Add(lang.Culture);
                comboBox1.Items.Add(lang.Culture.EnglishName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Gets the default, and current languages.
            textBox2.Text = "Current input language is: " + InputLanguage.DefaultInputLanguage.Culture.EnglishName + '\n';
            textBox2.Text += "Default input language is: " + InputLanguage.CurrentInputLanguage.Culture.EnglishName + '\n';
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            // Changes the current input language to the default, and prints the new current language.
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(_cultures[comboBox1.SelectedIndex]);
        }

        #endregion
    }
}