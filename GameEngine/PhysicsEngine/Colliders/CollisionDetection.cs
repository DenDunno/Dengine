using OpenTK.Mathematics;

public static class CollisionDetection
{
    public static bool CheckBoxCollisions(BoundingBox boundingBox1, BoundingBox boundingBox2)
    {
        return boundingBox1.Max.X > boundingBox2.Min.X && boundingBox1.Min.X < boundingBox2.Max.X &&
               boundingBox1.Max.Y > boundingBox2.Min.Y && boundingBox1.Min.Y < boundingBox2.Max.Y &&
               boundingBox1.Max.Z > boundingBox2.Min.Z && boundingBox1.Min.Z < boundingBox2.Max.Z;
    }
    
    public static bool CheckSphereCollisions(SphereCollider collider1, SphereCollider collider2)
    {
        return Vector3.Distance(collider1.Centre, collider2.Centre) <= collider1.Radius + collider2.Radius;
    }
    
    public static bool CheckBoxSphereCollisions(BoxCollider collider1, SphereCollider collider2)
    {
        return true;
    }
}