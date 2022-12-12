using System.Numerics;
using ImGuiNET;

public abstract class Widget
{
    private readonly string _name;
    private readonly Window _window;

    protected Widget(string name, Window window)
    {
        _name = name;
        _window = window;
    }

    protected float WindowWidth => _window.Size.X;
    protected float WindowHeight => _window.Size.Y;
    
    protected abstract Vector2 Size { get; }
    protected abstract Vector2 Position { get; }

    public void Draw()
    {
        ImGui.Begin(_name, ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize);
        ImGui.SetWindowPos(Position);
        ImGui.SetWindowSize(Size);

        OnDraw();
        
        ImGui.End();
    }

    protected abstract void OnDraw();
}