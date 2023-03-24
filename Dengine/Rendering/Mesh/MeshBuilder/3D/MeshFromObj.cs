using OpenTK.Mathematics;

public class MeshFromObj : IMeshDataSource
{
    private readonly ObjParser _objParser;
    private readonly Dictionary<ObjVertex, uint> _indicesDictionary = new();
    private readonly Vector3 _offset;

    public MeshFromObj(string pathToModel) : this(pathToModel, Vector3.Zero)
    {
    }

    public MeshFromObj(string pathToModel, Vector3 offset)
    {
        _objParser = new ObjParser(pathToModel);
        _offset = offset;
    }

    public Mesh Build()
    {
        IReadOnlyList<ObjVertex> vertices = _objParser.Parse();
        IReadOnlyList<ObjVertex> optimizedVertices = OptimizeVertices(vertices);

        return new Mesh(new List<VertexAttribute>()
        {
            new("Position", 0, 3, optimizedVertices.Select(vertex => vertex.Position + _offset).ToArray().ToFloatArray()),
            new("Normals", 1, 3, optimizedVertices.Select(vertex => vertex.Normal).ToArray().ToFloatArray()),
            new("TexCoord", 2, 2, optimizedVertices.Select(vertex => vertex.TextureCoordinate).ToArray().ToFloatArray()),
        })
        {
            Indices = CreateIndices(vertices)
        };
    }

    private IReadOnlyList<ObjVertex> OptimizeVertices(IReadOnlyList<ObjVertex> vertices)
    {
        List<ObjVertex> result = new();
        
        for (int i = 0, vertexIndex = 0; i < vertices.Count; ++i)
        {
            if (_indicesDictionary.ContainsKey(vertices[i]) == false)
            {
                _indicesDictionary[vertices[i]] = (uint)vertexIndex;
                result.Add(vertices[i]);
                ++vertexIndex;
            }
        }

        return result;
    }

    private uint[] CreateIndices(IReadOnlyList<ObjVertex> vertices)
    {
        uint[] indices = new uint[vertices.Count];
        
        for (int i = 0; i < vertices.Count; ++i)
        {
            indices[i] = _indicesDictionary[vertices[i]];
        }

        return indices;
    }
}