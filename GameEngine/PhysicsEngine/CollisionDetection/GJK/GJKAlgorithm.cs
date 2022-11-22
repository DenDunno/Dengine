using OpenTK.Mathematics;

public class GJKAlgorithm : ICollisionDetection
{
    private readonly Vector3 _origin = Vector3.Zero;
    private readonly Simplex _simplex = new();
        
    public bool CheckCollision(Rigidbody objectA, Rigidbody objectB)
    {
        Vector3 direction = Vector3.UnitX;
        Vector3[] positionsA = objectA.MeshWorldView.Positions;
        Vector3[] positionsB = objectB.MeshWorldView.Positions;
        
        _simplex.A = GetSupportPoint(direction, positionsA, positionsB);
        direction = _origin - _simplex.A;

        Vector3 simplexB = GetSupportPoint(direction, positionsA, positionsB);

        if (Vector3.Dot(simplexB, direction) < 0)
        {
            return false;
        }

        _simplex.B = simplexB;
        direction = Algorithms.GetNormal(_simplex.B - _simplex.A);
            
        _simplex.C = GetSupportPoint(direction, positionsA, positionsB);
            
        return Vector3.Dot(_origin, Algorithms.GetNormal(_simplex.B - _simplex.C)) < 0 && Vector3.Dot(_origin, Algorithms.GetNormal(_simplex.A - _simplex.C)) < 0;
    }

    private Vector3 GetSupportPoint(Vector3 direction, IReadOnlyCollection<Vector3> objectA, IReadOnlyCollection<Vector3> objectB)
    {
        return GetFurthestPoint(direction, objectA) - GetFurthestPoint(-direction, objectB);
    }

    private Vector3 GetFurthestPoint(Vector3 direction, IReadOnlyCollection<Vector3> positions)
    {
        Vector3 supportPoint = Vector3.Zero;
        float maxDot = float.MinValue;
        
        foreach (Vector3 position in positions)
        {
            if (Vector3.Dot(position, direction) > maxDot)
            {
                supportPoint = position;
            }
        }

        return supportPoint;
    }
}