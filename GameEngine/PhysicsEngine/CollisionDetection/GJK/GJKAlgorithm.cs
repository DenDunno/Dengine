using OpenTK.Mathematics;

public class GJKAlgorithm : ICollisionDetection
{
    private readonly Simplex _simplex = new();
    private readonly ConvexHullBruteForce _convexHullBruteForce = new();
    
    public bool CheckCollision(Rigidbody objectA, Rigidbody objectB)
    {
        Vector3[] positionsA = objectA.MeshWorldView.Positions;
        Vector3[] positionsB = objectB.MeshWorldView.Positions;
        Vector3 direction = Vector3.UnitX;
        Vector3 initPoint = GetSupportPoint(direction, positionsA, positionsB);
        
        _simplex.Clear();
        _simplex.Add(initPoint);
        direction = initPoint.Negated();
        
        _convexHullBruteForce.DrawSupportPoints(positionsA, positionsB);
         
        while (true)
        {
            Vector3 point = GetSupportPoint(direction, positionsA, positionsB);
            
            if (point.Dot(direction) < 0)       
            {
                return false;
            }

            _simplex.Add(point);
            
            if (_simplex.Contains(ref direction))
            {
                _simplex.Draw();
                return true;
            }
        }   
    }

    private Vector3 GetSupportPoint(Vector3 direction, IReadOnlyList<Vector3> objectA, IReadOnlyList<Vector3> objectB)
    {
        return GetFurthestPoint(direction, objectA) - GetFurthestPoint(-direction, objectB);
    }

    private Vector3 GetFurthestPoint(Vector3 direction, IReadOnlyList<Vector3> positions)
    {
        Vector3 furthestPoint = Vector3.Zero;
        float maxDot = float.MinValue;

        for (int i = 0; i < positions.Count; ++i)
        {
            float dot = Vector3.Dot(positions[i], direction);
            
            if (dot > maxDot)
            {
                maxDot = dot;
                furthestPoint = positions[i];
            }
        }

        return furthestPoint;
    }
}