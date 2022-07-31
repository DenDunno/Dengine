#version 330 core

layout(location = 0) in vec3 vertexPosition;
layout(location = 1) in vec2 vertexTextureCoordinates;
uniform mat4 transform;
out vec2 textureCoordinates;

void main(void)
{    
    textureCoordinates = vertexTextureCoordinates;    
    gl_Position = vec4(vertexPosition, 1.0) * transform;
}