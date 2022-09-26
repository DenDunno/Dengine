
public class KeyboardInput
{
    private readonly Commands _commands;

    public KeyboardInput(Commands commands)
    {
        _commands = commands;
    }
    
    public void Listen()
    {
        Task.Run(() =>
        {
            while (true)
            {
                string command = Console.ReadLine()!.ToLower();

                _commands.TryExecute(command);
            }
        });
    }
}