
public class BoxCollider : ICollider
{
    public readonly BoundingBox Box;

    public BoxCollider(Mesh mesh, Transform transform)
    {
        Box = new BoundingBox(mesh, transform);
    }

    public void Init() => Box.Init();
    public bool CheckCollision(ICollider collider) => collider.CheckCollision(this);
    public bool CheckCollision(BoxCollider boxCollider) => CollisionDetection.CheckCollision(Box, boxCollider.Box);
    public bool CheckCollision(MeshCollider meshCollider) => CollisionDetection.CheckCollision(Box, meshCollider.ConvexHull);
    public bool CheckCollision(SphereCollider sphereCollider) => CollisionDetection.CheckCollision(this, sphereCollider);
}