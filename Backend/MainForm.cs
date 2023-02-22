using System.Diagnostics;
using RawInput;

namespace Backend
{
    public partial class MainForm : Form
    {
        private readonly Backend _backend;

        public MainForm(Backend backend)
        {
            InitializeComponent();
            _backend = backend;
            _backend.RegisterRawInput(Handle);
            PopulateLayoutListBox();
            _backend.NewDeviceFound += PopulateDeviceListBox;
            FormClosing += MainWindow_FormClosing;
        }

        private void PopulateLayoutListBox()
        {
            LayoutListBox.BeginUpdate();
            foreach (var culture in _backend.Cultures)
            {
                LayoutListBox.Items.Add(culture.EnglishName);
            }

            LayoutListBox.EndUpdate();
        }

        private void PopulateDeviceListBox(object? sender, EventArgs e)
        {
            DeviceListBox.BeginUpdate();
            DeviceListBox.Items.Clear();
            foreach (var device in _backend.Devices)
            {
                DeviceListBox.Items.Add(device);
            }
            DeviceListBox.EndUpdate();
        }

        protected override void WndProc(ref Message message)
        {
            switch (message.Msg)
            {
                case User32.WM_INPUT:
                {
                    if (_backend.HandleWmInputEvent(message))
                    {
                        LastDeviceIdLabel.Text = $@"Last device used: {_backend.LastDeviceUsed}";
                    }
                }
                break;
            }

            base.WndProc(ref message);
        }

        #region WinForms stuff
        
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

        private void AddMappingButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteMappingButton_Click(object sender, EventArgs e)
        {

        }
    }
}