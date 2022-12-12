using System.Numerics;

public class ControlPanel : Widget
{
    public ControlPanel(Window window) : base("Control panel", window)
    {
    }

    protected override Vector2 Size => new(WindowWidth - UIData.InspectorWidth - UIData.HierarchyWidth, UIData.ControlPanelHeight);
    protected override Vector2 Position => new(UIData.HierarchyWidth, WindowHeight - UIData.ControlPanelHeight);
    
    protected override void OnDraw()
    {
    }
}