using System.Diagnostics;
using RawInput;

namespace Backend
{
    public partial class MainForm : Form
    {
        private readonly Backend _backend;

        public MainForm(Backend backend)
        {
            _backend = backend;
            FormClosing += MainWindow_FormClosing;
            InitializeComponent();
        }

        protected override void WndProc(ref Message message)
        {
            switch (message.Msg)
            {
                case User32.WM_INPUT:
                {
                    /*if (_rawinput.ProcessRawInput(message.LParam, out var deviceId))
                    {
                        ProcessKeyboardPressed(deviceId);
                    }*/
                }
                break;
            }

            base.WndProc(ref message);
        }

        private void ProcessKeyboardPressed(int deviceId)
        {
            throw new NotImplementedException();
        }

        #region WinForms stuff

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Items.Clear();
            // Gets the list of installed languages.
            foreach (var culture in _backend.Cultures)
            {
                textBox1.Text += culture.EnglishName + '\n';
                comboBox1.Items.Add(culture.EnglishName);
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
            // InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(_cultures[comboBox1.SelectedIndex]);
        }
        
        /// <summary>
        /// Event handler for the FormClosing event.
        /// If the user closes the window through the UI, hide the window instead of closing it.
        /// </summary>
        private void MainWindow_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Hide();
        }

        #endregion
    }
}