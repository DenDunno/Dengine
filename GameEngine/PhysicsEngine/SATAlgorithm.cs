using System.Drawing;
using OpenTK.Mathematics;

public readonly struct Projection
{
    public readonly float _min;
    public readonly float _max;

    public Projection(float min, float max)
    {
        _min = min;
        _max = max;
    }

    public bool DoNotOverlap(Projection projection)
    {
        return _max < projection._min ||
               projection._max < _min; 
    }
}

public class SATAlgorithm
{
    public bool CheckCollision(Rigidbody objectA, Rigidbody objectB)
    {
        Vector3[] worldPositionsA = objectA.MeshWorldView.Positions;
        Vector3[] worldPositionsB = objectB.MeshWorldView.Positions;
        Vector3[] normalsA = objectA.MeshWorldView.Normals;
        Vector3[] normalsB = objectB.MeshWorldView.Normals;

        return CheckSeparatingAxis(worldPositionsA, normalsA, worldPositionsB) && 
               CheckSeparatingAxis(worldPositionsB, normalsB, worldPositionsA);
    }

    private bool CheckSeparatingAxis(Vector3[] worldPositionsA, Vector3[] normals, Vector3[] worldPositionsB)
    {
        foreach (Vector3 normal in normals)
        {
            Projection projectionA = ProjectOnNormal(worldPositionsA, normal);
            Projection projectionB = ProjectOnNormal(worldPositionsB, normal);

            if (projectionA.DoNotOverlap(projectionB))
            {
                DrawSeparatingAxis(normal, projectionA, projectionB);
                return false;
            }
        }
        
        return true;
    }

    private Projection ProjectOnNormal(Vector3[] worldPositions, Vector3 normal)
    {
        float min = float.MaxValue;
        float max = float.MinValue;

        foreach (Vector3 worldPosition in worldPositions)
        {
            float projection = Vector3.Dot(worldPosition, normal);

            if (projection > max)
            {
                max = projection;
            }
            else if (projection < min)
            {
                min = projection;
            }
        }

        return new Projection(min, max);
    }

    private (Vector3, float) FindMinSeparation(Vector3 vertexA, Vector3 normalA, Vector3[] worldPositionsB)
    {
        float minSeparation = float.MaxValue;
        Vector3 minVertexB = Vector3.Zero;
            
        foreach (Vector3 vertexB in worldPositionsB)
        {
            float dot = Vector3.Dot(vertexB - vertexA, normalA);
                
            if (dot < minSeparation)
            {
                minVertexB = vertexB;
                minSeparation = dot;
            }
        }

        return (minVertexB, minSeparation);
    }

    private void DrawSeparatingAxis(Vector3 direction, Projection projectionA, Projection projectionB)
    {
        Vector3 normal = Algorithms.GetNormal(direction);
        Vector3 firstPoint = direction * 2;
        Vector3 secondPoint = -direction * 2;
        Vector3 offset = normal * 0.1f;
        Vector3 projectionMinA = offset + direction * projectionA._min;
        Vector3 projectionMaxA = offset + direction * projectionA._max;
        Vector3 projectionMinB = offset + direction * projectionB._min;
        Vector3 projectionMaxB = offset + direction * projectionB._max;
        
        Gizmo.Instance.DrawLine(firstPoint, secondPoint, Color.Aqua);
        Gizmo.Instance.DrawLine(projectionMinA, projectionMaxA, Color.Red);
        Gizmo.Instance.DrawLine(projectionMinB, projectionMaxB, Color.Red);
    }

    private void DrawSeparatingAxis(Vector3 vertexA, Vector3 normalA, Vector3 vertexB)
    {
        Vector3 lineDirection = Algorithms.GetNormal(normalA);
        Vector3 lineCentre = (vertexA + vertexB) / 2;
        Vector3 firstPoint = lineCentre + lineDirection;
        Vector3 secondPoint = lineCentre - lineDirection;
        
        Gizmo.Instance.DrawLine(firstPoint, secondPoint, Color.Aqua);
    }
}