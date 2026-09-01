namespace TerminalCustomApp.Commands;

class Command
{
    internal int Arg_count { get; set; }
    internal string Command_text { get; set; }
    internal string[] Args { get; set; }
    
    public Command(string command_text, List<string> args)
    {
        Command_text = command_text;
        Args = args.ToArray();
        Arg_count = args.Count;
    }
}
