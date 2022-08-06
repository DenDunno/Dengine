
public class RenderData
{
    public Transform Transform { get; init; } = null!;
    public Mesh Mesh { get; init; } = null!;
    public AttributePointer[] AttributePointers { get; init; } = null!;
    public ShaderProgram ShaderProgram { get; init; } = null!;
}