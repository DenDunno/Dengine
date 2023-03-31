using System.Drawing;
using OpenTK.Mathematics;

public class FrustumCullingDemo : IWorldFactory
{
    private readonly int _count = 10;
    private readonly float _distance = 10f;
    private RenderData _cachedRenderData = null!;
    
    public List<GameObject> CreateGameObjects()
    {
        Camera camera = new(new Transform(Vector3.One * _count * _distance / 2));
        _cachedRenderData = CreateRenderData();
        Light light = new(new Transform(), camera.Transform, Color.FromArgb(255,216,128,54));
        light.Add(_cachedRenderData.Material.Bridge);

        List<GameObject> gameObjects = new()
        {
            GameObjectFactory.CreateCamera(camera),
            CreateCube(Vector3.Zero),
            //GameObjectFactory.Point(light),
        };
        
        //AddCubes(gameObjects);

        return gameObjects;
    }

    private RenderData CreateRenderData()
    {
        return new()
        {
            Mesh = MeshBuilder.Cube(1f),
            Material = new LitMaterial(new LitMaterialData()
            {
                Base = new Texture2D(Paths.GetTexture("crate.png"))
            })
        };
    }

    private void AddCubes(List<GameObject> gameObjects)
    {
        for (int x = 0; x < _count; ++x)
        {
            for (int y = 0; y < _count; ++y)
            {
                for (int z = 0; z < _count; ++z)
                {
                    gameObjects.Add(CreateCube(new Vector3(x, y, z) * _distance));
                }
            }
        }
    }

    private GameObject CreateCube(Vector3 position)
    {
        Transform transform = new(position);

        return new GameObject(new GameObjectData("Cube", transform)
        {
            Drawable = new Model(new RenderData()
            {
                Mesh = _cachedRenderData.Mesh,
                Material = _cachedRenderData.Material,
                Transform = transform
            }),
            
            Components = new List<IGameComponent>()
            {
                new RotationAnimation(transform, Algorithms.RandomVector3(), Algorithms.RandomFloat(0.5f, 1))
            }
        });
    }
}