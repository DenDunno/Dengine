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
        };
    }

    public void TryExecute(string command)
    {
        if (_commands.ContainsKey(command))
        {
            _commands[command]();
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