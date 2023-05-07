using OpenTK.Mathematics;

public class FrustumCulling
{
    private readonly Plane[] _frustumPlanes = new Plane[6];

    public FrustumCulling()
    {
        _frustumPlanes[0] = new Plane(Vector3.Zero, 0.0f); // Left plane
        _frustumPlanes[1] = new Plane(Vector3.Zero, 0.0f); // Right plane
        _frustumPlanes[2] = new Plane(Vector3.Zero, 0.0f); // Top plane
        _frustumPlanes[3] = new Plane(Vector3.Zero, 0.0f); // Bottom plane
        _frustumPlanes[4] = new Plane(Vector3.Zero, 0.0f); // Near plane
        _frustumPlanes[5] = new Plane(Vector3.Zero, 0.0f); // Far plane
    }

    public void Update(Matrix4 projection, Matrix4 modelView)
    {
        Matrix4 viewProj = projection * modelView;
        //viewProj.Invert();
        
        _frustumPlanes[0].Set(viewProj.Row3 + viewProj.Row0); // Left plane
        _frustumPlanes[1].Set(viewProj.Row3 - viewProj.Row0); // Right plane
        _frustumPlanes[2].Set(viewProj.Row3 - viewProj.Row1); // Top plane
        _frustumPlanes[3].Set(viewProj.Row3 + viewProj.Row1); // Bottom plane
        _frustumPlanes[4].Set(viewProj.Row3 - viewProj.Row2); // Near plane
        _frustumPlanes[5].Set(viewProj.Row3 + viewProj.Row2); // Far plane
    }

    public bool ContainsSphere(Vector3 center, float radius)
    {
        for (int i = 0; i < 6; i++)
        {
            float distance = _frustumPlanes[i].DistanceTo(center);
            
            if (distance < -radius)
            {
                return false;
            }
        }
        
        return true;
    }
}