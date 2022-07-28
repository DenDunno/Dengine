
using OpenTK.Graphics.OpenGL;

public class UpdateCycle : IUpdatable
{
    private readonly World _world;

    public UpdateCycle(World world)
    {
        _world = world;
    }

    public void Update(float deltaTime)
    {
        _world.Update(deltaTime);
        _world.Draw();
        
        GL.Begin(PrimitiveType.Polygon);
        GL.Color3(1.0f, 0.0f, 0.0f); 
        GL.Vertex3(-1.0f-2, -1.0f, 0);
 
        GL.Color3(0.0f, 1.0f, 0.0f);
        GL.Vertex3(1.0f-2, -1.0f, 0);
 
        GL.Color3(0.0f, 0.0f, 1.0f);
        GL.Vertex3(0.0f-2, 1.0f, 0);
        GL.End();
    }
}