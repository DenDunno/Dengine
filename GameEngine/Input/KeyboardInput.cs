using System.Collections.ObjectModel;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class KeyboardInput
{
    private readonly ReadOnlyDictionary<string, Action> _commands;

    public KeyboardInput(IDictionary<string, Action> commands)
    {
        _commands = new ReadOnlyDictionary<string, Action>(commands);
    }

    public void Listen()
    {
        while (true)
        {
            string commandName = Console.ReadLine()!.ToLower();
            
            if (_commands.ContainsKey(commandName))
            {
                _commands[commandName]();
            }
        }
    }
}