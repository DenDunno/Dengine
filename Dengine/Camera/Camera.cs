using OpenTK.Mathematics;

public class Camera : IGameComponent
{
    [EditorField] public readonly RenderSettings Settings = new();
    [EditorField] public readonly CameraProjection Projection;
    public readonly FrustumCulling Culling = new();
    public readonly Transform Transform;
    private readonly ViewMatrix _viewMatrix;
    private readonly UniformData<CameraUniformData> _uniformData = new(0);

    public Camera(Transform transform) : this(transform, new PerspectiveProjection())
    {
    }

    public Camera(CameraProjection projection) : this(new Transform(new Vector3(0, 0, 10)), projection)
    {
    }

    private Camera(Transform transform, CameraProjection projection)
    {
        Transform = transform;
        Projection = projection;
        _viewMatrix = new ViewMatrix(Transform);
    }
    
    public Vector2 ScreenToWorldCoordinates(Vector2 mousePosition) => CameraUtils.ScreenToWorldCoordinates(_viewMatrix.Value, Projection.Value, mousePosition);

    void IGameComponent.Initialize()
    {
        _uniformData.Initialize();
    }

    public void UpdateMatrices()
    {
        _uniformData.Value.Position = new Vector4(Transform.Position);
        _uniformData.Value.ViewMatrix = _viewMatrix.Value;
        _uniformData.Value.ProjectionMatrix = Projection.Value;

        _uniformData.Map();
        
        Matrix4 modelMatrix = Transform.ModelMatrix;
        //modelMatrix.Transpose();
        //Culling.Update(Projection.Value, modelMatrix.Inverted() * _viewMatrix.Value);
    }

    public void Dispose()
    {
        _uniformData.Dispose();
    }
}