#version 430 core

layout(location = 0) in vec3 vertexPosition;
layout (location = 1) in vec3 vertexNormal;
layout(location = 2) in vec2 vertexTextureCoordinates;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

layout (binding = 1, std430) buffer Data
{ 
    mat4[] modelMatrices; 
};

out vec2 textureCoordinates;
out vec3 fragmentPosition;
out vec3 normal;
     
void main(void)
{        
    textureCoordinates = vertexTextureCoordinates;    
    fragmentPosition = vec3(vec4(vertexPosition, 1.0) * modelMatrices[gl_InstanceID]);
    normal = vertexNormal * mat3(transpose(inverse(modelMatrices[gl_InstanceID])));                                         
    
    gl_Position = vec4(vertexPosition, 1.0) * modelMatrices[gl_InstanceID] * view * projection;
}