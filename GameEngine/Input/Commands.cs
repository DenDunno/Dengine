using System.Collections.ObjectModel;

public class Commands
{
    private readonly ReadOnlyDictionary<string, Action> _commands;

    public Commands(IDictionary<string, Action> commands)
    {
        _commands = new ReadOnlyDictionary<string, Action>(commands);
    }

    public void Listen()
    {
        Task.Run(() =>
        {
            while (true)
            {
                string commandName = Console.ReadLine()!.ToLower();

                if (_commands.ContainsKey(commandName))
                {
                    _commands[commandName]();
                }
            }
        });
    }
}