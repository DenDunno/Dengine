using System.Drawing;
using OpenTK.Mathematics;

public class LODGroupDemo : IWorldFactory
{
    public List<GameObject> CreateGameObjects()
    {
        return new List<GameObject>()
        {
            GameObjectFactory.CreateCamera(new Transform(new Vector3(0, 15, 0))),
            GameObjectFactory.CreateSkybox("Storm"),
            CreatePlane(),
            CreateLight(),
        };
    }

    private GameObject CreatePlane()
    {
        return GameObjectFactory.WithRenderData("Plane", new RenderData()
        {
            Transform = new Transform(Quaternion.FromAxisAngle(Vector3.UnitX, -MathF.PI / 2)),
            Material = new GridMaterial(),
            Mesh = MeshBuilder.Quad(100f)
        });
    }

    private GameObject CreateLight()
    {
        Light light = new(new Transform(new Vector3(-1, 1, -1) * 10000), new LightData()
        {
            Color = new ColorVector4(Color.FromArgb(255, 216, 128, 54))
        });

        return GameObjectFactory.CreateLight(light);
    }
}