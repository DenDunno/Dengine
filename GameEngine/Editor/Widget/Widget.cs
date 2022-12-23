using ImGuiNET;

public abstract class Widget
{
    private readonly string _name;
    private readonly ImGuiWindowFlags _flags;

    protected Widget(string name, ImGuiWindowFlags flags = ImGuiWindowFlags.None)
    {
        _name = name;
        _flags = flags;
    }

    public virtual void Update(float deltaTime) { }
    
    public virtual void PreDraw() {}
    public virtual void AfterDraw() {}

    public void Draw()
    {
        ImGui.Begin(_name, _flags);

        OnDraw();
        
        ImGui.End();
    }

    protected abstract void OnDraw();
}