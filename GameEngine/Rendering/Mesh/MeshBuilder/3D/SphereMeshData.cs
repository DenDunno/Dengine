using OpenTK.Mathematics;

public class SphereMeshData : IMeshDataSource
{
    private readonly float _radius;
    private readonly uint _sectorCount;
    private readonly uint _stackCount;
    private readonly Vector3 _offset;

    public SphereMeshData(float radius, uint sectorCount, uint stackCount) : this(radius, sectorCount, stackCount, Vector3.Zero)
    {
    }
    
    public SphereMeshData(float radius, uint sectorCount, uint stackCount, Vector3 offset)
    {
        _radius = radius;
        _sectorCount = sectorCount;
        _stackCount = stackCount;
        _offset = offset;
    }
    
    public Mesh Build()
    {
        GetSphereVertices(out float[] positions, out float[] normals);

        List<VertexAttribute> attributes = new()
        {
            new("Position", 0, 3, positions),
            new("TexCoord", 2, 3, normals),
        };
        
        return new Mesh(attributes)
        {
            Indices = GetIndices()
        };
    }
    
    private void GetSphereVertices(out float[] positions, out float[] normals)
    {
        float lengthInv = 1.0f / _radius;
        float sectorStep = 2 * MathF.PI / _sectorCount;
        float stackStep = MathF.PI / _stackCount;
        positions = new float[(_stackCount + 1) * (_sectorCount + 1) * 3];
        normals = new float[positions.Length * 3];
        
        for(int i = 0; i <= _stackCount; ++i)
        {
            float stackAngle = MathF.PI / 2 - i * stackStep;
            float xy = _radius * MathF.Cos(stackAngle); 
            float z = _radius * MathF.Sin(stackAngle);  
            
            for(int j = 0; j <= _sectorCount; ++j)
            {
                float sectorAngle = j * sectorStep;
                
                float x = xy * MathF.Cos(sectorAngle);   
                float y = xy * MathF.Sin(sectorAngle);
                float nx = x * lengthInv;
                float ny = y * lengthInv;
                float nz = z * lengthInv;

                positions[i * (_sectorCount + 1) + j + 0] = x + _offset.X;
                positions[i * (_sectorCount + 1) + j + 1] = y + _offset.Y;
                positions[i * (_sectorCount + 1) + j + 2] = z + _offset.Z;

                normals[i * (_sectorCount + 1) + j + 0] = nx;
                normals[i * (_sectorCount + 1) + j + 1] = ny;
                normals[i * (_sectorCount + 1) + j + 2] = nz;
            }
        }
    }

    private uint[] GetIndices()
    {
        var indices = new List<uint>();

        for(uint i = 0; i < _stackCount; ++i)
        {
            uint k1 = i * (_sectorCount + 1);
            uint k2 = k1 + _sectorCount + 1;

            for(uint j = 0; j < _sectorCount; ++j, ++k1, ++k2)
            {
                if(i != 0)
                {
                    indices.Add(k1);
                    indices.Add(k2);
                    indices.Add(k1 + 1);
                }
                
                if(i != (_stackCount-1))
                {
                    indices.Add(k1 + 1);
                    indices.Add(k2);
                    indices.Add(k2 + 1);
                }
            }
        }
        
        return indices.ToArray();
    }
}