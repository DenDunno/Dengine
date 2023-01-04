using OpenTK.Mathematics;

public class Gizmos : Singlton<Gizmos>, IModel
{
    private Matrix4 _projectionMatrix;
    private Matrix4 _viewMatrix;
    
    public void Manipulate(Transform transform)
    {
        //ImGuizmo.Manipulate(ref _viewMatrix.Row0.X, ref _projectionMatrix.Row0.X, TransformOperation.Translate, transform_mode, ref test_cube.Row0.X, ref delta_test_cube.Row0.X, ref snap.X);
    }

    public void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
        _projectionMatrix = projectionMatrix;
        _viewMatrix = viewMatrix;
    }
}