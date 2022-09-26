using OpenTK.Mathematics;

public class BoundingBox 
{
    private readonly float[] _verticesData;
    private readonly Transform _transform;
    private readonly int _offset;
    private Vector4 _min;
    private Vector4 _max;

    public BoundingBox(float[] verticesData, int offset, Transform transform)
    {
        _verticesData = verticesData;
        _transform = transform;
        _offset = offset;
        Initialize();
    }

    public Vector4 Min => _min * _transform.ModelMatrix;
    public Vector4 Max => _max * _transform.ModelMatrix;

    private void Initialize()
    {
        Vector3 min = Vector3.Zero;
        Vector3 max = Vector3.Zero;
        
        for (var i = 0; i < _verticesData.Length; i += _offset)
        {
            var vertex = new Vector3(_verticesData[i], _verticesData[i + 1], _verticesData[i + 2]);

            min = Algorithms.Min(vertex, min);
            max = Algorithms.Max(vertex, max);
        }

        _max = new Vector4(max, 1);
        _min = new Vector4(min, 1);
    }
}