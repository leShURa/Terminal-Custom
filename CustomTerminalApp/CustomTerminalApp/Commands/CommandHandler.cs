using System.Runtime.CompilerServices;
using System.IO;
using System.Text;

namespace TerminalCustomApp.Commands;

class CommandHandler
{
    internal Func<string> Help = () => "Available commands: \n=>help, \n=>exit, \n=>clear, \n=>write <text>, \n=>date, \n=>time, \n=>create_file <path>, \n=>delete_file <path>, \n=>create_dir <path>, \n=>delete_dir <path>, \n=>where, \n=>cd <path>, \n=>ls\n";

    internal Func<string> ListDir = () =>
    {
        StringBuilder sb = new StringBuilder();
        foreach (var d in Directory.GetDirectories(".")) 
            sb.Append($"\n<dir> {d}");
        foreach (var f in Directory.GetFiles("."))
            sb.Append($"\n<file> {f}");
        sb.Append(Environment.NewLine);
        return sb.ToString();
    };
    internal Func<string, string> Write = (text) => text;
    internal Func<string> Date = () => DateTime.Now.ToString("yyyy-MM-dd");
    internal Func<string> Time = () => DateTime.Now.ToString("HH:mm:ss");
    internal Func<string> Where = () => Directory.GetCurrentDirectory();
    internal Action<string> CreateFile = (path) => File.Create(path).Close();
    internal Action<string> DeleteFile = (path) => File.Delete(path);
    internal Action<string> CreateDir = (path) => Directory.CreateDirectory(path);
    internal Func<string, string> Cd = (path) =>
    {
        if (path == "..")
            Directory.SetCurrentDirectory(Directory.GetParent(Directory.GetCurrentDirectory()).FullName);
        else
            Directory.SetCurrentDirectory(path);
        return Directory.GetCurrentDirectory();
    };
    internal Action Exit = () => Environment.Exit(0);
    internal Action<string> DeleteDir = (path) => Directory.Delete(path, recursive: true);
}