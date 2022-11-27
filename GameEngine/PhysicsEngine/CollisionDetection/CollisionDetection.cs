using OpenTK.Mathematics;

public static class CollisionDetection
{
    private static readonly GJKAlgorithm _gjkAlgorithm = new();
    
    public static bool CheckCollision(CollisionMesh collisionMeshA, CollisionMesh collisionMeshB)
    {
        return _gjkAlgorithm.CheckCollision(collisionMeshA.Vertices, collisionMeshB.Vertices);
    }

    public static bool CheckCollision(SphereCollider colliderA, SphereCollider colliderB)
    {
        return Vector3.Distance(colliderA.Centre, colliderB.Centre) <= colliderA.Radius + colliderB.Radius;
    }
    
    public static bool CheckCollision(BoxCollider collider1, SphereCollider colliderB)
    {
        return true;
    }
}