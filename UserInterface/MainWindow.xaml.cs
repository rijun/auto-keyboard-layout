using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Xml.Linq;

namespace UserInterface;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public class MappingEventArgs : EventArgs
    {
        
    }
    public event EventHandler<MappingEventArgs> NewMappingAdded;
        
    public MainWindow()
    {
        InitializeComponent();
    }

    public void UpdateDeviceIdListBox(object? sender, int deviceId)
    {
        DeviceIdListBox.Items.Add(deviceId);
    }

    public void UpdateKeyboardLayoutListBox(List<CultureInfo> cultures)
    {
        KeyboardLayoutListBox.Items.Clear();
        foreach (var culture in cultures)
        {
            KeyboardLayoutListBox.Items.Add(culture.EnglishName);
        }
    }

    private void AddMappingButton_OnClick(object sender, RoutedEventArgs e)
    {
    }
}
