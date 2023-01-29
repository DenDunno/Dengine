﻿
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

    private static GameObject Sprite(Texture sprite, Transform transform)
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

    private static GameObject Sprite(string sprite, Transform transform)
    {
        return Sprite(new Texture(sprite), transform);
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

    public static GameObject CreateCamera(Camera camera)
    {
        return new GameObject(new GameObjectData("Camera", camera.Transform)
        {
            Components = new List<IGameComponent>
            {
                camera,
            },

            Drawable = Gizmo.Instance
        });
    }

    public static GameObject CreateSkybox(string name, Camera camera)
    {
        return new SkyboxFactory(name, camera.Transform).Create();
    }

    public static GameObject CreateParticleSystem(ParticleSystemData particleSystemData)
    {
        Transform transform = new();
        
        return new GameObject(new GameObjectData("Particle system", transform)
        {
            Drawable = new ParticleSystem(transform, particleSystemData)
        });
    }
}