using System.Drawing;
using OpenTK.Mathematics;

public class GPUInstancingDemo : IWorldFactory
{
    public List<GameObject> CreateGameObjects()
    {
        return new List<GameObject>()
        {
            GameObjectFactory.CreateCamera(new Transform(new Vector3(150, 200, 900))),
            GameObjectFactory.CreateLight(new LightData() {Color = new ColorVector4(Color.Orange)}),
            GameObjectFactory.CreateSkybox("Space"),
            CreateAsteroids(),
            CreateSun(),
        };
    }

    private GameObject CreateSpace()
    {
        GameObject skybox = GameObjectFactory.CreateSkybox("Space");
        skybox.Data.Components.Add(new RotationAnimation(skybox.Data.Transform, Vector3.One, 0.015f));

        return skybox;
    }

    private GameObject CreateAsteroids()
    {
        const int count = 18_000;
        
        RenderData renderData = new()
        {
            Mesh = MeshBuilder.FromObj("rock"),
            DrawCommand = new DrawElementsInstanced(count),
            Material = new AsteroidsMaterial(new LitMaterialData()
            {
                Base = new Texture2D(Paths.GetTexture("rock.png"))
            }),
        };

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