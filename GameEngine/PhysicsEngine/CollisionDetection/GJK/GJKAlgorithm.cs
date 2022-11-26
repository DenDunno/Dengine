using System.Drawing;
using OpenTK.Mathematics;

public class GJKAlgorithm : ICollisionDetection
{
    private readonly Simplex _simplex = new();
    
    public bool CheckCollision(Rigidbody objectA, Rigidbody objectB)
    {
        Vector3[] positionsA = objectA.MeshWorldView.Positions;
        Vector3[] positionsB = objectB.MeshWorldView.Positions;
        Vector3 direction = Vector3.UnitX;
        Vector3 initPoint = GetSupportPoint(direction, positionsA, positionsB);
        
        _simplex.Clear();
        _simplex.Add(initPoint);
        direction = initPoint.Negated();
    
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
                //DrawGizmo(positionsA, positionsB);
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

    private void DrawGizmo(IReadOnlyList<Vector3> objectA, IReadOnlyList<Vector3> objectB)
    {
        Gizmo.Instance.DrawPoint(Vector3.Zero, Color.Aqua);
        _simplex.Draw();
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
            
            Gizmo.Instance.DrawLine(minDifference[first], minDifference[second], Color.Coral);
        }
    }
}