using OpenTK.Graphics.OpenGL4;

public class RenderData
{
    public Transform Transform { get; init; } = null!;
    public Mesh Mesh { get; init; } = null!;
    public ShaderProgram ShaderProgram { get; init; } = null!;
    public BufferUsageHint BufferUsageHint { get; init; }
}