
public class MeshCollider : ICollider
{
    public readonly ConvexHull ConvexHull;
    
    public MeshCollider(Mesh mesh, Transform transform)
    {
        ConvexHull = new ConvexHull(mesh, transform);
    }

    public void Init() => ConvexHull.Init();
    public bool CheckCollision(ICollider collider) => collider.CheckCollision(this);
    public bool CheckCollision(BoxCollider boxCollider) => CollisionDetection.CheckCollision(boxCollider.Box, ConvexHull);
    public bool CheckCollision(MeshCollider meshCollider) => CollisionDetection.CheckCollision(meshCollider.ConvexHull, ConvexHull);
    public bool CheckCollision(SphereCollider sphereCollider) => false;
}