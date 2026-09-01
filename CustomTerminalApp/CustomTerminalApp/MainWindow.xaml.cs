using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using TerminalCustomApp.Terminal;
using TerminalCustomApp.Commands;

namespace TerminalCustomApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private TerminalCustomApp.Terminal.Terminal terminal;

    public MainWindow()
    {
        InitializeComponent();
        terminal = new();
        Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object? sender, System.Windows.RoutedEventArgs e)
    {
        if (Terminal != null)
            Terminal.Text = $"{terminal.Current_directory}>> ";
            Terminal.FontSize = 20;
        Terminal.FontFamily = new FontFamily("Consolas");
    }
    private void Input_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key != Key.Enter)
            return;
        
        string input = Terminal.Text;
        string[] command = input.Split(' ');
        string command_text = command[1];
        List<string> args = new();
        for (int i = 2; i < command.Length; i++)
        {
            args.Add(command[i]);
        }
        var cmd = new Command(
                command[1],
                args
            );
        string? result = terminal.ExecuteCommand(cmd);
        Terminal.Text += "\n" + result;
        Terminal.Text += $"\n{terminal.Current_directory}>> ";
        Terminal.CaretIndex = Terminal.Text.Length;
        Terminal.ScrollToEnd();
        Terminal.Focus();

    }
}