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
            GameObjectFactory.CreateSkybox("Space", -Vector3.One, 0.03f),
            CreateAsteroids(),
            CreateSun(),
        };
    }

    private GameObject CreateAsteroids()
    {
        const int count = 18_000;
        Material material = new AsteroidsMaterial(new LitMaterialData()
        {
            Base = new Texture2D(Paths.GetTexture("rock.png"))
        });
        
        RenderData renderData = new(MeshBuilder.FromObj("rock"), material, new DrawElementsInstanced(count));

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
        RenderData renderData = new(MeshBuilder.FromObj("sun"), new SunMaterial())
        {
            Transform = new Transform() { Scale = Vector3.One * 60 },
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