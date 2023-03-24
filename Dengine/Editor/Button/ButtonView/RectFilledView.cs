using System.Drawing;
using System.Numerics;
using ImGuiNET;

public class RectFilledView : ButtonView
{
    public RectFilledView(float size, Color color, string name) : base(size, color, name)
    {
    }

    protected override void OnDraw(Vector2 rectMin, Vector2 rectMax, ImDrawListPtr drawList)
    {
        drawList.AddRect(rectMin, rectMax, Color, 0, ImDrawFlags.None, 4f);
    }
}