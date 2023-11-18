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
    public EventHandler thresholdReached;

    public MainWindow()
    {
        InitializeComponent();


        thresholdReached = () => { System.Console.WriteLine($"Notification received for"); };
    }

    public delegate void ThresholdReachedEventHandler(object sender);

    public void UpdateKeyboardLayoutListBox(List<CultureInfo> cultures)
    {
        KeyboardLayoutListBox.Items.Clear();
        foreach (var culture in cultures)
        {
            KeyboardLayoutListBox.Items.Add(culture.EnglishName);
        }
    }
}
