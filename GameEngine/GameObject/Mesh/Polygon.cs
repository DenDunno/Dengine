
public readonly struct Polygon
{
    public readonly MeshVertex FirstVertex;
    public readonly MeshVertex SecondVertex;
    public readonly MeshVertex ThirdVertex;

    public Polygon(MeshVertex[] polygon)
    {
        FirstVertex = polygon[0];
        SecondVertex = polygon[1];
        ThirdVertex = polygon[2];
    }
}