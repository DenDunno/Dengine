
public abstract class Collider // Visitor pattern
{
    public bool CheckCollision(Collider collider) => collider.CheckCollision(this);
    
    public abstract bool CheckCollision(BoxCollider boxCollider);
    public abstract bool CheckCollision(SphereCollider sphereCollider);
}