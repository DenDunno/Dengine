using System.Drawing;
using System.Numerics;
using ImGuiNET;

public class NGonView : ButtonView
{
    private readonly int _segments;
    private readonly float _radius;
    
    public NGonView(float size, Color color, int segments, string name) : base(size, color, name)
    {
        _segments = segments;
        _radius = size / 2f;
    }

    protected override void OnDraw(Vector2 rectMin, Vector2 rectMax, ImDrawListPtr drawList)
    {
        Vector2 size = rectMax - rectMin;
        Vector2 position = new(rectMin.X + size.X * 0.37f, rectMin.Y + size.Y * 0.5f);
        
        drawList.AddNgon(position, _radius, Color, _segments, 4f);
    }
}