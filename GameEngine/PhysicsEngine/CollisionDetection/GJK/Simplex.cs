using System.Drawing;
using OpenTK.Mathematics;

public class Simplex
{
    private readonly List<Vector3> _points = new(3);

    private Vector3 PointA => _points[^1];
    private Vector3 PointB => _points[^2];
    private Vector3 PointC => _points[^3];

    public void Clear()
    {
        _points.Clear();
    }

    public void Add(Vector3 point)
    {
        _points.Add(point);
    }

    public bool Contains(ref Vector3 direction)
    {
        Vector3 originA = PointA.Negated();
        Vector3 ab = PointB - PointA;
        
        if (_points.Count == 3)
        {
            Vector3 ac = PointC - PointA;
            Vector3 abPerp = Algorithms.LeftTriple(ac, ab, ab);
            Vector3 acPerp = Algorithms.LeftTriple(ab, ac, ac);

            if (abPerp.Dot(originA) > 0)
            {
                _points.RemoveAt(0);
                direction = abPerp;
            }
            else if (acPerp.Dot(originA) > 0)
            {
                _points.RemoveAt(1);
                direction = acPerp;
            }
            else
            {
                return true;
            }
        }
        else if (_points.Count == 2)
        {
            Vector3 abPerp = Algorithms.LeftTriple(ab, originA, ab);
            direction = abPerp;
        }

        return false;
    }

    public void Draw()
    {
        Gizmo.Instance.DrawLine(PointA, PointB, Color.Bisque);
        Gizmo.Instance.DrawLine(PointB, PointC, Color.Bisque);
        Gizmo.Instance.DrawLine(PointC, PointA, Color.Bisque);
    }
}