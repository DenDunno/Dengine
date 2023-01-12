using OpenTK.Graphics.OpenGL;

public class RenderData
{
    public Transform Transform { get; set; } = null!;
    public Mesh Mesh { get; init; } = null!;
    public Material Material { get; set; } = null!;
    public BufferUsageHint BufferUsageHint { get; init; } = BufferUsageHint.DynamicDraw;
}