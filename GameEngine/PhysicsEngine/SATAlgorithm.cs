using System.Drawing;
using OpenTK.Mathematics;

public class SATAlgorithm
{
    public bool CheckCollision(Rigidbody objectA, Rigidbody objectB)
    {
        IReadOnlyList<MeshVertex> verticesA = objectA.MeshWorldView.GetWorldVertices();
        IReadOnlyList<MeshVertex> verticesB = objectB.MeshWorldView.GetWorldVertices();

        return CheckSeparatingAxis(verticesA, verticesB) && 
               CheckSeparatingAxis(verticesB, verticesA);
    }

    private bool CheckSeparatingAxis(IReadOnlyList<MeshVertex> verticesA, IReadOnlyList<MeshVertex> verticesB)
    {
        float separation = float.MinValue;
        bool isGizmoDrawing = false;
        
        for (int i = 0; i < verticesA.Count && separation <= 0; ++i)
        {
            foreach (Vector3 normal in verticesA[i].Normals)
            {
                Vector3 vertexA = verticesA[i].Position;
                
                (Vector3 minVertexB, float minSeparation) = FindMinSeparation(vertexA, normal, verticesB);
                separation = MathF.Max(separation, minSeparation);
                
                if (separation >= 0 && isGizmoDrawing == false)
                {
                    isGizmoDrawing = true;
                    DrawGizmo(vertexA, normal, minVertexB);
                }
            }
        }
        
        return separation <= 0;
    }

    private (Vector3, float) FindMinSeparation(Vector3 vertexA, Vector3 normalA, IReadOnlyList<MeshVertex> verticesB)
    {
        float minSeparation = float.MaxValue;
        Vector3 minVertexB = Vector3.Zero;
            
        foreach (MeshVertex vertexB in verticesB)
        {
            float dot = Vector3.Dot(vertexB.Position - vertexA, normalA);
                
            if (dot < minSeparation)
            {
                minVertexB = vertexB.Position;
                minSeparation = dot;
            }
        }

        return (minVertexB, minSeparation);
    }

    private void DrawGizmo(Vector3 vertexA, Vector3 normalA, Vector3 vertexB)
    {
        Vector3 lineDirection = Algorithms.GetNormal(normalA);
        Vector3 lineCentre = (vertexA + vertexB) / 2;
        Vector3 firstPoint = lineCentre + lineDirection;
        Vector3 secondPoint = lineCentre - lineDirection;
        Vector3 normalFirstPoint = vertexA + normalA * 0.4f;
        Vector3 baDirection = (vertexB - vertexA).Normalized();
        
        Gizmo.Instance.DrawPlane(lineCentre, normalA, Color.Aqua);
        //Gizmo.Instance.DrawLine(firstPoint, secondPoint, Color.Aqua);
        Gizmo.Instance.DrawArrow(normalFirstPoint, vertexA, Color.Chartreuse);
        Gizmo.Instance.DrawArrow(vertexB - baDirection * 0.2f, vertexA, Color.FromArgb(1, 255, 255, 0));
    }
}