using ImGuiNET;

public abstract class Panel : UIElement
{
    public readonly string Name;
    private readonly ImGuiWindowFlags _flags;

    protected Panel(string name, ImGuiWindowFlags flags = ImGuiWindowFlags.None)
    {
        Name = name;
        _flags = flags;
    }

    protected override void OnDraw()
    {
        ImGui.Begin(Name, _flags);

        OnPanelDraw();
        
        ImGui.End();
    }

    protected abstract void OnPanelDraw();
}