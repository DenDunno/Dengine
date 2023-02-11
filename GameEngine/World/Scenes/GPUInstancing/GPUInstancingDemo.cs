using System.Drawing;
using OpenTK.Mathematics;

public class GPUInstancingDemo : IWorldFactory
{
    public List<GameObject> CreateGameObjects()
    {
        Camera camera = new(new Transform(new Vector3(150, 200, 700)));
        Light light = new(new Transform(), camera.Transform, Color.Orange);
        
        return new List<GameObject>()
        {
            GameObjectFactory.Point(light, light.Transform),
            GameObjectFactory.CreateCamera(camera),
            CreateSpace(camera),
            CreateAsteroids(light),
            CreateSun(),
        };
    }

    private GameObject CreateSpace(Camera camera)
    {
        GameObject skybox = GameObjectFactory.CreateSkybox("Space", camera);
        skybox.Data.Components.Add(new RotationAnimation(skybox.Data.Transform, Vector3.One, 0.015f));

        return skybox;
    }

    private GameObject CreateAsteroids(Light light)
    {
        const int count = 16_000;
        
        RenderData renderData = new()
        {
            Mesh = MeshBuilder.FromObj("rock"),
            DrawCommand = new DrawElementsInstanced(count),
            Material = new AsteroidsMaterial(new LitMaterialData()
            {
                Base = new Texture(Paths.GetTexture("rock.png"))
            }),
        };

        light.Add(renderData.Material.Bridge);
        
        return new GameObject(new GameObjectData("Asteroids", renderData.Transform)
        {
            Drawable = new Model(renderData),
            Components = new List<IGameComponent>()
            {
                new AsteroidsAnimation(renderData.Material, count)
            }
        });
    }

    private GameObject CreateSun()
    {
        RenderData renderData = new()
        {
            Transform = new Transform() { Scale = Vector3.One * 60 },
            Mesh = MeshBuilder.FromObj("sun"),
            Material = new SunMaterial(),
        };

        return new GameObject(new GameObjectData("Sun", renderData.Transform)
        {
            Drawable = new Model(renderData),
            Components = new List<IGameComponent>()
            {
                new SunAnimation(renderData.Material.Bridge, renderData.Transform)
            }
        });
    }
}