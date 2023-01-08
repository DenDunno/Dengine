using ImGuiNET;

public class DengineConsole : Panel
{
    private static readonly List<string> _logs = new();
    
    public DengineConsole() : base("Console")
    {
    }

    public static void Log(string text)
    {
        _logs.Add(text);
    }

    protected override void OnPanelDraw()
    {
        if (ImGui.Button("Clear logs"))
        {
            _logs.Clear();
        }
        
        foreach (string log in _logs)
        {
            ImGui.Text(log);
        }
    }
}