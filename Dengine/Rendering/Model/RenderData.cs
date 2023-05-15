
public class RenderData
{
    [EditorField] public readonly bool Visible = true;
    [EditorField] public readonly Material Material;
    public readonly VertexArrayObject VertexArrayObject;
    public readonly GLDrawCommand DrawCommand;
    public Transform Transform { get; set; } = new(); // "set" for material caching

    public RenderData(Mesh mesh, Material material) : this(new StaticMesh(mesh), material, new DrawElements())
    {
    }
    
    public RenderData(IMeshProvider meshProvider, Material material) : this(meshProvider, material, new DrawElements())
    {
    }
    
    public RenderData(Mesh mesh, Material material, GLDrawCommand drawCommand) : this(new StaticMesh(mesh), material, drawCommand)
    {
    }
    
    public RenderData(IMeshProvider meshProvider, Material material, GLDrawCommand drawCommand)
    {
        Material = material;
        DrawCommand = drawCommand;
        VertexArrayObject = new VertexArrayObject(meshProvider);
        DrawCommand.SetMeshProvider(meshProvider);
    }
}