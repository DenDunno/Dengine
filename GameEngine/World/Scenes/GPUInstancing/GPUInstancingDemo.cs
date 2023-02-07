﻿
using OpenTK.Mathematics;

public class GPUInstancingDemo : IWorldFactory
{
    public List<GameObject> CreateGameObjects()
    {
        Camera camera = new();
        
        return new List<GameObject>()
        {
            GameObjectFactory.CreateCamera(camera),
            CreateSpace(camera),
            CreateRock()
        };
    }

    private GameObject CreateSpace(Camera camera)
    {
        GameObject skybox = GameObjectFactory.CreateSkybox("Space", camera);
        skybox.Data.Components.Add(new RotationAnimation(skybox.Data.Transform, Vector3.One, 0.015f));

        return skybox;
    }

    private GameObject CreateRock()
    {
        Transform transform = new();

        return new GameObject(new GameObjectData("Rock", transform)
        {
            Drawable = new Model(new RenderData()
            {
                Transform = transform,
                Mesh = MeshBuilder.Quad(1f),
                Material = new Material(Paths.GetShader("vert"), Paths.GetShader("uv")),
                DrawCommand = new DrawElementsInstanced(1_000_000)
            })
        });
    }
}