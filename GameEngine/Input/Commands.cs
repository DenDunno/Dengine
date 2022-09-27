using OpenTK.Graphics.OpenGL;

public class Commands
{
    private readonly Window _window;
    private readonly IReadOnlyDictionary<string, Action> _commands;

    public Commands(Window window)
    {
        _window = window;
        _commands = new Dictionary<string, Action>()
        {
            {"wireframe", EnableWireframeMode},
            {"shaded", EnableShadedMode},
            {"help", ShowCommands},
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

    private void ShowCommands()
    {
        Logger.Show("\n");

        foreach (var command in _commands)
        {
            Logger.Show(command.Key);
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
}