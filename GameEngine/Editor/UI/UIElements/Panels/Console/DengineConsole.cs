using System.Numerics;
using ImGuiNET;

public class DengineConsole : Panel
{
    private static readonly List<Log> _logs = new();
    
    public DengineConsole() : base("Console")
    {
    }

    public static void Log(object value)
    {
        _logs.Add(new Log(value.ToString()!));
    }
    
    public static void LogWarning(object value)
    {
        _logs.Add(new Log(value.ToString()!, new Vector4(246, 243, 76, 255)));
    }

    protected override void OnPanelDraw()
    {
        if (ImGui.Button("Clear logs"))
        {
            _logs.Clear();
        }
         
        foreach (Log log in _logs)
        {
            ImGui.TextDisabled(log.Time);
            ImGui.SameLine();
            ImGui.Dummy(new Vector2(10, 0));
            ImGui.SameLine();
            ImGui.TextColored(log.Color, log.Text);
        }
    }
}