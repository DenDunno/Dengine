using System.Numerics;
using ImGuiNET;

public class DengineConsole : Panel
{
    public static DengineConsole Instance = null!; 
    private static readonly List<Log> _logs = new();
    
    public DengineConsole() : base("Console")
    {
        Instance = this;
    }

    public void Log(object value)
    {
        _logs.Add(new Log(value.ToString()!));
    }
    
    public void LogWarning(object value)
    {
        _logs.Add(new Log(value.ToString()!, new Vector4(246, 243, 76, 255)));
    }
    
    public void LogError(object value)
    {
        _logs.Add(new Log(value.ToString()!, new Vector4(255, 0, 0, 255)));
        SetFocused();
    }

    protected override void OnPanelDraw()
    {
        if (ImGui.Button("Clear logs") || _logs.Count > 10_000)
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