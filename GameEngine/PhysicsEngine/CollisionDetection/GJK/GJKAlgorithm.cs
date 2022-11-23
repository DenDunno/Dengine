using System.Drawing;
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

        DrawGizmo(positionsA, positionsB);
        
        return Vector3.Dot(_origin, Algorithms.GetNormal(_simplex.C - _simplex.B)) < 0 && Vector3.Dot(_origin, Algorithms.GetNormal(_simplex.C - _simplex.A)) < 0;
    }

    private void DrawGizmo(IReadOnlyCollection<Vector3> objectA, IReadOnlyCollection<Vector3> objectB)
    {
        DrawMinDifference(objectA, objectB);
        Gizmo.Instance.DrawLine(_simplex.A, _simplex.B, Color.Red);
        Gizmo.Instance.DrawLine(_simplex.B, _simplex.C, Color.Red);
        Gizmo.Instance.DrawLine(_simplex.C, _simplex.A, Color.Red);
        Gizmo.Instance.DrawPoint(_origin, Color.Aqua);
    }

    private void DrawMinDifference(IReadOnlyCollection<Vector3> objectA, IReadOnlyCollection<Vector3> objectB)
    {
        List<Vector3> minDifference = new();

        for (float angle = 0; angle < 360; angle += 0.005f)
        {
            Vector3 direction =  Quaternion.FromAxisAngle(Vector3.UnitZ, angle) * Vector3.UnitX;
            Vector3 position = GetSupportPoint(direction, objectA, objectB);

            if (minDifference.Contains(position) == false)
            {
                minDifference.Add(position);
            }
        }

        for (int i = 0; i < minDifference.Count; ++i)
        {
            int first = i;
            int second = i + 1 >= minDifference.Count ? 0 : i + 1;
            
            Gizmo.Instance.DrawLine(minDifference[first], minDifference[second], Color.Chartreuse);
        }
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
            float dot = Vector3.Dot(position, direction);
            
            if (dot > maxDot)
            {
                maxDot = dot;
                supportPoint = position;
            }
        }

        return supportPoint;
    }
}