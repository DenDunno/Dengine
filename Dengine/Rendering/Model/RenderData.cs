using OpenTK.Graphics.OpenGL;

public class RenderData
{
    [EditorField] public readonly bool Visible = true;
    [EditorField] public required Material Material = null!;
    public Transform Transform { get; init; } = new();
    public Mesh Mesh { get; init; } = null!;
    public BufferUsageHint VertexBufferUsage { get; init; } = BufferUsageHint.StaticDraw;
    public BufferUsageHint IndexBufferUsage { get; init; } = BufferUsageHint.StaticDraw;
    public GLDrawCommand DrawCommand { get; init; } = new DrawElements();
}