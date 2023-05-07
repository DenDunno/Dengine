using OpenTK.Mathematics;

[TestFixture]
public class FrustumCullingTests
{
    private readonly FrustumCulling _frustumCulling = new();

    [Test]
    public void SphereInsideFrustum()
    {
        Vector3 center = new(0.0f, 0.0f, 0);
        float radius = 2.0f;

        Matrix4 projection = new(1.81066f, 0, 0, 0,
                                 0, 2.414213f, 0, 0,
                                 0, 0, -1.002002f, -0.2002002f,
                                 0, 0, -1, 0);
        
        Matrix4 modelView = new(-0.707107f, -0.707107f, 0, 0,
                                0.707107f, -0.707107f, 0, 0,
                                0, 0, 1, 0,
                                0, 0, 10, 1);
        
        _frustumCulling.Update(projection, modelView);

        bool isInside = _frustumCulling.ContainsSphere(center, radius);
        
        Assert.IsTrue(isInside);
    }
}