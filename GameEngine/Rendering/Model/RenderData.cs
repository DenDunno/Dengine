using OpenTK.Graphics.OpenGL;

public class RenderData
{
    [EditorField] public readonly bool Visible = true;
    [EditorField] public required Material Material = null!;
    public Transform Transform { get; set; } = new();
    public Mesh Mesh { get; set; } = null!;
    public BufferUsageHint VertexBufferUsage { get; init; } = BufferUsageHint.StaticDraw;
    public BufferUsageHint IndexBufferUsage { get; init; } = BufferUsageHint.StaticDraw;
    public GLDrawCommand DrawCommand { get; init; } = new DrawElements();
}