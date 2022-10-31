using OpenTK.Mathematics;

public static class Primitives
{
    public static Mesh Quad(float size)
    {
        var positions = new Vector3[]
        {
            new(size, size, 0.0f),
            new(size, -size, 0.0f),
            new(-size, -size, 0.0f),
            new(-size, size, 0.0f),
        };

        var indices = new uint[]
        {
            0, 1, 3,
            1, 2, 3,
        };

        Mesh mesh = new Mesh(positions, indices)
        {
            Normals = new Vector3[]
            {
                new(1, 0, 0),
                new(0, -1, 0),
                new(-1, 0, 0),
                new(0, 1, 0),
            }
        };
        mesh.Init();
        return mesh;
    }
}