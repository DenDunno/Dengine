
public readonly struct MeshFaces
{
    private readonly IReadOnlyList<Polygon> _polygons;

    public MeshFaces(IReadOnlyList<Polygon> polygons)
    {
        _polygons = polygons;
    }
    
    public Polygon this[int index] => _polygons[index];
}