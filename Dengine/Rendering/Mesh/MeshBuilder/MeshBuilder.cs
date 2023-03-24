
public static class MeshBuilder
{
    public static Mesh Cube(float size) => BuildMesh(new CubeMeshData(size));
    
    public static Mesh Quad(float size) => BuildMesh(new QuadMeshData(size));
    
    public static Mesh Hexagon(float size) => BuildMesh(new HexagonMeshData(size));
    
    public static Mesh Triangle(float size) => BuildMesh(new TriangleMeshData(size));

    public static Mesh FromObj(string path) => BuildMesh(new MeshFromObj(Paths.GetModel(path)));
    
    public static Mesh Sphere(float radius, uint sectors, uint stacks) => BuildMesh(new SphereMeshData(radius, sectors, stacks));

    private static Mesh BuildMesh(IMeshDataSource meshDataSource) => meshDataSource.Build();
}