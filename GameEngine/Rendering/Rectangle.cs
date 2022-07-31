﻿using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

public class Rectangle : IDrawable
{
    private readonly Texture _texture = new("Resources/wood.png");
    private readonly ElementBufferObject _elementBufferObject;
    private readonly VertexArrayObject _vertexArrayObject;
    private readonly ShaderProgram _shader;
    private readonly Transform _transform = new();
    private readonly float[] _verticesData = 
    {
        // Position          Texture coordinates
         0.5f,  0.5f, 0.0f,  1.0f, 1.0f, 
         0.5f, -0.5f, 0.0f,  1.0f, 0.0f, 
        -0.5f, -0.5f, 0.0f,  0.0f, 0.0f, 
        -0.5f,  0.5f, 0.0f,  0.0f, 1.0f  
    };
    private readonly uint[] _indices = 
    {  
        0, 1, 3,
        1, 2, 3 
    };

    public Rectangle()
    {
        _elementBufferObject = new ElementBufferObject(_indices);
        _vertexArrayObject = new VertexArrayObject(new VertexBufferObject(_verticesData), new[]
        {
            new AttributePointer(0, 3, 5, 0),
            new AttributePointer(1, 2, 5, 3)
        });

        _shader = new ShaderProgram(new Shader[]
        {
            new("Shaders/vert.glsl", ShaderType.VertexShader),
            new("Shaders/frag.glsl", ShaderType.FragmentShader)
        });
    }

    public void Init()
    {
        _shader.Init();
        _texture.Load();
        _vertexArrayObject.Init();
        _elementBufferObject.Init();
        
        _shader.Bridge.SetMatrix4("transform", Matrix4.Identity * Matrix4.CreateRotationX(45));
    }
    
    public void Draw(in Matrix4 viewMatrix)
    {
        _transform.Rotate(0, 0, 0.01f);
        _shader.Bridge.SetMatrix4("transform", viewMatrix * _transform.ModelMatrix);
        
        _vertexArrayObject.Bind();
        _texture.Use();
        _shader.Use();
        GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
    }
}