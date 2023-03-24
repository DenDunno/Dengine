
public static class MeshExtensions
{
    public static void PushID(this Mesh mesh, string name, int index, int id)
    {
        float[] data = Enumerable.Repeat<float>(id, mesh.VerticesCount).ToArray();
        
        mesh.PushAttribute(new VertexAttribute(name, index, 1, data));
    }
}