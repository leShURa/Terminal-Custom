using System.Runtime.CompilerServices;
using System.IO;

namespace TerminalCustomApp.Commands;

class CommandHandler
{
    internal Func<string> Help = () => "Available commands: help, exit, clear, write <text>, date";
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