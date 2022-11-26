
public class BoxCollider : Collider
{
    private readonly BoundingBox _boundingBox;

    public BoxCollider(BoundingBox boundingBox)
    {
        _boundingBox = boundingBox;
    }

    public override bool CheckCollision(BoxCollider boxCollider)
    {
        return CollisionDetection.CheckBoxCollisions(_boundingBox, boxCollider._boundingBox);
    }

    public override bool CheckCollision(SphereCollider sphereCollider)
    {
        return CollisionDetection.CheckBoxSphereCollisions(this, sphereCollider);
    }
}