
public class RenderData
{
    public Transform Transform;
    public Mesh Mesh;
    public AttributePointer[] AttributePointers;
    public ShaderProgram ShaderProgram;

    public RenderData(Transform transform, Mesh mesh, AttributePointer[] attributePointers, ShaderProgram shaderProgram)
    {
        Transform = transform;
        Mesh = mesh;
        AttributePointers = attributePointers;
        ShaderProgram = shaderProgram;
    }
}