﻿
public class MeshFromObj : IMeshDataSource
{
    private readonly ObjParser _objParser;
    private readonly Dictionary<ObjVertex, uint> _indicesDictionary = new();
    
    public MeshFromObj(string pathToModel)
    {
        _objParser = new ObjParser(pathToModel);
    }
    
    Mesh IMeshDataSource.Build()
    {
        throw new NotImplementedException();
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