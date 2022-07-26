using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class CoordinateSystem : IDrawable
{
    private readonly LineSettings _axis = new(2, 50);
    private readonly LineSettings _mark = new(4, 0.05f);

    void IDrawable.Draw()
    {
        DrawAxis();
            
        DrawMarks(true);
        DrawMarks(false);
    }

    private void DrawAxis()
    {
        GL.LineWidth(_axis.Width);
        GL.Color3(Color.Gray);
        GL.Begin(PrimitiveType.Lines);
        GL.Vertex2(-_axis.Length, 0);
        GL.Vertex2(_axis.Length, 0);
        GL.Vertex2(0, -_axis.Length);
        GL.Vertex2(0, _axis.Length);
        GL.End();
    }

    private void DrawMarks(bool isHorizontal)
    {
        GL.LineWidth(_mark.Width);
        GL.Color3(Color.Orange);
        GL.Begin(PrimitiveType.Lines);
        
        for (float i = -_axis.Length; i <= _axis.Length; ++i)
        {
            if (i == 0)
                continue;

            Vector2 point = isHorizontal ? new Vector2(i, _mark.Length) : new Vector2(_mark.Length, i);

            GL.Vertex2(point.X, point.Y * (isHorizontal ? -1 : 1));
            GL.Vertex2(point.X * (isHorizontal ? 1 : -1), point.Y);
        }
        
        GL.End();
    }
}