using OpenTK.Mathematics;

public class Mesh
{
    public IReadOnlyCollection<int> Indices { get; init; } = Array.Empty<int>();
    public IReadOnlyCollection<Vector3> Points { get; init; } = Array.Empty<Vector3>();
}