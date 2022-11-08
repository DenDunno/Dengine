using System.Globalization;
using OpenTK.Mathematics;

public class ObjParser
{
    private readonly string _pathToModel;
    private readonly List<Vector3> _positions = new();
    private readonly List<Vector2> _textureCoordinates = new();
    private readonly List<Vector3> _normals = new();
    private readonly List<Polygon> _polygons = new();
    
    public ObjParser(string pathToModel)
    {
        _pathToModel = pathToModel;
    }

    public MeshFaces Parse()
    {
        string[] lines = File.ReadAllLines(_pathToModel);

        foreach (string line in lines)
        {
            string[] data = line.Split();
            string identifier = data[0];
            
            TryAddVertexData(identifier, data);
            TryAddPolygon(identifier, data);
        }
        
        return new MeshFaces(_polygons);
    }

    private void TryAddVertexData(string identifier, string[] data)
    {
        switch (identifier)
        {
            case "v":
                ParseVector3ToCollection(data, _positions);
                break;
            case "vt":
                ParseVector2ToCollection(data, _textureCoordinates);
                break;
            case "vn":
                ParseVector3ToCollection(data, _normals);
                break;
        }
    }

    private void TryAddPolygon(string identifier, string[] data)
    {
        if (identifier != "f") 
            return;
        
        MeshVertex[] polygon = new MeshVertex[3];
            
        for (int i = 1; i < data.Length; ++i)
        {
            int[] vertexDataIndices = data[i].Split("/").Select(int.Parse).ToArray();
                
            int positionIndex = vertexDataIndices[0] - 1;
            int textureCoordinateIndex = vertexDataIndices[1] - 1;
            int normalIndex = vertexDataIndices[2] - 1;

            Vector3 position = _positions[positionIndex];
            Vector2 textureCoordinate = _textureCoordinates[textureCoordinateIndex];
            Vector3 normal = _normals[normalIndex];

            polygon[i - 1] = new MeshVertex(position, textureCoordinate, normal);
        }
            
        _polygons.Add(new Polygon(polygon));
    }

    private void ParseVector2ToCollection(string[] dataToParse, List<Vector2> collection)
    {
        Vector2 data = new(
            float.Parse(dataToParse[1], CultureInfo.InvariantCulture), 
            float.Parse(dataToParse[2], CultureInfo.InvariantCulture));
        
        collection.Add(data);
    }

    private void ParseVector3ToCollection(string[] dataToParse, List<Vector3> collection)
    {
        Vector3 data = new(
            float.Parse(dataToParse[1], CultureInfo.InvariantCulture), 
            float.Parse(dataToParse[2], CultureInfo.InvariantCulture), 
            float.Parse(dataToParse[3], CultureInfo.InvariantCulture));
        
        collection.Add(data);
    }
}