using System.Drawing;
using OpenTK.Mathematics;

public class LODGroupDemo : IWorldFactory
{
    public List<GameObject> CreateGameObjects()
    {
        Camera camera = new();
        
        List<GameObject> gameObjects = new()
        {
            GameObjectFactory.CreateCamera(camera),
            GameObjectFactory.CreateSkybox("Storm"),
            CreateLod(camera),
            CreateLight(),
            // CreatePlane(),
        };

        //AddObjects(gameObjects);

        return gameObjects;
    }

    private GameObject CreateLod(Camera camera)
    {
        Transform transform = new();
        LODGroup lodGroup = new(transform, camera, new LODMesh[]
        {
            new(MeshBuilder.Quad(1f), 5),
            new(MeshBuilder.FromObj("monkey"), 50),
            new(MeshBuilder.Cube(1f), 10),
            new(MeshBuilder.Cube(1f), 55),
        });
        
        return GameObjectFactory.WithRenderData(new RenderData(lodGroup, new LitMaterial(new LitMaterialData()))
        {
            Transform = transform
        });
    }

    private GameObject CreatePlane()
    {
        return GameObjectFactory.WithRenderData("Plane", new RenderData(MeshBuilder.Quad(100f), new GridMaterial())
        {
            Transform = new Transform(Quaternion.FromAxisAngle(Vector3.UnitX, -MathF.PI / 2)),
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

    private void AddObjects(List<GameObject> gameObjects)
    {
        const int axisSize = 10;
        const float distance = 6f;
        RenderData cachedRenderData = new(MeshBuilder.Cube(1f), new LitMaterial(new LitMaterialData()));

        for (int i = 0; i < axisSize; ++i)
        {
            for (int j = 0; j < axisSize; ++j)
            {
                cachedRenderData.Transform = new Transform(new Vector3(i * distance, 1, j * distance));

                gameObjects.Add(GameObjectFactory.WithRenderData($"Object {i * axisSize + j}", cachedRenderData));
            }
        }
    }
}