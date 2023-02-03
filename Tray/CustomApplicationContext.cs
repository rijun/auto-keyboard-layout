using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Tray
{
    internal class CustomApplicationContext : ApplicationContext
    {
        private const string IconFileName = "../../../assets/icon.ico";
        private static readonly string DefaultTooltip = "Route HOST entries via context menu";

        private System.ComponentModel.IContainer _components;	// a list of components to dispose when the context is disposed
        private NotifyIcon notifyIcon;				            // the icon that sits in the system tray

        public CustomApplicationContext()
        {
            _components = new System.ComponentModel.Container();
            notifyIcon = new NotifyIcon(_components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon = new Icon(IconFileName),
                Text = DefaultTooltip,
                Visible = true
            };
            notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            notifyIcon.DoubleClick += notifyIcon_DoubleClick;
        }


        private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
            //hostManager.BuildServerAssociations();
            //hostManager.BuildContextMenu(notifyIcon.ContextMenuStrip);
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            //notifyIcon.ContextMenuStrip.Items.Add(hostManager.ToolStripMenuItemWithHandler("Show &Details", showDetailsItem_Click));
            //notifyIcon.ContextMenuStrip.Items.Add(hostManager.ToolStripMenuItemWithHandler("&Help/About", showHelpItem_Click));
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            //notifyIcon.ContextMenuStrip.Items.Add(hostManager.ToolStripMenuItemWithHandler("&Exit", exitItem_Click));
            (bool result, IntPtr language) = WinUser.GetKeyboardLayout();
            if (!result)
            {
                Debug.WriteLine("constructor fired");
            }
            else
            {
                Debug.WriteLine(language.ToString());
            }
        }

    private void notifyIcon_DoubleClick(object sender, EventArgs e)
    {

    }
        /*
        private System.Windows.Window introForm;
        
        private void ShowIntroForm()
        {
            if (introForm == null)
            {
                introForm = new WpfFormLibrary.IntroForm();
                introForm.Closed += mainForm_Closed;
                ElementHost.EnableModelessKeyboardInterop(introForm);
                introForm.Show();
            }
            else { introForm.Activate(); }
        }*/
    }
}
