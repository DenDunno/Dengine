
public interface ICollider // Visitor pattern
{
    bool CheckCollision(ICollider collider);
    bool CheckCollision(BoxCollider boxCollider);
    bool CheckCollision(SphereCollider sphereCollider);
}