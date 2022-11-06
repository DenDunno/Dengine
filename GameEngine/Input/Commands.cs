
public class Commands
{
    private readonly IReadOnlyDictionary<string, Action> _commands;

    public Commands(Window window, World world)
    {
        WindowCommands windowCommands = new(window);
        Reflection reflection = new(world);
        GizmoCommands gizmoCommands = new(reflection);
        
        _commands = new Dictionary<string, Action>
        {
            {"wireframe", windowCommands.EnableWireframeMode},
            {"shaded", windowCommands.EnableShadedMode},
            {"show normals", gizmoCommands.ShowNormals},
            {"hide normals", gizmoCommands.HideNormals},
            {"help", ShowCommands},
            {"clear", Console.Clear},
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
        Console.WriteLine();
        
        foreach (KeyValuePair<string, Action> command in _commands)
        {
            Logger.Show(command.Key);
        }
        
        Console.WriteLine();
    }
}