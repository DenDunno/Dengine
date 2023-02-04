using OpenTK.Graphics.OpenGL;

public class RenderData
{
    public required Transform Transform { get; init; } = null!;
    public required Mesh Mesh { get; set; } = null!;
    public required Material Material { get; init; } = null!;
    public BufferUsageHint VertexBufferUsage { get; init; } = BufferUsageHint.StaticDraw;
    public BufferUsageHint IndexBufferUsage { get; init; } = BufferUsageHint.StaticDraw;
}