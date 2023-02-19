using System.ComponentModel;
using System.Diagnostics;

namespace Tray
{
    internal class CustomApplicationContext : ApplicationContext
    {
        private const string IconFileName = "../../../assets/icon.ico";
        private const string DefaultTooltip = "Route HOST entries via context menu";

        private readonly IContainer? _components;
        private readonly NotifyIcon _notifyIcon;

        public CustomApplicationContext()
        {
            // Create new notify icon
            _components = new Container();
            _notifyIcon = new NotifyIcon(_components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = new Icon(IconFileName),
                Text = DefaultTooltip,
                Visible = true
            };

            _notifyIcon.ContextMenuStrip.Items.Add("&Exit", null, (_, _) => ExitThread());

            _notifyIcon.DoubleClick += (_, _) => ShowMainForm();
        }

        private MainForm? _mainForm;
        
        private void ShowMainForm()
        {
            if (_mainForm == null)
            {
                _mainForm = new MainForm();
                _mainForm.Closed += (_, _) => _mainForm = null;
                _mainForm.Show();
            }
            else
            {
                _mainForm.Activate();
            }
        }

        protected override void Dispose(bool disposing)
        {
            Debug.WriteLine("Firing dispose");
            if (disposing && _components != null) { _components.Dispose(); }
        }

        protected override void ExitThreadCore()
        {
            Debug.WriteLine("Firing ExitThreadCore");
            // if (mainForm != null) { MainWindow.Close(); }
            _notifyIcon.Visible = false; // should remove lingering tray icon!
            base.ExitThreadCore();
        }
    }
}
