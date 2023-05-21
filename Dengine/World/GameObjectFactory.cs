
using OpenTK.Mathematics;

public static class GameObjectFactory
{
    public static GameObject Point(string name, IGameComponent tag)
    {
        GameObject point = Point(name);
        point.Data.Components.Add(tag);

        return point;
    }
    
    public static GameObject Point(string name)
    {
        return new GameObject(new GameObjectData(name, new Transform()));
    }

    public static GameObject Point(IGameComponent tag)
    {
        return new GameObject(new GameObjectData(tag.GetType().Name, new Transform())
        {
            Components = new List<IGameComponent>()
            {
                tag
            }
        });
    }

    public static GameObject Point(string name, IGameComponent tag, Transform transform)
    {
        return new GameObject(new GameObjectData(name, transform)
        {
            Components = new List<IGameComponent>()
            {
                tag
            }
        });
    }

    public static GameObject Point(IGameComponent tag, Transform transform)
    {
        return new GameObject(new GameObjectData(tag.GetType().Name, transform)
        {
            Components = new List<IGameComponent>()
            {
                tag
            }
        });
    }

    private static GameObject Sprite(Texture2D sprite, Transform transform)
    {
        RenderData renderData = new(MeshBuilder.Quad(1f), new LitMaterial(new LitMaterialData() { Base = sprite }))
        {
            Transform = transform,
        };

        return new GameObject(new GameObjectData("Default name", renderData.Transform)
        {
            Drawable = new Model(renderData)
        });
    }

    public static GameObject WithRenderData(RenderData renderData)
    {
        return new GameObject(new GameObjectData("Default name", renderData.Transform)
        {
            Drawable = new Model(renderData)
        });
    }

    public static GameObject WithRenderData(string name, RenderData renderData)
    {
        return new GameObject(new GameObjectData(name, renderData.Transform)
        {
            Drawable = new Model(renderData)
        });
    }

    public static GameObject Sprite(string sprite, Transform transform)
    {
        return Sprite(new Texture2D(sprite), transform);
    }

    public static GameObject Sprite(IGameComponent tag, string sprite, Transform transform)
    {
        GameObject gameObject = Sprite(sprite, transform);
        gameObject.Data.Components.Add(tag);
        gameObject.Data.Name = tag.GetType().Name;
        
        return gameObject;
    }

    public static GameObject CreateCamera()
    {
        return CreateCamera(new PerspectiveProjection());
    }

    public static GameObject CreateCamera(CameraProjection projection)
    {
        return CreateCamera(new Camera(projection));
    }

    public static GameObject CreateCamera(Transform transform)
    {
        return CreateCamera(new Camera(transform));
    }

    public static GameObject CreateCamera(Camera camera, float translationSpeed = 4)
    {
        return new GameObject(new GameObjectData("Camera", camera.Transform)
        {
            Components = new List<IGameComponent>
            {
                camera,
                new CameraControlling(camera, translationSpeed),
            },

            Drawable = Gizmo.Instance
        });
    }

    public static GameObject CreateSkybox(string name)
    {
        return CreateSkybox(name, new Vector3(1, 0, 0), 0);
    }
    
    public static GameObject CreateSkybox(string name, Vector3 rotationVector, float rotationSpeed)
    {
        RenderData renderData = new(MeshBuilder.FromObj("cube"), new SkyboxMaterial(new Cubemap(Paths.GetSkybox(name))));

        return new GameObject(new GameObjectData("Skybox", renderData.Transform)
        {
            Drawable = new Model(renderData),
            Components = new List<IGameComponent>() {new Skybox(renderData.Material.Bridge, rotationVector, rotationSpeed)}
        });
    }

    public static GameObject CreateParticleSystem(ParticleSystemData particleSystemData)
    {
        ParticleSystem particleSystem = new(particleSystemData);
        
        return new GameObject(new GameObjectData("Particle system", particleSystem.Transform)
        {
            Drawable = particleSystem
        });
    }

    public static GameObject CreateParticleSystem(ParticleSystem particleSystem)
    {
        return new GameObject(new GameObjectData("Particle system", particleSystem.Transform)
        {
            Drawable = particleSystem
        });
    }

    public static GameObject CreateLight(Transform transform, LightData data)
    {
        return CreateLight(new Light(transform, data));
    }
    
    public static GameObject CreateLight(LightData data)
    {
        return CreateLight(new Light(data));
    }

    public static GameObject CreateLight(Light light)
    {
        return new GameObject(new GameObjectData("Light", light.Transform)
        {
            Drawable = light
        });
    }
}