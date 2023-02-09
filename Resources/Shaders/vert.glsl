#version 330 core

layout(location = 0) in vec3 vertexPosition;
layout (location = 1) in vec3 vertexNormal;
layout(location = 2) in vec2 vertexTextureCoordinates;
uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
out vec2 textureCoordinates;
out vec3 fragmentPosition;
out vec3 normal;

void main(void)
{        
    textureCoordinates = vertexTextureCoordinates;    
    fragmentPosition = vec3(vec4(vertexPosition, 1.0) * model);
    normal = vertexNormal * mat3(transpose(inverse(model)));
    
    mat4 dummy = model;
    dummy += mat4(0,0,0,gl_InstanceID, 
                  0,0,0,0,
                  0,0,0,0,
                  0,0,0,0);
                  
    gl_Position = vec4(vertexPosition, 1.0) * dummy * view * projection;
}