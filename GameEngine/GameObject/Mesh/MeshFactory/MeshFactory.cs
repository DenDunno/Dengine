
public static class MeshFactory
{
    public static Mesh Quad(float size) => BuildMesh(new QuadMeshData(size));

    public static Mesh Cube(float size) => BuildMesh(new CubeMeshData(size));

    public static Mesh FromObj(string path) => BuildMesh(new MeshFromObj(path));

    private static Mesh BuildMesh(IMeshDataSource meshDataSource) => new MeshBuilder(meshDataSource).Build();
}