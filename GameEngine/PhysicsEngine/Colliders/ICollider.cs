
public interface ICollider // Visitor pattern
{
    bool CheckCollision(ICollider collider);
    bool CheckCollision(BoxCollider boxCollider);
    bool CheckCollision(MeshCollider meshCollider);
    bool CheckCollision(SphereCollider sphereCollider);
    
    public void Init() {}
}