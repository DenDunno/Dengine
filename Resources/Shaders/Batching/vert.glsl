#version 430 core

layout(location = 0) in vec3 vertexPosition;
layout (location = 1) in vec3 vertexNormal;
layout(location = 2) in vec2 vertexTextureCoordinates;
layout(location = 3) in float vertexTextureId;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

out vec2 textureCoordinates;
out vec3 fragmentPosition;
out vec3 normal;
flat out float textureId;
      
void main(void)
{       
    textureId = vertexTextureId; 
    textureCoordinates = vertexTextureCoordinates;    
    fragmentPosition = vec3(vec4(vertexPosition, 1.0) * model);
    normal = vertexNormal * mat3(transpose(inverse(model)));                                         
    
    gl_Position = vec4(vertexPosition, 1.0) * model * view * projection;
}