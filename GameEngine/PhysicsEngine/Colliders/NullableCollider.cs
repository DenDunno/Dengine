
public class NullableCollider : Collider
{
    public override bool CheckCollision(BoxCollider boxCollider) => false;

    public override bool CheckCollision(SphereCollider sphereCollider) => false;
}