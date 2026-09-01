using TerminalCustomApp.Commands;

interface ITerminal
{   
    // private CommandHandler commandHandler;
    List<Command> CommandHistory { get; set;}
    
    bool IsCommandValid(string command, int argCount);
    
}