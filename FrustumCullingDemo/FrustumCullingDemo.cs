using System.Drawing;
using OpenTK.Mathematics;

public class FrustumCullingDemo : IWorldFactory
{
    private readonly int _countInAxis = 10;
    private readonly float _distance = 10f;

    private Transform CameraTransform => new(Vector3.One * _countInAxis * _distance / 2 - new Vector3(2, 2, 0));
    
    private Light SunLight => new(new Transform(new Vector3(-1, 1, -1) * 10000), new LightData()
    {
        Color = new ColorVector4(Color.FromArgb(255, 216, 128, 54))
    });

    public List<GameObject> CreateGameObjects()
    {
        List<GameObject> gameObjects = new()
        {
            GameObjectFactory.CreateCamera(CameraTransform),
            GameObjectFactory.CreateLight(SunLight),
            GameObjectFactory.CreateSkybox("Storm")
        };
        
        AddCubes(gameObjects, CreateRenderData());

        return gameObjects;
    }

    private RenderData CreateRenderData()
    {
        return new RenderData
        {
            Mesh = MeshBuilder.Cube(1f),
            Material = new LitMaterial(new LitMaterialData()
            {
                Base = new Texture2D(Paths.GetTexture("crate.png"))
            })
        };
    }

    private void AddCubes(List<GameObject> gameObjects, RenderData renderData)
    {
        for (int x = 0; x < _countInAxis; ++x)
        {
            for (int y = 0; y < _countInAxis; ++y)
            {
                for (int z = 0; z < _countInAxis; ++z)
                {
                    gameObjects.Add(CreateCube(new Vector3(x, y, z) * _distance, renderData));
                }
            }
        }
    }

    private GameObject CreateCube(Vector3 position, RenderData renderData)
    {
        Transform transform = new(position);

        return new GameObject(new GameObjectData("Cube", transform)
        {
            Drawable = new Model(new RenderData()
            {
                Mesh = renderData.Mesh,
                Material = renderData.Material,
                Transform = transform
            }),
            
            Components = new List<IGameComponent>()
            {
                new RotationAnimation(transform, Algorithms.RandomVector3(), Algorithms.RandomFloat(0.5f, 1))
            }
        });
    }
}