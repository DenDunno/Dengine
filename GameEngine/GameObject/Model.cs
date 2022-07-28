
public class Model 
{
    public readonly Mesh Mesh;
    public readonly Material Material;

    public Model() : this(new Mesh(), new Material())
    {
    }
    
    public Model(Mesh mesh, Material material)
    {
        Mesh = mesh;
        Material = material;
    }
}