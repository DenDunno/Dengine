using ImGuiNET;

public abstract class WidgetBase : IWidget
{
    private readonly string _name;
    private readonly ImGuiWindowFlags _flags;

    protected WidgetBase(string name, ImGuiWindowFlags flags = ImGuiWindowFlags.None)
    {
        _name = name;
        _flags = flags;
    }

    public virtual void Update(float deltaTime) { }

    public void Draw()
    {
        ImGui.Begin(_name, _flags);

        OnDraw();
        
        ImGui.End();
    }

    protected abstract void OnDraw();
}