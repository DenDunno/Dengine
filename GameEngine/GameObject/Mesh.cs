using OpenTK.Mathematics;

public class Mesh
{
    public readonly float[] VerticesData;
    public readonly uint[] Indices;
    public readonly Vector3[] LocalVertexPositions;

    public Mesh(float[] verticesData, uint[] indices, int stride)
    {
        VerticesData = verticesData;
        Indices = indices;
        LocalVertexPositions = new Vector3[verticesData.Length / stride];
        Init(stride);
    }

    private void Init(int stride)
    {
        for (int i = 0, j = 0; i < VerticesData.Length; i += stride, ++j)
        {
            LocalVertexPositions[j].X = VerticesData[i];
            LocalVertexPositions[j].Y = VerticesData[i + 1];
            LocalVertexPositions[j].Z = VerticesData[i + 2];
        }
    }
}