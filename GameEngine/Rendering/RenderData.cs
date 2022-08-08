
public class RenderData
{
    public readonly Transform Transform;
    public readonly Mesh Mesh;
    public readonly AttributePointer[] AttributePointers;
    public readonly ShaderProgram ShaderProgram;

    public RenderData(Transform transform, Mesh mesh, AttributePointer[] attributePointers, ShaderProgram shaderProgram)
    {
        Transform = transform;
        Mesh = mesh;
        AttributePointers = attributePointers;
        ShaderProgram = shaderProgram;
    }
}