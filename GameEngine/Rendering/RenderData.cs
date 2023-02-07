using OpenTK.Graphics.OpenGL;

public class RenderData
{
    public required Transform Transform { get; init; } = null!;
    public required Material Material { get; init; } = null!;
    public Mesh Mesh { get; set; } = null!;
    public BufferUsageHint VertexBufferUsage { get; init; } = BufferUsageHint.StaticDraw;
    public BufferUsageHint IndexBufferUsage { get; init; } = BufferUsageHint.StaticDraw;
    public CullFaceMode CullingMode { get; init; } = CullFaceMode.Front;
    public GLDrawCommand DrawCommand { get; init; } = new DrawElements();
}