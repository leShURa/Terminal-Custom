using TerminalCustomApp.Commands;
using System.IO;

namespace TerminalCustomApp.Terminal;

internal class Terminal : ITerminal
{
    public string Current_directory { get; set; } = "C:\\Users";
    private CommandHandler commandHandler = new CommandHandler();
    public List<Command> CommandHistory { get; set; } = new List<Command>();
    public Dictionary<string, int> DictionnaryOfCommands { get; set; } = new ()
    {
        { "help", 0 },
        { "exit", 0 },
        { "clear", 0 },
        { "write", 1 },
        { "date", 0 },
        { "time", 0 },
        { "create_file", 2 },
        { "delete_file", 2 },
        { "create_dir", 2 },
        { "delete_dir", 2 },
        { "where", 0 },
        { "cd", 1 },
        { "ls", 0 }
    };
    internal string? ExecuteCommand(Command cmd)
    {
        string command = cmd.Command_text;
        string[] args = cmd.Args;
        
        if (!IsCommandValid(command, args.Length))
            return null;
        
        CommandHistory.Add(cmd);

        switch (command)
        {
            case "help":
                return commandHandler.Help();
            case "exit":
                commandHandler.Exit();
                break;
            case "clear":
                return commandHandler.Clear(); 
            case "write":
                return commandHandler.Write(args[0]);
            case "date":
                return commandHandler.Date();
                case "time":
                return commandHandler.Time();
            case "create_file":
                commandHandler.CreateFile(args[0]);
                return "ok";
            case "delete_file":
                commandHandler.DeleteFile(args[0]);
                return "ok";
            case "create_dir":
                commandHandler.CreateDir(args[0]);
                return "ok";
            case "delete_dir":
                commandHandler.DeleteDir(args[0]);
                return "ok";
            case "where":
                return commandHandler.Where();
            case "cd":
                commandHandler.Cd(args[0]);
                return commandHandler.Where();
                case "ls":
                return commandHandler.ListDir();
            default:
                return null;
        }
        return null;
    }
    public bool IsCommandValid(string command, int argCount)
    {
        if (DictionnaryOfCommands.ContainsKey(command) && DictionnaryOfCommands[command] == argCount)
        {
            return true;
        }
        return false;
    }
}