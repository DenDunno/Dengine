using System.Drawing;
using OpenTK.Mathematics;

public class Simplex
{
    private List<Vector3> _points = new(3);

    private Vector3 PointA => _points[2];
    private Vector3 PointB => _points[1];
    private Vector3 PointC => _points[0];
    
    public void Add(Vector3 point)
    {
        _points.Add(point);
    }

    public void Clear()
    {
        _points = new List<Vector3>(3);
    }
    
    public bool Contains(ref Vector3 direction)
    {
        Vector3 a = PointA;
        Vector3 ap = a.Negated();

        if (_points.Count == 3)
        {
            // we have a triangle
            Vector3 b = PointB;
            Vector3 c = PointC;

            Vector3 ab = b - a;
            Vector3 ac = c - a;


            // explanation of region #s:
            //
            //V  A         1         B
            //V    o---------------o
            //V     \      2      /
            //V      \           /
            //V       \ 4     6 /
            //V     3  \       /  5
            //V         \     /
            //V          \   /
            //V           \ /
            //V            o
            //V            C
            //
            // Each region is defined as being on one side of a line. If the point is
            // contained by all regions 2, 4, and 6, then it is within the simplex. If it is
            // contained by any of region 1, 3, or 5, then it is outside the simplex.
            //
            // NerbsNote: I believe GJK already ensures that p is within region 6 when this is
            // called, by means of the direction vectors selected here. This is why we only
            // need to check against the AB and AC lines here.


            // check against AB.
            Vector3 abPerp = Algorithms.LeftTriple(ac, ab, ab);    // points into region 1

            if (abPerp.Dot(ap) > 0)
            {
                // p is in region 1. Point C is least optimal, so remove it
                _points.RemoveAt(0);

                // update direction to point towards p.
                direction = abPerp;
            }
            else
            {
                // p is in region 2. Check against AC.
                Vector3 acPerp = Algorithms.LeftTriple(ab, ac, ac);    // points into region 3

                if (acPerp.Dot(ap) > 0)
                {
                    // p is in region 3. Point B is least optimal, so remove it.
                    _points.Remove(PointB);

                    // update direction to point towards p.
                    direction = acPerp;
                }
                else
                {
                    // p is within the simplex.
                    return true;
                }
            }
        }
        else if (_points.Count == 2)
        {
            // we have a line segment.
            Vector3 b = PointB;
            Vector3 ab = b - a;

            Vector3 abPerp = Algorithms.LeftTriple(ab, ap, ab);
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