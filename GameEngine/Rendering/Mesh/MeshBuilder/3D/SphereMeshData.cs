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
        throw new NotImplementedException();
    }
    
    private void GetSphereVertices(out Vector3[] positions, out Vector3[] normals)
    {
        float lengthInv = 1.0f / _radius;
        float sectorStep = 2 * MathF.PI / _sectorCount;
        float stackStep = MathF.PI / _stackCount;
        positions = new Vector3[(_stackCount + 1) * (_sectorCount + 1)];
        normals = new Vector3[positions.Length];
        
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

                positions[i * (_sectorCount + 1) + j] = new Vector3(x, y, z) + _offset;
                normals[i * (_sectorCount + 1) + j] = new Vector3(nx, ny, nz);
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