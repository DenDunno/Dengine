using System.Drawing;
using System.Numerics;
using ImGuiNET;

public abstract class ButtonView : UIElement
{
    private readonly float _size;
    private readonly string _name;
    protected readonly uint Color;

    protected ButtonView(float size, Color color, string name)
    {
        _size = size;
        _name = name;
        Color = color.ToUint();
    }
    
    public bool WasClicked { get; private set; }

    protected override void OnDraw()
    {
        ImGui.SetCursorPosX((ImGui.GetWindowSize().X - _size) * 0.5f);
        ImGui.SetCursorPosY(40f);
        
        WasClicked = ImGui.InvisibleButton(_name, Vector2.One * _size);
        
        Vector2 rectMin = ImGui.GetItemRectMin();
        Vector2 rectMax = ImGui.GetItemRectMax();
        ImDrawListPtr drawList = ImGui.GetWindowDrawList();

        OnDraw(rectMin, rectMax, drawList);
        
        drawList.PushClipRect(rectMin, rectMax);
        drawList.PopClipRect();
    }

    protected abstract void OnDraw(Vector2 rectMin, Vector2 rectMax, ImDrawListPtr drawList);
}