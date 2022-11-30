using System.Drawing;
using OpenTK.Mathematics;

public class ConvexHullBruteForce
{
    private readonly List<Vector3> _input = new();
    private readonly List<Vector3> _convexHullPoints = new();
    
    public void DrawSupportPoints(IReadOnlyList<Vector3> objectA, IReadOnlyList<Vector3> objectB)
    {
        _convexHullPoints.Clear();
        _input.Clear();
        DrawOrigin();
        EvaluatePoints(objectA, objectB);
        DrawConvex();
        DrawPoints();
    }

    private void DrawOrigin()
    {
        Gizmo.Instance.DrawPoint(Vector3.Zero, Color.Aqua);
    }

    private void EvaluatePoints(IReadOnlyList<Vector3> objectA, IReadOnlyList<Vector3> objectB)
    {
        foreach (Vector3 pointA in objectA)
        {
            foreach (Vector3 pointB in objectB)
            {
                _input.Add(pointA - pointB);
            }
        }
    }

    private void DrawPoints()
    {
        foreach (Vector3 point in _input)
        {
            Gizmo.Instance.DrawPoint(point, Color.Crimson);
        }
    }
    
    private void DrawConvex()
    {
        foreach (Vector3 pointA in _input)
        {
            foreach (Vector3 pointB in _input)
            {
                if (pointA == pointB || (_convexHullPoints.Contains(pointA) && _convexHullPoints.Contains(pointB)))
                {
                    continue;
                }

                Vector3 axisNormal = Algorithms.GetNormal(pointB - pointA);
                bool isPartOfSegment = true;
                
                for (int i = 0; i < _input.Count; ++i)
                {
                    if (_input[i] != pointA && _input[i] != pointB)
                    {
                        if (Vector3.Dot(axisNormal, _input[i] - pointA) <= 0)
                        {
                            isPartOfSegment = false;
                            break;
                        }
                    }
                }

                if (isPartOfSegment)
                {
                    _convexHullPoints.Add(pointA);
                    _convexHullPoints.Add(pointB);
                    Gizmo.Instance.DrawLine(pointA, pointB, Color.Aqua);
                }
            }
        }
    }
}