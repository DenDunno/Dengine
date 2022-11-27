
public class NullableCollider : ICollider
{
    public bool CheckCollision(ICollider collider) => false;
    public bool CheckCollision(BoxCollider boxCollider) => false;
    public bool CheckCollision(MeshCollider meshCollider) => false;
    public bool CheckCollision(SphereCollider sphereCollider) => false;
}