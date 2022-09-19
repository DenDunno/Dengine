
public class BoxCollider 
{
    private readonly BoundingBox _boundingBox;

    public BoxCollider(BoundingBox boundingBox)
    {
        _boundingBox = boundingBox;
    }

    public bool CheckCollision(BoxCollider boxCollider)
    {
        return _boundingBox.Max.X > boxCollider._boundingBox.Min.X && _boundingBox.Min.X < boxCollider._boundingBox.Max.X &&
               _boundingBox.Max.Y > boxCollider._boundingBox.Min.Y && _boundingBox.Min.Y < boxCollider._boundingBox.Max.Y &&
               _boundingBox.Max.Z > boxCollider._boundingBox.Min.Z && _boundingBox.Min.Z < boxCollider._boundingBox.Max.Z;
    }
}