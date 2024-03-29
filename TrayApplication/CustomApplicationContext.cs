﻿using System.ComponentModel;
using UserInterface;

namespace TrayApplication;

internal class CustomApplicationContext : ApplicationContext
{
    private const string IconFileName = "../../../Resources/TrayIcon.ico";
    private const string DefaultTooltip = "AutoKeyboardLayout";

    private readonly IContainer? _components;
    private readonly NotifyIcon _notifyIcon;
    private Backend _backend;
    private MainWindow _ui;

    // private readonly MainWindow _userInterface;

    public CustomApplicationContext()
    {
        _backend = new();

        // Create new notify icon
        _components = new Container();
        _notifyIcon = new(_components)
        {
            ContextMenuStrip = new ContextMenuStrip(),
            Icon = new Icon(IconFileName),
            Text = DefaultTooltip,
            Visible = true
        };

        // Add call to terminate the ApplicationContext when selecting the exit option
        _notifyIcon.ContextMenuStrip.Items.Add("&Exit", null, (_, _) => ExitThread());
        _notifyIcon.DoubleClick += (_, _) => ShowMainForm();

        _ui= new MainWindow();
        _ui.UpdateKeyboardLayoutListBox(_backend.Cultures);
        _ui.Show();
        
        _backend.NewDeviceFound += _ui.UpdateDeviceIdListBox;
    }
    
    private void ShowMainForm()
    {
        // _mainForm.Show();
        // _mainForm.Activate();
        // _userInterface.Show();
    }

    #region Generic code framework

    /// <summary>
    /// When the application context is disposed, dispose things like the notify icon.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing && _components != null) { _components.Dispose(); }
    }

    /// <summary>
    /// If a form is showing, clean it up.
    /// </summary>
    protected override void ExitThreadCore()
    {
        // _mainForm.Close(); // Clean up form
        // _userInterface.Close();
        _notifyIcon.Visible = false; // Remove lingering tray icon
        base.ExitThreadCore();
    }
    
    #endregion
}
