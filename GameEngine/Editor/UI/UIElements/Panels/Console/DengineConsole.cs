using System.Numerics;
using ImGuiNET;

public class DengineConsole : Panel
{
    private static readonly List<Log> _logs = new();
    
    public DengineConsole() : base("Console")
    {
    }

    public static void Log(string text)
    {
        _logs.Add(new Log(text));
    }

    protected override void OnPanelDraw()
    {
        if (ImGui.Button("Clear logs"))
        {
            _logs.Clear();
        }
        
        foreach (Log log in _logs)
        {
            ImGui.TextDisabled($"{log.Time:H:mm:ss}: "); 
            ImGui.SameLine();
            ImGui.TextColored(new Vector4(255 / 255f, 167 / 255f, 32 / 255f, 1.00f), log.Text);
        }
    }
}