
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
        RenderData renderData = new()
        {
            Transform = transform,
            Mesh = MeshBuilder.Quad(1f),
            Material = new UnlitMaterial(new LitMaterialData()
            {
                Base = sprite
            })
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

    public static GameObject CreateCamera(Camera camera)
    {
        return new GameObject(new GameObjectData("Camera", camera.Transform)
        {
            Components = new List<IGameComponent>
            {
                camera,
                new CameraControlling(camera),
            },

            Drawable = Gizmo.Instance
        });
    }

    public static GameObject CreateSkybox(string name)
    {
        return WithRenderData("Skybox", new RenderData()
        {
            Mesh = MeshBuilder.FromObj("cube"),
            Material = new SkyboxMaterial(new Cubemap(Paths.GetSkybox(name))),
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

    public static GameObject CreateLight(LightData data)
    {
        Light light = new(data);
        
        return new GameObject(new GameObjectData("Light", light.Transform)
        {
            Drawable = light
        });
    }
}