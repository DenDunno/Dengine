using System.Drawing;
using OpenTK.Mathematics;

public class GJKAlgorithm : ICollisionDetection
{
    private readonly Vector3 _origin = Vector3.Zero;
    private readonly Simplex _simplex = new();
        
    public bool CheckCollision(Rigidbody objectA, Rigidbody objectB)
    {
        Vector3[] positionsA = objectA.MeshWorldView.Positions;
        Vector3[] positionsB = objectB.MeshWorldView.Positions;
        Vector3 direction = Vector3.UnitX;

        _simplex.A = GetSupportPoint(direction, positionsA, positionsB);
        direction = _origin - _simplex.A;
        _simplex.B = GetSupportPoint(direction, positionsA, positionsB);

        while (true)
        {
            if (Vector3.Dot(_simplex.B, direction) < 0)
            {
                return false;
            }
        
            direction = Algorithms.GetNormal(_simplex.A - _simplex.B);
            _simplex.C = GetSupportPoint(direction, positionsA, positionsB);

            if (_simplex.IsOriginInside())
            {
                Gizmo.Instance.DrawVector(_origin, _simplex.C, Color.Beige);
                Gizmo.Instance.DrawVector(_simplex.C + Algorithms.GetNormal(_simplex.C - _simplex.B), _simplex.C, Color.Beige);
                Gizmo.Instance.DrawVector(_simplex.C + Algorithms.GetNormal(_simplex.A - _simplex.C), _simplex.C, Color.Beige);
                
                DrawGizmo(positionsA, positionsB);
                return true;
            }

            _simplex.B = _simplex.C;
        }
    }

    private void DrawGizmo(IReadOnlyList<Vector3> objectA, IReadOnlyList<Vector3> objectB)
    {
        Gizmo.Instance.DrawPoint(_simplex.A, Color.Fuchsia);
        Gizmo.Instance.DrawLine(_simplex.A, _simplex.B, Color.Red);
        Gizmo.Instance.DrawLine(_simplex.B, _simplex.C, Color.Red);
        Gizmo.Instance.DrawLine(_simplex.C, _simplex.A, Color.Red);
        Gizmo.Instance.DrawPoint(_origin, Color.Aqua);
        DrawMinDifference(objectA, objectB);
    }

    private void DrawMinDifference(IReadOnlyList<Vector3> objectA, IReadOnlyList<Vector3> objectB)
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