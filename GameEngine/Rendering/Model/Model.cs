﻿using OpenTK.Mathematics;

public class Model : IDrawable
{
    [EditorField] public readonly Material Material;
    [EditorField] private readonly bool _visible = true;
    private readonly VertexArrayObject _vertexArrayObject;
    private readonly GLDrawCommand _glDrawCommand;
    private readonly Transform _transform;

    public Model(RenderData renderData)
    {
        _vertexArrayObject = new VertexArrayObject(renderData);
        _glDrawCommand = renderData.DrawCommand;
        _transform = renderData.Transform;
        Material = renderData.Material;
        _glDrawCommand.SetMesh(renderData.Mesh);
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
            Material.Bridge.SetMatrix4("model", _transform.ModelMatrix);
            Material.Bridge.SetMatrix4("view", viewMatrix);
            Material.Bridge.SetMatrix4("projection", projectionMatrix);
            _vertexArrayObject.Bind();
            Material.Use();
            _glDrawCommand.Execute();
        }
    }

    public void Dispose()
    {
        _vertexArrayObject.Dispose();
        Material.Dispose();
    }
}