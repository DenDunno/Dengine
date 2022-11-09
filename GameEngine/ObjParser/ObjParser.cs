using System.Globalization;
using OpenTK.Mathematics;

public class ObjParser
{
    private readonly string _pathToModel;
    private readonly List<Vector3> _positions = new();
    private readonly List<Vector2> _textureCoordinates = new();
    private readonly List<Vector3> _normals = new();
    
    public ObjParser(string pathToModel)
    {
        _pathToModel = pathToModel;
    }

    public void Parse()
    {
        string[] lines = File.ReadAllLines(_pathToModel);
        
        foreach (string line in lines)
        {
            TryParse(line);
        }
    }

    private void TryParse(string line)
    {
        string[] data = line.Split();

        switch (data[0])
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
            case "f":
                ParsePolygon(data);
                break;
        }
    }

    private void ParsePolygon(string[] data)
    {
        for (int i = 1; i < data.Length; ++i)
        {
            int[] vertexDataIndices = data[i].Split("/").Select(int.Parse).ToArray();
                
            int positionIndex = vertexDataIndices[0] - 1;
            int textureCoordinateIndex = vertexDataIndices[1] - 1;
            int normalIndex = vertexDataIndices[2] - 1;

            Vector3 position = _positions[positionIndex];
            Vector2 textureCoordinate = _textureCoordinates[textureCoordinateIndex];
            Vector3 normal = _normals[normalIndex];
        }
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