using OpenTK.Mathematics;

class BigObjectData
{
    public readonly Vector3 InitialPosition;
    public readonly string Name;
    public readonly Material Material;
    public readonly Mesh Mesh;

    public BigObjectData(Vector3 initialPosition, string name, Mesh mesh, Material material)
    {
        InitialPosition = initialPosition;
        Name = name;
        Material = material;
        Mesh = mesh;
    }
}