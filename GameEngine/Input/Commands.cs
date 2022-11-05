using OpenTK.Graphics.OpenGL;

public class Commands
{
    private readonly Window _window;
    private readonly IReadOnlyDictionary<string, Action> _commands;

    public Commands(Window window)
    {
        _window = window;
        _commands = new Dictionary<string, Action>
        {
            {"wireframe", EnableWireframeMode},
            {"shaded", EnableShadedMode},
            {"help", ShowCommands},
            {"clear", ClearConsole},
        };
    }

    public void TryExecute(string command)
    {
        if (_commands.ContainsKey(command))
        {
            _commands[command]();
        }
        else
        {
            Logger.ShowError("Wrong command");
            ShowCommands();
        }
    }

    private void EnableWireframeMode()
    {
        _window.SetPolygonMode(PolygonMode.Line);
    }

    private void EnableShadedMode()
    {
        _window.SetPolygonMode(PolygonMode.Fill);
    }

    private void ShowCommands()
    {
        Console.WriteLine();
        
        foreach (KeyValuePair<string, Action> command in _commands)
        {
            Logger.Show(command.Key);
        }
        
        Console.WriteLine();
    }

    private void ClearConsole()
    {
        Console.Clear();
    }
}