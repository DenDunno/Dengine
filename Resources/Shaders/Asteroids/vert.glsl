#version 430 core

layout(location = 0) in vec3 vertexPosition;
layout (location = 1) in vec3 vertexNormal;
layout(location = 2) in vec2 vertexTextureCoordinates;

layout (binding = 1, std430) buffer ModelMatrices
{ 
    mat4[] modelMatrices; 
};

layout (std140) uniform CameraData
{ 
    mat4 viewMatrix;
    mat4 projectionMatrix;
    vec4 position;
};

out vec2 textureCoordinates;
out vec3 fragmentPosition;
out vec3 normal;
     
void main(void)
{        
    textureCoordinates = vertexTextureCoordinates;    
    fragmentPosition = vec3(modelMatrices[gl_InstanceID] * vec4(vertexPosition, 1.0));
    normal = vertexNormal * mat3(inverse(modelMatrices[gl_InstanceID]));                               
    
    gl_Position = projectionMatrix * viewMatrix * modelMatrices[gl_InstanceID] * vec4(vertexPosition, 1.0);
}