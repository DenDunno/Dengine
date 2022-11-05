using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

// Debugging rendering tool
public class Gizmo : IModel
{
    public static Gizmo Instance;
    private readonly List<List<Vector2>> _linesToRenderPool = new();
    
    public Gizmo()
    {
        Instance = this;
    }

    public void AddLineToDraw(List<Vector2> line)
    {
        _linesToRenderPool.Add(line);
    }
    
    public void Initialize()
    {
    }

    void IModel.Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
        GL.UseProgram(0);
        GL.Color3(Color.Aqua);
        GL.LineWidth(5);
        
        foreach (List<Vector2> line in _linesToRenderPool)
        {
            GL.Begin(PrimitiveType.Lines);
            
            foreach (Vector2 linePoint in line)
            {
                GL.Vertex2(linePoint);
            }

            GL.End();
        }
        
        _linesToRenderPool.Clear();
    }
}