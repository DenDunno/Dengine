﻿using OpenTK.Mathematics;

public class Model : IDrawable
{
    [EditorField] public readonly Material Material;
    [EditorField] private readonly bool _visible = true;
    private readonly VertexArrayObject _vertexArrayObject;
    private readonly GLRenderer _glRenderer;
    private readonly Transform _transform;

    public Model(RenderData renderData)
    {
        _vertexArrayObject = new VertexArrayObject(renderData);
        _glRenderer = new GLRenderer(renderData.Mesh);
        _transform = renderData.Transform;
        Material = renderData.Material;
    }

    public void Initialize()
    {
        Material.Initialize();
        _vertexArrayObject.Init();
    }

    public void Draw(in Matrix4 projectionMatrix, in Matrix4 viewMatrix)
    {
        if (_visible)
        {
            Material.Bridge.SetValue("model", _transform.ModelMatrix);
            Material.Bridge.SetValue("view", viewMatrix);
            Material.Bridge.SetValue("projection", projectionMatrix);
            _vertexArrayObject.Bind();
            Material.Use();
            _glRenderer.Draw();
        }
    }

    public void Dispose()
    {
        _vertexArrayObject.Dispose();
        Material.Dispose();
    }
}