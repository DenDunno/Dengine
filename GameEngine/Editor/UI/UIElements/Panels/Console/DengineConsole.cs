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

    protected override void OnPanelDraw()
    {
        if (ImGui.Button("Clear logs"))
        {
            _logs.Clear();
        }
         
        foreach (Log log in _logs)
        {
            ImGui.TextDisabled(log.Time.ToString("H:mm:ss"));
            ImGui.SameLine();
            ImGui.Dummy(new Vector2(10, 0));
            ImGui.SameLine();
            ImGui.TextColored(new Vector4(255 / 255f, 167 / 255f, 32 / 255f, 1.00f), log.Text);
        }
    }
}