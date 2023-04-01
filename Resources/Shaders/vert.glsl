#version 330 core

layout(location = 0) in vec3 vertexPosition;
layout (location = 1) in vec3 vertexNormal;
layout(location = 2) in vec2 vertexTextureCoordinates;
uniform mat4 model;
out vec2 textureCoordinates;
out vec3 fragmentPosition;
out vec3 normal;

layout (std140) uniform CameraData
{ 
    mat4 viewMatrix;
    mat4 projectionMatrix;
    vec4 position;
};

void main(void)
{    
    textureCoordinates = vertexTextureCoordinates;    
    fragmentPosition = vec3(model * vec4(vertexPosition, 1.0));
    normal = vertexNormal * mat3(inverse(model));    
                 
    gl_Position = projectionMatrix * viewMatrix * model * vec4(vertexPosition, 1.0);
}