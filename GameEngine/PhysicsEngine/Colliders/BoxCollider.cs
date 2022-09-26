
public class BoxCollider : ICollider
{
    private readonly BoundingBox _boundingBox;

    public BoxCollider(BoundingBox boundingBox)
    {
        _boundingBox = boundingBox;
    }

    public bool CheckCollision(ICollider collider) => collider.CheckCollision(this);

    public bool CheckCollision(BoxCollider boxCollider) => CollisionDetection.CheckBoxCollisions(_boundingBox, boxCollider._boundingBox);

    public bool CheckCollision(SphereCollider sphereCollider) => CollisionDetection.CheckBoxSphereCollisions(this, sphereCollider);
}