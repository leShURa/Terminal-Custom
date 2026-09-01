using System.Runtime.CompilerServices;
using System.IO;

namespace TerminalCustomApp.Commands;

class CommandHandler
{
    internal Func<string> Help = () => "Available commands: \n=>help, \n=>exit, \n=>clear, \n=>write <text>, \n=>date, \n=>time, \n=>create_file <path>, \n=>delete_file <path>, \n=>create_dir <path>, \n=>delete_dir <path>, \n=>where, \n=>cd <path>, \n=>ls";
    internal Func<string> Clear = () => "";
    internal Func<string> ListDir = () => string.Join("\n", Directory.GetDirectories("."));
    internal Func<string, string> Write = (text) => text;
    internal Func<string> Date = () => DateTime.Now.ToString("yyyy-MM-dd");
    internal Func<string> Time = () => DateTime.Now.ToString("HH:mm:ss");
    internal Func<string> Where = () => Directory.GetCurrentDirectory();
    internal Action<string> CreateFile = (path) => File.Create(path).Close();
    internal Action<string> DeleteFile = (path) => File.Delete(path);
    internal Action<string> CreateDir = (path) => Directory.CreateDirectory(path);
    internal Action<string> Cd = (path) => Directory.SetCurrentDirectory(path);
    internal Action Exit = () => Environment.Exit(0);
    internal Action<string> DeleteDir = (path) => Directory.Delete(path);
}